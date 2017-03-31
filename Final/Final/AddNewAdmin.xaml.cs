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

        private void create_Click(object sender, RoutedEventArgs e)
        {
            Admins addadmin = new Admins();
            Boolean okay = true;
            Boolean checkUserNameExistsnce = addadmin.get_Admin_by_username(adminuname.Text);
            if (checkUserNameExistsnce == true)
            {
                adminleble.Content = "User name already in use ";
            }
            else
            {

                okay = addadmin.Add_Admin(adminfname.Text, adminlname.Text, adminuname.Text, AdminPassword.Password, adminemail.Text, Convert.ToInt64(adminphone.Text));
                //addadmin.Add_Admin(us.Firstname, us.Lastname, us.Username, us.Password, us.Email, us.PhoneNumber);
                  if (okay)
                   {
                    AdminHome ah = new AdminHome();
                    ah.Show();
                    this.Close();
                    }
            }

            

//            if (adminphone.Text == "")
//            {
//                okay = false;
//                MessageBox.Show("Phone number field required!");
//            }
//            else
//            {
//                temp = adminphone.Text.Replace("-", "").Replace("(", "").Replace(")","");
//                okay = long.TryParse(temp, out num);
//                //us.PhoneNumber = Convert.ToInt64(adminphone.Text);

//                if (okay)
//                {
//                    us.PhoneNumber = num;
//                    Admins addadmin = new Admins();
//                    okay = addadmin.Add_Admin(us.Firstname, us.Lastname, us.Username, us.Password, us.Email, us.PhoneNumber);
//                    if (okay)
//                    {
//                        AdminHome ah = new AdminHome();
//                        ah.Show();
//                        this.Close();
//                    }
//                }
//                else
//                {
//                    MessageBox.Show("Invalid phone number!");
//                }
//            }
            
//>>>>>>> 1522a361209096202da7f46a001ba6293561ee90
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            adminfname.Text = "";
            adminlname.Text = "";
            adminuname.Text = "";
            AdminPassword.Password = "";
            adminemail.Text = "";
            adminphone.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ad = new AdminHome();
            ad.Show();
            this.Close(); //this needs to be close not hide so that all windows in the program exit properly and arent running invisible in the background.
        }
    }
}
