using CheckOutApp.views;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CheckOutApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private Dictionary<string, Uri> allViews = new Dictionary<string, Uri>(); //包含所有页面
        public MainWindow()
        {
            InitializeComponent();
            //添加页面的Uri地址，采用相对路径，根路径是项目名,实现allViews的初始化
            allViews.Add("page1", new Uri("views/ManagerSite.xaml", UriKind.Relative));
            allViews.Add("page2", new Uri("views/OperatorSite.xaml", UriKind.Relative));
            allViews.Add("page3", new Uri("views/ManManagement.xaml", UriKind.Relative));
            allViews.Add("page4", new Uri("views/ReportCenter.xaml", UriKind.Relative));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddRecord addRecord = new AddRecord();
            addRecord.ShowDialog();
        }
        public void page1Button(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["page1"]);                   
        }

        /*
        *页面二按钮的响应事件函数，实现导航到page2
        */
        public void page2Button(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["page2"]);                    //Frame导航函数，导航到page2
        }
        public void page3Button(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["page3"]);
        }
        public void page4Button(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(allViews["page4"]);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            EditPassword editPassword = new EditPassword();
            editPassword.ShowDialog();
        }

        private void Weighbridge_Click(object sender, RoutedEventArgs e)
        {
            Connetion connetion = new Connetion();
            connetion.ShowDialog();
        }
    }
}
