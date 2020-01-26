using CheckOutApp.data;
using CheckOutApp.entity;
using CheckOutApp.utill;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows;

namespace CheckOutApp.views
{
    /// <summary>
    /// BathPrint.xaml 的交互逻辑
    /// </summary>
    public partial class BathPrint : MetroWindow
    {
        
        public BathPrint()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintUtill printUtill = new PrintUtill();
            string companyName = CompanyName.Text;
            string startTime = StartTime.SelectedDate.ToString();
            string endTime = EndTime.SelectedDate.Value.AddDays(1).ToString();
            string operatorName = OperatorName.Text;
            List<CheckoutRecord>  records = DBService.GetCheckoutRecords(companyName, startTime, endTime, operatorName);
            foreach(CheckoutRecord record in records)
            {
                printUtill.record = record;
                printUtill.PrintServiceNoPreview();
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
