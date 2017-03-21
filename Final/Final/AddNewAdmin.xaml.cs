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
            User us = new User();
            us.Firstname = adminfname.Text;
            us.Lastname = adminlname.Text;
            us.Username = adminuname.Text;
            us.Password = AdminPassword.Password;
            us.Email = adminemail.Text;
            us.PhoneNumber = Convert.ToInt64(adminphone.Text);

            Admins addadmin = new Admins();
            addadmin.Add_Admin(us.Firstname, us.Lastname, us.Username, us.Password, us.Email, us.PhoneNumber);
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
            this.Hide();
        }
    }
}
