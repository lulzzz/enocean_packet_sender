namespace USB400J_packet_sender
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.button_A50205 = new System.Windows.Forms.Button();
            this.label_F60204 = new System.Windows.Forms.Label();
            this.trackBar_A502xx_temp = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label_A502xx_temp = new System.Windows.Forms.Label();
            this.checkBox_D50001 = new System.Windows.Forms.CheckBox();
            this.textBox_SendPacket = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_A50204 = new System.Windows.Forms.Button();
            this.label_A504xx_humi = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar_A504xx_humi = new System.Windows.Forms.TrackBar();
            this.button_A50401 = new System.Windows.Forms.Button();
            this.button_A50402 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxSendIPAddress = new System.Windows.Forms.TextBox();
            this.textBoxSendPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_UDP = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_A502xx_temp)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_A504xx_humi)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(6, 18);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(245, 20);
            this.comboBoxSerialPort.TabIndex = 0;
            this.comboBoxSerialPort.DropDown += new System.EventHandler(this.comboBoxSerial_DropDown);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConnect.Location = new System.Drawing.Point(257, 18);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(75, 23);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // button_A50205
            // 
            this.button_A50205.Location = new System.Drawing.Point(189, 174);
            this.button_A50205.Name = "button_A50205";
            this.button_A50205.Size = new System.Drawing.Size(140, 23);
            this.button_A50205.TabIndex = 3;
            this.button_A50205.Text = "A5-02-05";
            this.button_A50205.UseVisualStyleBackColor = true;
            this.button_A50205.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label_F60204
            // 
            this.label_F60204.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label_F60204.Location = new System.Drawing.Point(23, 174);
            this.label_F60204.Name = "label_F60204";
            this.label_F60204.Size = new System.Drawing.Size(140, 113);
            this.label_F60204.TabIndex = 4;
            this.label_F60204.Text = "F6-02-04";
            this.label_F60204.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_F60204.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label_MouseDown);
            this.label_F60204.MouseUp += new System.Windows.Forms.MouseEventHandler(this.label_MouseUp);
            // 
            // trackBar_A502xx_temp
            // 
            this.trackBar_A502xx_temp.Location = new System.Drawing.Point(234, 203);
            this.trackBar_A502xx_temp.Maximum = 200;
            this.trackBar_A502xx_temp.Minimum = -100;
            this.trackBar_A502xx_temp.Name = "trackBar_A502xx_temp";
            this.trackBar_A502xx_temp.Size = new System.Drawing.Size(95, 45);
            this.trackBar_A502xx_temp.TabIndex = 5;
            this.trackBar_A502xx_temp.TickFrequency = 20;
            this.trackBar_A502xx_temp.ValueChanged += new System.EventHandler(this.trackBar_A502xx_temp_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(187, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "temp";
            // 
            // label_A502xx_temp
            // 
            this.label_A502xx_temp.AutoSize = true;
            this.label_A502xx_temp.Location = new System.Drawing.Point(187, 216);
            this.label_A502xx_temp.Name = "label_A502xx_temp";
            this.label_A502xx_temp.Size = new System.Drawing.Size(23, 12);
            this.label_A502xx_temp.TabIndex = 6;
            this.label_A502xx_temp.Text = "-℃";
            // 
            // checkBox_D50001
            // 
            this.checkBox_D50001.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox_D50001.Location = new System.Drawing.Point(23, 293);
            this.checkBox_D50001.Name = "checkBox_D50001";
            this.checkBox_D50001.Size = new System.Drawing.Size(140, 23);
            this.checkBox_D50001.TabIndex = 7;
            this.checkBox_D50001.Text = "D5-00-01";
            this.checkBox_D50001.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_D50001.UseVisualStyleBackColor = true;
            this.checkBox_D50001.CheckedChanged += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBox_SendPacket
            // 
            this.textBox_SendPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_SendPacket.Location = new System.Drawing.Point(6, 30);
            this.textBox_SendPacket.Multiline = true;
            this.textBox_SendPacket.Name = "textBox_SendPacket";
            this.textBox_SendPacket.Size = new System.Drawing.Size(326, 96);
            this.textBox_SendPacket.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "Send Packet";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBoxSerialPort);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 51);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Port";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox_SendPacket);
            this.groupBox2.Location = new System.Drawing.Point(12, 356);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 132);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // button_A50204
            // 
            this.button_A50204.Location = new System.Drawing.Point(189, 145);
            this.button_A50204.Name = "button_A50204";
            this.button_A50204.Size = new System.Drawing.Size(140, 23);
            this.button_A50204.TabIndex = 12;
            this.button_A50204.Text = "A5-02-04";
            this.button_A50204.UseVisualStyleBackColor = true;
            this.button_A50204.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // label_A504xx_humi
            // 
            this.label_A504xx_humi.AutoSize = true;
            this.label_A504xx_humi.Location = new System.Drawing.Point(187, 258);
            this.label_A504xx_humi.Name = "label_A504xx_humi";
            this.label_A504xx_humi.Size = new System.Drawing.Size(17, 12);
            this.label_A504xx_humi.TabIndex = 15;
            this.label_A504xx_humi.Text = "-%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(187, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "humi";
            // 
            // trackBar_A504xx_humi
            // 
            this.trackBar_A504xx_humi.Location = new System.Drawing.Point(234, 242);
            this.trackBar_A504xx_humi.Maximum = 100;
            this.trackBar_A504xx_humi.Name = "trackBar_A504xx_humi";
            this.trackBar_A504xx_humi.Size = new System.Drawing.Size(95, 45);
            this.trackBar_A504xx_humi.TabIndex = 13;
            this.trackBar_A504xx_humi.TickFrequency = 20;
            this.trackBar_A504xx_humi.ValueChanged += new System.EventHandler(this.trackBar_A504xx_humi_ValueChanged);
            // 
            // button_A50401
            // 
            this.button_A50401.Location = new System.Drawing.Point(189, 293);
            this.button_A50401.Name = "button_A50401";
            this.button_A50401.Size = new System.Drawing.Size(140, 23);
            this.button_A50401.TabIndex = 16;
            this.button_A50401.Text = "A5-04-01";
            this.button_A50401.UseVisualStyleBackColor = true;
            this.button_A50401.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // button_A50402
            // 
            this.button_A50402.Location = new System.Drawing.Point(189, 322);
            this.button_A50402.Name = "button_A50402";
            this.button_A50402.Size = new System.Drawing.Size(140, 23);
            this.button_A50402.TabIndex = 16;
            this.button_A50402.Text = "A5-04-02";
            this.button_A50402.UseVisualStyleBackColor = true;
            this.button_A50402.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.checkBox_UDP);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxSendPort);
            this.groupBox3.Controls.Add(this.textBoxSendIPAddress);
            this.groupBox3.Location = new System.Drawing.Point(12, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 51);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "UDP";
            // 
            // textBoxSendIPAddress
            // 
            this.textBoxSendIPAddress.Location = new System.Drawing.Point(92, 17);
            this.textBoxSendIPAddress.Name = "textBoxSendIPAddress";
            this.textBoxSendIPAddress.Size = new System.Drawing.Size(100, 19);
            this.textBoxSendIPAddress.TabIndex = 0;
            this.textBoxSendIPAddress.Text = "192.168.0.2";
            // 
            // textBoxSendPort
            // 
            this.textBoxSendPort.Location = new System.Drawing.Point(230, 17);
            this.textBoxSendPort.Name = "textBoxSendPort";
            this.textBoxSendPort.Size = new System.Drawing.Size(98, 19);
            this.textBoxSendPort.TabIndex = 1;
            this.textBoxSendPort.Text = "51111";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port";
            // 
            // checkBox_UDP
            // 
            this.checkBox_UDP.AutoSize = true;
            this.checkBox_UDP.Location = new System.Drawing.Point(6, 20);
            this.checkBox_UDP.Name = "checkBox_UDP";
            this.checkBox_UDP.Size = new System.Drawing.Size(80, 16);
            this.checkBox_UDP.TabIndex = 9;
            this.checkBox_UDP.Text = "IP Address";
            this.checkBox_UDP.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 500);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button_A50402);
            this.Controls.Add(this.button_A50401);
            this.Controls.Add(this.label_A504xx_humi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar_A504xx_humi);
            this.Controls.Add(this.button_A50204);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_D50001);
            this.Controls.Add(this.label_A502xx_temp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar_A502xx_temp);
            this.Controls.Add(this.label_F60204);
            this.Controls.Add(this.button_A50205);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_A502xx_temp)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_A504xx_humi)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button button_A50205;
        private System.Windows.Forms.Label label_F60204;
        private System.Windows.Forms.TrackBar trackBar_A502xx_temp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_A502xx_temp;
        private System.Windows.Forms.CheckBox checkBox_D50001;
        private System.Windows.Forms.TextBox textBox_SendPacket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_A50204;
        private System.Windows.Forms.Label label_A504xx_humi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar_A504xx_humi;
        private System.Windows.Forms.Button button_A50401;
        private System.Windows.Forms.Button button_A50402;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSendPort;
        private System.Windows.Forms.TextBox textBoxSendIPAddress;
        private System.Windows.Forms.CheckBox checkBox_UDP;
    }
}

