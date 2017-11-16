using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USB400J_packet_sender
{
    public partial class Form1 : Form
    {
        SerialPortProcessor serial_ = new SerialPortProcessor();
        Boolean serial_connect_ = false;
        
        public Form1()
        {
            InitializeComponent();

            // COM port list first update
            UpdateSerialPortList();

            // Update GUI
            updateUi();
            
            // Serial port data receive handler
            serial_.DataReceived += serial_DataReceived;
        }

        // --------------------------------------------------
        // Update button, text, ... etc.
        // --------------------------------------------------
        private void updateUi()
        {
            // Button
//            buttonSendSample.Enabled = serial_connect_;
        }

        // --------------------------------------------------
        // Update COM port list just before opening comboBox
        // --------------------------------------------------
        private void comboBoxSerial_DropDown(object sender, EventArgs e)
        {
            // Update COM port list (hope not taking so long time ...)
            UpdateSerialPortList();
        }

        // --------------------------------------------------
        // Update COM port list
        // --------------------------------------------------
        private void UpdateSerialPortList()
        {
            string[] ports = serial_.GetPorts();
            comboBoxSerialPort.Items.Clear();
            foreach (string port in ports)
            {
                comboBoxSerialPort.Items.Add(port);
            }
        }
        
        // --------------------------------------------------
        // Connect COM port
        // --------------------------------------------------
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            serial_.PortName = comboBoxSerialPort.Text;
            try
            {
                if (!serial_connect_)
                {
                    serial_.Start();

                    // The following procedure will only be executed if serial.Start () succeeds.
                    serial_connect_ = true;
                    buttonConnect.Text = "Disconnect";
                    // Update GUI
                    updateUi();
                }
                else
                {
                    // Regardless of the result of serial.Close (), the following procedure is always executed.
                    buttonConnect.Text = "Connect";
                    serial_connect_ = false;
                    // Update GUI
                    updateUi();

                    serial_.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        // --------------------------------------------------
        // Click and build data
        // --------------------------------------------------
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            ERP2DataDL erp2data_dl = null;

            // EEP
            if (sender.Equals(this.label_F60204))
            {
                erp2data_dl = new EEPF60204(
                    ERP2DataDL.BUTTON.PRESSED,
                    ERP2DataDL.BUTTON.NOT_PRESSED, 
                    ERP2DataDL.BUTTON.PRESSED,
                    ERP2DataDL.BUTTON.NOT_PRESSED
                ); // I side pressed
            }

            // build data and send
            buildAndSend(erp2data_dl);
        }
        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            ERP2DataDL erp2data_dl = null;

            // EEP
            if (sender.Equals(this.label_F60204))
            {
                erp2data_dl = new EEPF60204(
                    ERP2DataDL.BUTTON.NOT_PRESSED,
                    ERP2DataDL.BUTTON.NOT_PRESSED,
                    ERP2DataDL.BUTTON.NOT_PRESSED,
                    ERP2DataDL.BUTTON.NOT_PRESSED
                ); // all released
            }

            // build data and send
            buildAndSend(erp2data_dl);
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            ERP2DataDL erp2data_dl = null;

            // EEP
            if (sender.Equals(this.button_A50204))
            {
                erp2data_dl = new EEPA50204((float)trackBar_A502xx_temp.Value);
            }
            if (sender.Equals(this.button_A50205))
            {
                erp2data_dl = new EEPA50205((float)trackBar_A502xx_temp.Value);
            }
            if (sender.Equals(this.button_A50401))
            {
                erp2data_dl = new EEPA50401((float)trackBar_A502xx_temp.Value, (float)trackBar_A504xx_humi.Value);
            }
            if (sender.Equals(this.button_A50402))
            {
                erp2data_dl = new EEPA50402((float)trackBar_A502xx_temp.Value, (float)trackBar_A504xx_humi.Value);
            }
            if (sender.Equals(this.checkBox_D50001))
            {
                ERP2DataDL.BUTTON b = (this.checkBox_D50001.Checked)? ERP2DataDL.BUTTON.CLOSED: ERP2DataDL.BUTTON.OPEN;
                erp2data_dl = new EEPD50001(b);
            }

            // build data and send
            buildAndSend(erp2data_dl);
        }

        // --------------------------------------------------
        // Build and send packets
        // --------------------------------------------------
        private void buildAndSend(ERP2DataDL erp2data_dl)
        {
            // build data
            ESP3Packet esp3pkt = new ESP3PacketType10(erp2data_dl);

            // Serial port data send
            if (serial_connect_)
            {
                serial_SendData(esp3pkt.build());
            }
            // UDP
            if (checkBox_UDP.Checked)
            {
                SendUDP(esp3pkt.build());
            }
        }

        // --------------------------------------------------
        // Serial port data send
        // --------------------------------------------------
        private async void serial_SendData(byte[] buf)
        {
            // Start a thread and send data asynchronously
            await Task.Run(() =>
            {
                try
                {
//                    MessageBox.Show(BitConverter.ToString(buf));
                    Invoke(new Action(() =>
                    {
                        String str = BitConverter.ToString(buf).Replace("-", " ");
                        textBox_SendPacket.Text = "[USB] " + str;
                    }));
                    serial_.WriteData(buf);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception");
                }
            });
        }

        // --------------------------------------------------
        // Serial port data receive handler
        // --------------------------------------------------
        private void serial_DataReceived(byte[] data)
        {
            // nop
        }

        // --------------------------------------------------
        // UDP send
        // --------------------------------------------------
        private async void SendUDP(byte[] buf)
        {
            // Start a thread and send data asynchronously
            await Task.Run(() =>
            {
                IPAddress sendIPAddress = null;
                int sendPort = 0;
                try
                {
                    sendIPAddress = IPAddress.Parse(textBoxSendIPAddress.Text);
                    sendPort = Int32.Parse(textBoxSendPort.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // abort
                }

                // create UdpClient object
                System.Net.Sockets.UdpClient udp =
                    new System.Net.Sockets.UdpClient();

                // sourse IP Address and Port: auto
                // destination IP Address and Port: textBox
                // 送信先
                //リモートホストを指定してデータを送信する
                udp.Send(buf, buf.Length, sendIPAddress.ToString(), sendPort);

                Invoke(new Action(() =>
                {
                    String str = BitConverter.ToString(buf).Replace("-", " ");
                    textBox_SendPacket.Text = "[UDP] "+ str;
                }));

                //UdpClientを閉じる
                udp.Close();
            });
        }

        // --------------------------------------------------
        // Close form
        // --------------------------------------------------
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            serial_.Close();
        }

        // --------------------------------------------------
        // Other event
        // --------------------------------------------------
        private void trackBar_A502xx_temp_ValueChanged(object sender, EventArgs e)
        {
            label_A502xx_temp.Text = trackBar_A502xx_temp.Value.ToString() + "℃";
        }

        private void trackBar_A504xx_humi_ValueChanged(object sender, EventArgs e)
        {
            label_A504xx_humi.Text = trackBar_A504xx_humi.Value.ToString() + "%";
        }


    }
}
