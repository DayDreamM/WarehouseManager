using CheckOutApp.data;
using CheckOutApp.entity;
using MahApps.Metro.Controls;
using System.Windows;

namespace CheckOutApp.views
{
    /// <summary>
    /// AddRecord.xaml 的交互逻辑
    /// </summary>
    public partial class AddRecord : MetroWindow
    {
        public AddRecord()
        {
            InitializeComponent();
        }
        //新增记录
        private void btnLogin_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CheckoutRecord record = new CheckoutRecord
            {
                company = company.Text,
                carNumber = carnumber.Text,
                totalNumber = totalnumber.Text,
                totalSum = totalsum.Text,
                paymentMethod = paymethod.Text
              
            };
            int i = DBService.AddLog(record);
            if (i > 0)
            {
                MessageBox.Show("新增成功", "提示");
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("新增失败", "提示");
            }
        }
    }
}
