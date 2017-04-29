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
    /// Interaction logic for AddNewAdmin.xaml
    /// </summary>
    public partial class AddNewAdmin : Window
    {
        public AddNewAdmin()
        {
            InitializeComponent();
        }

        private void create_Click(object sender, RoutedEventArgs e)//create new admin
        {
            Admins addadmin = new Admins();
            Boolean okay = true;
            Boolean checkUserNameExistsnce = addadmin.get_Admin_by_username(adminuname.Text);//checks if entered username is already in use
            long num = 0;
            if (checkUserNameExistsnce == true)
            {
                adminleble.Content = "User name already in use.";
            }
            else
            {
                if (adminphone.Text == "")//make sure phone number was given
                {
                    okay = false;
                    MessageBox.Show("Phone number field required!");
                }
                else if(adminfname.Text == "" || adminemail.Text == "" || adminlname.Text == "" || adminuname.Text == "" || AdminPassword.Password == ""){
                    MessageBox.Show("Make sure all data fields are filled in!");
                }
                else if (AdminPassword.Password.Length < 6)
                {
                    MessageBox.Show("Password not long enough! Needs to be at least 6 characters.");
                }
                else//if entries are valid
                {
                    string temp = adminphone.Text.Replace("-", "").Replace("(", "").Replace(")", "");//remove special characters from phone number
                    okay = long.TryParse(temp, out num);//test if phone number is valid
                    if (okay)
                    {
                        okay = addadmin.Add_Admin(adminfname.Text, adminlname.Text, adminuname.Text, AdminPassword.Password, adminemail.Text, num);//registers the new admin account
                        if (okay)//if admin successfully added
                        {
                            AdminHome ah = new AdminHome();//return to admin homepage
                            ah.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid phone number");
                    }
                }
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)//clear button
        {
            adminfname.Text = "";
            adminlname.Text = "";
            adminuname.Text = "";
            AdminPassword.Password = "";
            adminemail.Text = "";
            adminphone.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)//return to admin homepage
        {
            AdminHome ad = new AdminHome();
            ad.Show();
            this.Close();
        }
    }
}
