using CheckOutApp.data;
using CheckOutApp.entity;
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

namespace CheckOutApp
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow :  MetroWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        //登录按钮
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Password.Trim();
            bool flag = DBService.Login(username, password);
            if(flag == true)
            {
                MainWindow mainWindow = new MainWindow();
                if (Static_oprator.identity.Equals("0"))
                {
                    mainWindow.OperatorText.Text = "操作员：" + Static_oprator.realname;
                    mainWindow.ManagerBtn.Visibility = Visibility.Collapsed;
                    mainWindow.ManagetSiteBtn.Visibility = Visibility.Collapsed;
                }
                else
                {
                    mainWindow.OperatorText.Text = "管理员：" + Static_oprator.realname;
                    mainWindow.OperatorBtn.Visibility = Visibility.Collapsed;
                }
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
        }
            //移动
            private void window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
