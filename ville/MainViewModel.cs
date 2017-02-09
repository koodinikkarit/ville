using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO.Ports;

namespace ville
{
    class MainViewModel : INotifyPropertyChanged
    {    

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            //comPorts = new ObservableCollection<string>(SerialPort.GetPortNames());
        }

        private string selectedComPort;

        public string Selectedcomport
        {
            get { return selectedComPort; }
            set { selectedComPort = value; }
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


        private string petriIp;

        public string Petriip
        {
            get { return petriIp; }
            set { petriIp = value; }
        }


        private int petriPort;

        public int Petriport
        {
            get { return petriPort; }
            set { petriPort = value; }
        }


        private ObservableCollection<string> comPorts;

        public ObservableCollection<string> Comports
        {
            get { return comPorts; }
            set { comPorts = value; }
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
