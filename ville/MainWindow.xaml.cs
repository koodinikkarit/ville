using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.Ports;

namespace ville
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MainViewModel mainViewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(SerialPort.GetPortNames()[0]);
            //this.DataContext = mainViewModel;
        }

        private void macPartOne_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void macPartThree_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void macPartTwo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void macPartFive_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void macPartSix_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void macPartFour_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void petriIpTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void petriPortTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void saveSettingsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
