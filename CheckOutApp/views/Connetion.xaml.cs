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
    /// Connetion.xaml 的交互逻辑
    /// </summary>
    public partial class Connetion : MetroWindow
    {
        public Connetion()
        {
            InitializeComponent();
            init();
        }
        //初始化函数
        public void init()
        {
            string[] s = SerialPort.GetPortNames();
            foreach (var s1 in s)
            {
                cbbComList.Items.Add(s1);
            }
            if (cbbComList.Items.Count > 0)
            {
                cbbComList.SelectedIndex = 0;
            }
            if (PortConfig.serialPort1.IsOpen == true)
            {
                btnOpen.Content = "已连接!";
                btnOpen.Background = Brushes.Green;
                btnOpen.Foreground = Brushes.White;
            }
        }
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (cbbComList.Items.Count <= 0)
            {
                MessageBox.Show("没有发现串口,请检查线路!", "提示");
                return;
            }
            if (PortConfig.serialPort1.IsOpen == false)
            {
                PortConfig.serialPort1.PortName = cbbComList.SelectedItem.ToString();
                PortConfig.serialPort1.BaudRate = 9600;
                PortConfig.serialPort1.Parity = Parity.None;
                PortConfig.serialPort1.DataBits = 8;
                PortConfig.serialPort1.StopBits = StopBits.One;
                try
                {
                    PortConfig.serialPort1.Open();
                    btnOpen.Content = "连接成功!";
                    btnOpen.Background = Brushes.Green;
                    btnOpen.Foreground = Brushes.White;
                    PortConfig.IsOpen = true;
                    DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "连接错误!");
                    return;
                }
            }
            else
            {
                try
                {
                    PortConfig.serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
                btnOpen.Content = "打开串口";
            }
        }
    }
}
