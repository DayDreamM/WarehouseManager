using CheckOutApp.data;
using CheckOutApp.entity;
using CheckOutApp.utill;
using MahApps.Metro.Controls;
using System;
using System.IO.Ports;
using System.Windows;

namespace CheckOutApp.views
{
    /// <summary>
    /// AddInCar.xaml 的交互逻辑
    /// </summary>
    public partial class AddInCar : MetroWindow
    {
        SerialPort serialPort = new SerialPort();
        public AddInCar()
        {
            InitializeComponent();
            Init();
        }
        //接收数据
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                string backStr = serialPort.ReadExisting();
                Dispatcher.Invoke(new Action(() =>
                {
                    totalnumber.Text = backStr;
                }));
            }
            else
            {
                PortConfig.serialPort1.Open();
                string backStr = PortConfig.serialPort1.ReadExisting();
                Dispatcher.Invoke(new Action(() =>
                {
                    totalnumber.Text = backStr;
                }));
            }
        }
        //新增按钮
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            int i = DBService.AddInCar(carnumber.Text, totalnumber.Text, company.Text, remarks.Text);
            if (i > 0)
            {
                MessageBox.Show("新增成功", "提示");
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("新增失败", "提示");
            }
            serialPort.Close();
        }
        public void Init()
        {
            serialPort.PortName = Port.PortName;
            serialPort.BaudRate = 9600;
            serialPort.Parity = Parity.None;
            serialPort.DataBits = 8;
            serialPort.StopBits = StopBits.One;
            try
            {
                serialPort.Open();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "连接错误!");
                return;
            }
        }
    }
}
