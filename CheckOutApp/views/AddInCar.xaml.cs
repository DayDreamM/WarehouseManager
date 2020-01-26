using CheckOutApp.utill;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
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
using System.Windows.Shapes;

namespace CheckOutApp.views
{
    /// <summary>
    /// AddInCar.xaml 的交互逻辑
    /// </summary>
    public partial class AddInCar : MetroWindow
    {
        public AddInCar()
        {
            InitializeComponent();
            PortConfig.serialPort1.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
        //接收数据
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (PortConfig.serialPort1.IsOpen)
            {
                string backStr = PortConfig.serialPort1.ReadExisting();
                Dispatcher.Invoke(new Action(() =>
                {
                    totalnumber.Text = backStr;
                }));

            }
            else
            {
                MessageBox.Show("串口未打开", "提示");
            }
        }
    }
}
