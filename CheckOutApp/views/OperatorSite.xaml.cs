using CheckOutApp.data;
using CheckOutApp.entity;
using CheckOutApp.utill;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CheckOutApp.views
{
    /// <summary>
    /// OperatorSite.xaml 的交互逻辑
    /// </summary>
    public partial class OperatorSite : Page
    {
        public OperatorSite()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            List<CheckoutRecord> records = DBService.GetCheckoutRecords();
            List<InCar> cars = DBService.GetInCars();
            RecordDataGrid.ItemsSource = records;
            InCarGrid.ItemsSource = cars;
        }
        //新增按钮
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.ShowDialog();
            if (addRecord.DialogResult == true)
            {
                init();
            }
        }

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
        //弹出批量打印窗口
        private void BathPrintBtn_Click(object sender, RoutedEventArgs e)
        {
            BathPrint bathPrint = new BathPrint();
            bathPrint.ShowDialog();
        }
        //新增在场车辆
        private void AddCarBtn_Click(object sender, RoutedEventArgs e)
        {
            AddInCar addInCar = new AddInCar();
            addInCar.ShowDialog();
            if (addInCar.DialogResult == true)
            {
                init();
            }
        }
        //结算出场
        private void outCar_Click(object sender, RoutedEventArgs e)
        {
            if (InCarGrid.SelectedItem is InCar inCar)
            {
                OutCar outCar = new OutCar();
                outCar.company.Text = inCar.company;
                outCar.carnumber.Text = inCar.carNumber;
                outCar.ShowDialog();
            }
        }
    }
}
