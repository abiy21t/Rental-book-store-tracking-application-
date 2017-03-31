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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        public CreateUser()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)//cancel button
        {
            AdminHome ah = new AdminHome();
            ah.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//create button
        {
            Boolean okay = true;
            long num = 0;
            string temp = "";
            User us = new User();
            us.Firstname = textBox_fname.Text;
            us.Lastname = textBox_lname.Text;
            us.Username = textBox_user.Text;
            us.Password = passwordBox.Password;
            us.Email = textBox_email.Text;
            if (textBox_phone.Text == "")
            {
                okay = false;
                MessageBox.Show("Phone number field required!");
            }
            else
            {
                temp = textBox_phone.Text.Replace("-", "").Replace("(", "").Replace(")", "");
                okay = long.TryParse(temp, out num);
                //us.PhoneNumber = Convert.ToInt64(adminphone.Text);

                if (okay)
                {
                    us.PhoneNumber = num;
                    User user = new User();
                    okay = user.Add_User(us.Username,us.Password,us.Firstname, us.Lastname, us.Email, us.PhoneNumber);
                    if (okay)
                    {
                        AdminHome ah = new AdminHome();
                        ah.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid phone number!");
                }
            }
        }
    }
}
