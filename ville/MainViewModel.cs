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

        private SerialPort serialPort;

        public MainViewModel()
        {
            comPorts = new ObservableCollection<string>(SerialPort.GetPortNames());
        }

        private ConfigModel config;

        public ConfigModel Config
        {
            get { return config; }
            set {
                config = value;
                OnPropertyChanged("Config");
            }
        }

        private string selectedComPort;

        public string Selectedcomport
        {
            get { return selectedComPort; }
            set {
                selectedComPort = value;
                if (value != null && value != "")
                {

                    serialPort = new SerialPort(value);
                    serialPort.DataReceived += SerialPort_DataReceived;
                    while (serialPort.IsOpen == false) serialPort.Open();
                    //serialPort.Open();
                    byte[] message = new byte[1];
                    message[0] = Commands.REPORT_ALL_CONFIG;
                    serialPort.Write(message, 0, message.Length);
                }
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string data = sp.ReadExisting();
            Config = new ConfigModel(data);
        }

        public void sendUpdates()
        {
            var c = config.Changedmessage;
            while (serialPort.IsOpen == false) serialPort.Open();
            serialPort.Write(config.Changedmessage, 0, config.Bytestosend);
            //byte[] message = new byte[1];
            //message[0] = Commands.SET_PEKKA_IP;
            //serialPort.Write(message, 0, message.Length);
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
