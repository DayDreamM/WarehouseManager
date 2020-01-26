using CheckOutApp.data;
using CheckOutApp.entity;
using System.Windows;
using System.Windows.Controls;

namespace CheckOutApp.views
{
    /// <summary>
    /// ReportCenter.xaml 的交互逻辑
    /// </summary>
    public partial class ReportCenter : Page
    {
        public ReportCenter()
        {
            InitializeComponent();
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            string startTime = StartTime.SelectedDate.ToString();
            string endTime = EndTime.SelectedDate.Value.AddDays(1).ToString();
            Statistics statistics = DBService.GetStatistics(startTime, endTime);
            SumText.Text = statistics.count;
            Sum.Text = statistics.totalsum;
            Sumnumber.Text = statistics.totalnumber;
        }
    }
}
