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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)//add book button
        {
            AddBooksPage bk = new AddBooksPage();//opens the add book page
            bk.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)//add admin button
        {
            AddNewAdmin ad = new AddNewAdmin();//opens the add admin page
            ad.Show();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)//logout button
        {
            LoginPage lp = new LoginPage();//return user to login page
            lp.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//add clerk/new user
        {
            CreateUser cu = new CreateUser();//opens add user/clerk page
            cu.Show();
            this.Close();
        }

        private void button_report_Click(object sender, RoutedEventArgs e)//create report button
        {
            //show listbox
            listBox_report.Visibility = Visibility.Visible;
            button_hide.Visibility = Visibility.Visible;
            button_copy.Visibility = Visibility.Visible;
            BookData bd = new BookData();
            //clear cart so all books in system are shown
            bd.ClearCart();
            List<string> report = new List<string>();
            report = bd.CreateReport();//create the report
            foreach (var item in report)//put report into the listbox
            {
                listBox_report.Items.Add(item);
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)//update/delete button
        {
            UpdateAndDeletePage ud = new UpdateAndDeletePage();//opens update and delete page
            ud.Show();
            this.Close();
        }

        private void button_hide_Click(object sender, RoutedEventArgs e)//hides report
        {
            listBox_report.Visibility = Visibility.Collapsed;
            button_hide.Visibility = Visibility.Collapsed;
            button_copy.Visibility = Visibility.Collapsed;
        }

        private void button4_Click_1(object sender, RoutedEventArgs e)//copys the selected items ISBN to clipboard
        {
            if(listBox_report.SelectedItems.Count >= 1)
            {
                string item = listBox_report.SelectedItem.ToString();
                if (item.Contains("["))//make sure selected item contains ISBN
                {
                    string isbn;
                    int index = item.LastIndexOf("[");
                    int index2 = item.LastIndexOf("]");
                    isbn = item.Substring(index + 1, index2 - index - 1);
                    Clipboard.SetText(isbn);
                }
            }
        }
    }
}
