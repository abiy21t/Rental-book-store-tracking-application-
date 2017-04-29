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

namespace Final
{
    /// <summary>
    /// Interaction logic for LoginnPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)//login button
        {
            LoginPclass log = new LoginPclass();
            log.UserName = txtuname.Text;
            log.Password = passwordBox.Password;
            bool auth = log.AdminLogin(log.UserName, log.Password);
            if(txtuname.Text == "" || passwordBox.Password == "")//display errors
            {
                if (txtuname.Text == "")
                {
                    nameandpassword.Content = "";
                    username.Content = "Username required";
                }else
                {
                    username.Content = "";
                }
                if (passwordBox.Password == "")
                {
                    nameandpassword.Content = "";
                    password.Content = "Password required";
                }
                else
                {
                    password.Content = "";
                }
            }           
            else
            {
                username.Content = "";
                password.Content = "";
                if (radAdmin.IsChecked == true)//admin login
                {
                    if (auth == true)
                    {
                        //send user to admin homepage
                        AdminHome adh = new AdminHome();
                        adh.Show();
                        this.Close();
                        //MessageBox.Show("user name and password correct");
                    }
                    else//invalid admin login credentials
                    {
                        username.Content = "";
                        password.Content = "";
                        nameandpassword.Content = ("Username or Password incorrect.");
                    }
                }
                else if (radUser.IsChecked == true)//user/clerk login
                {
                    log.UserName = txtuname.Text;
                    log.Password = passwordBox.Password;
                    Boolean authorized = log.UserLogin(log.UserName, log.Password);
                    if (authorized)
                    {
                        ClerkHome ch = new ClerkHome();
                        ch.Show();
                        this.Close();
                    }
                    else//invalid clerk login credentials
                    {
                        nameandpassword.Content = ("Username or Password incorrect.");
                    }
                }
            }
        }
    }
}
