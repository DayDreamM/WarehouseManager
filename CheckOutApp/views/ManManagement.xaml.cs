using CheckOutApp.data;
using CheckOutApp.entity;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CheckOutApp.views
{
    /// <summary>
    /// ManManagement.xaml 的交互逻辑
    /// </summary>
    public partial class ManManagement : Page
    {
        public ManManagement()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            List<User> users = DBService.GetUserInfo();
            UserDataGrid.ItemsSource = users;
        }
        //新增人员
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
            if(addUser.DialogResult == true)
            {
                init();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
