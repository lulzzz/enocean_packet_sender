using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace USB400J_packet_sender
{
    enum R_ORG
    {
        R_ORG_RPS = 0x00,
        R_ORG_1BS = 0x01,
        R_ORG_4BS = 0x02,
        R_ORG_VLD = 0x04,
    }

    abstract class ERP2DataDL
    {
        //
        protected abstract R_ORG getRORG();
        protected abstract byte[] getData();
        public ushort data_length_
        {
            get { return (ushort)(getData().Length + 6); }
        }

        public byte[] build()
        {
            byte[] data = new byte[this.data_length_];
            // Bit 5…7 Address Control, 001: Originator-ID 32 bit; no Destination-ID
            // Bit 4 Extended header available, 0: No extended header
            // Bit 0…3 Telegram type (R-ORG)
            //      0000: RPS telegram (0xF6) 
            //      0001: 1BS telegram (0xD5) 
            //      0010: 4BS telegram (0xA5)
            //      0100: Variable length data telegram (0xD2)
            data[0] = (byte)(0x20 | (int)getRORG());
            // Originator-ID
            data[1] = 0x11; // will be overwritten with the ID of the sending device
            data[2] = 0x22;
            data[3] = 0x33;
            data[4] = 0x44;
            // Data_DL
            Array.Copy(getData(), 0, data, 5, getData().Length);
            // CRC
            data[5 + getData().Length] = 0xFF; // ignored ?

            return data;
        }

        protected byte getByteLinear(float f_min, float f_max, byte b1, byte b2, float f)
        {
            return
                (f <= f_min) ? b1 :
                (f >= f_max) ? b2 :
                (byte)(b1 + (f - f_min) * ((float)b2 - (float)b1) / (f_max - f_min))
            ;
        }

        public enum BUTTON
        {
            NOT_PRESSED = 0x00,
            PRESSED = 0x01,

            RELEASED = 0x00,

            OPEN = 0x00,
            CLOSED = 0x01,
        }
    }

    // 
    // EEP
    // 
    class EEPF60204 : ERP2DataDL
    {
        byte[] data_ = new byte[1];
        public EEPF60204(BUTTON b_rbi, BUTTON b_rbo, BUTTON b_rai, BUTTON b_rao)
        {
            int rbi = (int)b_rbi;
            int rbo = (int)b_rbo;
            int rai = (int)b_rai;
            int rao = (int)b_rao;
            int ebo = ((rbi | rbo | rai | rao) == (int)BUTTON.NOT_PRESSED) ? 
                (int)BUTTON.RELEASED : (int)BUTTON.PRESSED
            ;
            int data =
                (ebo << 7) // DB0.7
                | (0 << 6) // DB0.6
                | (rbi << 3) | (rbo << 2) | (rai << 1) | (rao << 0) // DB0.3 - DB0.0
            ;
            this.data_[0] = (byte)data;
        }
        protected override R_ORG getRORG() { return R_ORG.R_ORG_RPS; }
        protected override byte[] getData() { return data_; }
    }

    class EEPD50001 : ERP2DataDL
    {
        byte[] data_ = new byte[1];
        public EEPD50001(BUTTON b_co)
        {
            int co = (int)b_co;
            int lrn = 1;
            int data =
                (lrn << 3) // DB0.3
                | (co << 0) // DB0.0
            ;
            this.data_[0] = (byte)data;
        }
        protected override R_ORG getRORG() { return R_ORG.R_ORG_1BS; }
        protected override byte[] getData() { return data_; }
    }

    abstract class EEPA502_08bit : ERP2DataDL
    {
        protected virtual float min { get; private set; }
        protected virtual float max { get; private set; }
        byte[] data_ = new byte[4];
        public EEPA502_08bit(float temp)
        {
            // init
            this.data_[0] = this.data_[1] = this.data_[2] = this.data_[3] = 0x00;
            // set
            this.data_[2] = getByteLinear(min, max, 255, 0, temp);
            this.data_[3] = 1 << 3; // DB0.3

        }
        protected override R_ORG getRORG() { return R_ORG.R_ORG_4BS; }
        protected override byte[] getData() { return data_; }
    }

    class EEPA50204 : EEPA502_08bit
    {
        protected override float min { get { return -10f; } }
        protected override float max { get { return 30f; } }
        public EEPA50204(float temp) : base(temp) { }
    }

    class EEPA50205 : EEPA502_08bit
    {
        protected override float min { get { return 0f; } }
        protected override float max { get { return 40f; } }
        public EEPA50205(float temp) : base(temp) { }
    }

    abstract class EEPA504_08bit : ERP2DataDL
    {
        private float humi_min = 0f;
        private float humi_max = 100f;
        protected virtual float temp_min { get; private set; }
        protected virtual float temp_max { get; private set; }
        byte[] data_ = new byte[4];
        public EEPA504_08bit(float temp, float humi)
        {
            // init
            this.data_[0] = this.data_[1] = this.data_[2] = this.data_[3] = 0x00;
            // set
            // humidity
            this.data_[1] = getByteLinear(humi_min, humi_max, 0, 250, humi);
            // temp
            this.data_[2] = getByteLinear(temp_min, temp_max, 0, 250, temp);
            this.data_[3] =
                1 << 3 // DB0.3
                | 1 << 1 // DB0.1
            ;
        }
        protected override R_ORG getRORG() { return R_ORG.R_ORG_4BS; }
        protected override byte[] getData() { return data_; }
    }
    class EEPA50401 : EEPA504_08bit
    {
        protected override float temp_min { get { return 0f; } }
        protected override float temp_max { get { return 40f; } }
        public EEPA50401(float temp, float humi) : base(temp, humi) { }
    }
    class EEPA50402 : EEPA504_08bit
    {
        protected override float temp_min { get { return -20f; } }
        protected override float temp_max { get { return 60f; } }
        public EEPA50402(float temp, float humi) : base(temp, humi) { }
    }

}

