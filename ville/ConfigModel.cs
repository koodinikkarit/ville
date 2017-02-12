using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ville
{
    class ConfigModel : INotifyPropertyChanged
    {
        const byte REPORT_ALL_CONFIG = 1;
        const int REPORT_PEKKA_IP = 2;
        const int REPORT_PEKKA_PORT = 3;
        const int REPORT_MAC = 4;
        const byte PEKKA_IP = 5;
        const byte PEKKA_PORT = 6;
        const byte MAC = 7;

        public event PropertyChangedEventHandler PropertyChanged;

        public ConfigModel()
        {

        }

        public ConfigModel(byte[] configs)
        {

        }

        public ConfigModel(string configs)
        {
            for (var i = 0; i < configs.Length; i++)
            {
                switch((byte)configs[i])
                {
                    case PEKKA_IP:
                        i++;
                        ipPartOne = (byte)configs[i];
                        i++;
                        Ipparttwo = (byte)configs[i];
                        i++;
                        Ippartthree = (byte)configs[i];
                        i++;
                        Ippartfour = (byte)configs[i];
                        //i++;

                        break;
                    case PEKKA_PORT:
                        int port = 0;
                        i++;
                        port |= (configs[i] << 8);
                        i++;
                        port |= configs[i];
                        //i++;
                        Pekkaport = port;
                        break;
                    case MAC:
                        i++;
                        Macpartone = (byte)configs[i];
                        i++;
                        Macparttwo = (byte)configs[i];
                        i++;
                        Macpartthree = (byte)configs[i];
                        i++;
                        Macpartfour = (byte)configs[i];
                        i++;
                        Macpartfive = (byte)configs[i];
                        i++;
                        Macpartsix = (byte)configs[i];
                        i++;                     
                        break;
                }
            }
        }

        public override bool Equals(object model)
        {
            ConfigModel config = (ConfigModel)model;
            if (macPartOne != config.macPartOne) return false;
            if (macPartTwo != config.macPartTwo) return false;
            if (macPartThree != config.macPartThree) return false;
            if (macPartFour != config.macPartFour) return false;
            if (macPartFive != config.macPartFive) return false;
            if (macPartSix != config.macPartSix) return false;
            if (ipPartOne != config.ipPartOne) return false;
            if (ipPartTwo != config.ipPartTwo) return false;
            if (ipPartThree != config.ipPartThree) return false;
            if (ipPartFour != config.ipPartFour) return false;
            if (pekkaPort != config.pekkaPort) return false;
            return true;
        }




        private byte macPartOne;

        public byte Macpartone
        {
            get { return macPartOne; }
            set { macPartOne = value; }
        }


        private byte macPartTwo;

        public byte Macparttwo
        {
            get { return macPartTwo; }
            set { macPartTwo = value; }
        }


        private byte macPartThree;

        public byte Macpartthree
        {
            get { return macPartThree; }
            set { macPartThree = value; }
        }

        private byte macPartFour;

        public byte Macpartfour
        {
            get { return macPartFour; }
            set { macPartFour = value; }
        }

        private byte macPartFive;

        public byte Macpartfive
        {
            get { return macPartFive; }
            set { macPartFive = value; }
        }

        private byte macPartSix;

        public byte Macpartsix
        {
            get { return macPartSix; }
            set { macPartSix = value; }
        }


        private string pekkaIp;

        public string Pekkaip
        {
            get { return pekkaIp; }
            set { pekkaIp = value; }
        }

        private byte ipPartOne;

        public byte Ippartone
        {
            get { return ipPartOne; }
            set {
                ipPartOne = value;
                OnPropertyChanged("Ippartone");
            }
        }

        private byte ipPartTwo;

        public byte Ipparttwo
        {
            get { return ipPartTwo; }
            set { ipPartTwo = value; }
        }


        private byte ipPartThree;

        public byte Ippartthree
        {
            get { return ipPartThree; }
            set { ipPartThree = value; }
        }


        private byte ipPartFour;

        public byte Ippartfour
        {
            get { return ipPartFour; }
            set { ipPartFour = value; }
        }

        private int pekkaPort;

        public int Pekkaport
        {
            get { return pekkaPort; }
            set { pekkaPort = value; }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}

