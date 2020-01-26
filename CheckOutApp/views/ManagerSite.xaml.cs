using CheckOutApp.data;
using CheckOutApp.entity;
using CheckOutApp.utill;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CheckOutApp.views
{
    /// <summary>
    /// ManagerSite.xaml 的交互逻辑
    /// </summary>
    public partial class ManagerSite : Page
    {
        public ManagerSite()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            List<CheckoutRecord> records = DBService.GetCheckoutRecords();
            RecordDataGrid.ItemsSource = records;
        }
        //打印
        private void PrintCheck_Click(object sender, RoutedEventArgs e)
        {
            if (RecordDataGrid.SelectedItem is CheckoutRecord record)
            {
                PrintUtill utill = new PrintUtill
                {
                    record = record
                };
                utill.PrintService();
            }
        }
        //批量打印
        private void BathPrintBtn_Click(object sender, RoutedEventArgs e)
        {
            BathPrint bathPrint = new BathPrint();
            bathPrint.ShowDialog();
        }
        //删除记录
        private void DeleteCheck_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("是否删除记录?", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                CheckoutRecord record = RecordDataGrid.SelectedItem as CheckoutRecord;
                int i = DBService.DeleteRecord(record.recordId);
                if (i > 0)
                {
                    MessageBox.Show("删除成功", "提示");
                    init();
                }
            }
            else
            {
                MessageBox.Show("删除失败", "提示");
            }
        }
        //新增记录
        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.ShowDialog();
            if (addRecord.DialogResult == true)
            {
                init();
            }
        }
        //搜索
        private void QueryBtn_Click(object sender, RoutedEventArgs e)
        {
            List<CheckoutRecord> records = DBService.GetCheckoutRecordsById(Keyword.Text);
            RecordDataGrid.ItemsSource = records;
        }
    }
}
