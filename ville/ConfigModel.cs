using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ville
{
    class ConfigModel : INotifyPropertyChanged, ICloneable
    {
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
                    case Commands.PEKKA_IP:
                        i++;
                        ipPartOne = (byte)configs[i];
                        Ippartoneoriginal = (byte)configs[i];
                        i++;
                        ipPartTwo = (byte)configs[i];
                        Ipparttwooriginal = (byte)configs[i];
                        i++;
                        ipPartThree = (byte)configs[i];
                        Ippartthreeoriginal = (byte)configs[i];
                        i++;
                        ipPartFour = (byte)configs[i];
                        Ippartfouroriginal = (byte)configs[i];
                        break;
                    case Commands.PEKKA_PORT:
                        int port = 0;
                        i++;
                        port |= (configs[i] << 8);                     
                        i++;
                        port |= configs[i];
                        pekkaPort = port;
                        Pekkaportoriginal = port;
                        break;
                    case Commands.MAC:
                        i++;
                        macPartOne = (byte)configs[i];
                        Macpartoneoriginal = (byte)configs[i];
                        i++;
                        macPartTwo = (byte)configs[i];
                        Macparttwooriginal = (byte)configs[i];
                        i++;
                        macPartThree = (byte)configs[i];
                        Macpartthreeoriginal = (byte)configs[i];
                        i++;
                        macPartFour = (byte)configs[i];
                        Macpartfouroriginal = (byte)configs[i];
                        i++;
                        macPartFive = (byte)configs[i];
                        Macpartfiveoriginal = (byte)configs[i];
                        i++;
                        macPartSix = (byte)configs[i];
                        Macpartsixoriginal = (byte)configs[i];
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

        public object Clone()
        {
            return new ConfigModel()
            {
                Macpartone = macPartOne,
                Macparttwo = macPartTwo,
                Macpartthree = macPartThree,
                Macpartfour = macPartFour,
                Macpartfive = macPartFive,
                Macpartsix = macPartSix,
                Ippartone = ipPartOne,
                Ipparttwo = ipPartTwo,
                Ippartthree = ipPartThree,
                Ippartfour = ipPartFour,
                Pekkaport = pekkaPort
            };
        }



        private bool changed;

        public bool Changed
        {
            get {
                bool c = (
                    macPartOne != Macpartoneoriginal ||
                    macPartTwo != Macparttwooriginal ||
                    macPartThree != Macpartthreeoriginal ||
                    macPartFour != Macpartfouroriginal ||
                    macPartFive != Macpartfiveoriginal ||
                    macPartSix != Macpartsixoriginal ||
                    ipPartOne != Ippartoneoriginal ||
                    ipPartTwo != Ipparttwooriginal ||
                    ipPartThree != Ippartthreeoriginal ||
                    ipPartFour != Ippartfouroriginal ||
                    pekkaPort != Pekkaportoriginal
                );

                return (
                    macPartOne != Macpartoneoriginal ||
                    macPartTwo != Macparttwooriginal ||
                    macPartThree != Macpartthreeoriginal ||
                    macPartFour != Macpartfouroriginal ||
                    macPartFive != Macpartfiveoriginal ||
                    macPartSix != Macpartsixoriginal ||
                    ipPartOne != Ippartoneoriginal ||
                    ipPartTwo != Ipparttwooriginal ||
                    ipPartThree != Ippartthreeoriginal ||
                    ipPartFour != Ippartfouroriginal ||
                    pekkaPort != Pekkaportoriginal
                );
            }
        }

        public byte[] Changedmessage {
            get
            {
                bytesToSend = 0;
                byte[] message = new byte[12];
                if (macPartOne != Macpartoneoriginal ||
                    macPartTwo != Macparttwooriginal ||
                    macPartThree != Macpartthreeoriginal ||
                    macPartFour != Macpartfouroriginal ||
                    macPartFive != Macpartfiveoriginal ||
                    macPartFive != Macpartfiveoriginal ||
                    macPartSix != Macpartsixoriginal)
                {
                    message[bytesToSend] = Commands.SET_MAC;
                    bytesToSend++;
                    message[bytesToSend] = macPartOne;
                    bytesToSend++;
                    message[bytesToSend] = macPartTwo;
                    bytesToSend++;
                    message[bytesToSend] = macPartThree;
                    bytesToSend++;
                    message[bytesToSend] = macPartFour;
                    bytesToSend++;
                    message[bytesToSend] = macPartFive;
                    bytesToSend++;
                    message[bytesToSend] = macPartSix;
                    bytesToSend++;
                }
                if (ipPartOne != Ippartoneoriginal ||
                    ipPartTwo != Ipparttwooriginal ||
                    ipPartThree != Ippartthreeoriginal ||
                    ipPartFour != Ippartfouroriginal)
                {
                    message[bytesToSend] = Commands.SET_PEKKA_IP;
                    bytesToSend++;
                    message[bytesToSend] = ipPartOne;
                    bytesToSend++;
                    message[bytesToSend] = ipPartTwo;
                    bytesToSend++;
                    message[bytesToSend] = ipPartThree;
                    bytesToSend++;
                    message[bytesToSend] = ipPartFour;
                    bytesToSend++;
                }
                if (pekkaPort != Pekkaportoriginal)
                {
                    byte pekkaPortPart1 = (byte)(pekkaPort >> 8);
                    byte pekkaPortPart2 = (byte)(pekkaPort & 0xff);
                    message[bytesToSend] = Commands.SET_PEKKA_PORT;
                    bytesToSend++;
                    message[bytesToSend] = pekkaPortPart1;
                    bytesToSend++;
                    message[bytesToSend] = pekkaPortPart2;
                    bytesToSend++;
                }
                return message;
            }
        }

        private int bytesToSend;
        public int Bytestosend { get
            {
                return bytesToSend;
            }
        }

        public byte Macpartoneoriginal { get; set; }
        public byte Macparttwooriginal { get; set; }
        public byte Macpartthreeoriginal { get; set; }
        public byte Macpartfouroriginal { get; set; }
        public byte Macpartfiveoriginal { get; set; }
        public byte Macpartsixoriginal { get; set; }
        public byte Ippartoneoriginal { get; set; }
        public byte Ipparttwooriginal { get; set; }
        public byte Ippartthreeoriginal { get; set; }
        public byte Ippartfouroriginal { get; set; }
        public int Pekkaportoriginal { get; set; }

        private byte macPartOne;

        public byte Macpartone
        {
            get {
                return macPartOne;
            }
            set {
                if (macPartOne != value)
                {
                    macPartOne = value;
                    OnPropertyChanged("Macpartone");
                    OnPropertyChanged("Changed");
                }
            }
        }


        private byte macPartTwo;

        public byte Macparttwo
        {
            get { return macPartTwo; }
            set {
                if (macPartTwo != value)
                {
                    macPartTwo = value;
                    OnPropertyChanged("Macparttwo");
                    OnPropertyChanged("Changed");
                }
            }
        }


        private byte macPartThree;

        public byte Macpartthree
        {
            get { return macPartThree; }
            set {
                if (macPartThree != value)
                {
                    macPartThree = value;
                    OnPropertyChanged("Macpartthree");
                    OnPropertyChanged("Changed");
                }
            }
        }

        private byte macPartFour;

        public byte Macpartfour
        {
            get { return macPartFour; }
            set {
                if (macPartFour != value)
                {
                    macPartFour = value;
                    OnPropertyChanged("Macpartfour");
                    OnPropertyChanged("Changed");
                }
            }
        }

        private byte macPartFive;

        public byte Macpartfive
        {
            get { return macPartFive; }
            set {
                if (macPartFive != value)
                {
                    macPartFive = value;
                    OnPropertyChanged("Macpartfive");
                    OnPropertyChanged("Changed");
                }
            }
        }

        private byte macPartSix;

        public byte Macpartsix
        {
            get { return macPartSix; }
            set {
                if (macPartSix != value)
                {
                    macPartSix = value;
                    OnPropertyChanged("Macpartsix");
                    OnPropertyChanged("Changed");
                }
            }
        }


        private string pekkaIp;

        public string Pekkaip
        {
            get { return pekkaIp; }
            set {
                if (pekkaIp != value)
                {
                    pekkaIp = value;
                    OnPropertyChanged("Pekkaip");
                    OnPropertyChanged("Changed");
                }
            }
        }

        private byte ipPartOne;

        public byte Ippartone
        {
            get { return ipPartOne; }
            set {
                if (ipPartOne != value)
                {
                    ipPartOne = value;
                    OnPropertyChanged("Ippartone");
                    OnPropertyChanged("Changed");
                }
            }
        }

        private byte ipPartTwo;

        public byte Ipparttwo
        {
            get { return ipPartTwo; }
            set {
                if (ipPartTwo != value)
                {
                    ipPartTwo = value;
                    OnPropertyChanged("Ipparttwo");
                    OnPropertyChanged("Changed");
                }
            }
        }


        private byte ipPartThree;

        public byte Ippartthree
        {
            get { return ipPartThree; }
            set {
                if (ipPartThree != value)
                {
                    ipPartThree = value;
                    OnPropertyChanged("Ippartthree");
                    OnPropertyChanged("Changed");
                }
            }
        }


        private byte ipPartFour;

        public byte Ippartfour
        {
            get { return ipPartFour; }
            set {
                if (ipPartFour != value)
                {
                    ipPartFour = value;
                    OnPropertyChanged("Ippartfour");
                    OnPropertyChanged("Changed");
                }
            }
        }

        private int pekkaPort;

        public int Pekkaport
        {
            get { return pekkaPort; }
            set {
                if (pekkaPort != value)
                {
                    pekkaPort = value;
                    OnPropertyChanged("Pekkaport");
                    OnPropertyChanged("Changed");
                }
            }
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

