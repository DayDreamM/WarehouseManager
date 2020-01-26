using CheckOutApp.data;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
    /// AddUser.xaml 的交互逻辑
    /// </summary>
    public partial class AddUser : MetroWindow
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            int i = DBService.AddUser(username.Text, password.Text, realName.Text,phoneNumber.Text,sex.Text);
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
