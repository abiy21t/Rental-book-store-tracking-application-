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
            AddBooksPage bk = new AddBooksPage();
            bk.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)//add admin button
        {
            AddNewAdmin ad = new AddNewAdmin();
            ad.Show();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)//logout button
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//add clerk/new user
        {
            CreateUser cu = new CreateUser();
            cu.Show();
            this.Close();
        }

        private void button_report_Click(object sender, RoutedEventArgs e)//create report button
        {
            listBox_report.Visibility = Visibility.Visible;
            button_hide.Visibility = Visibility.Visible;
            button_copy.Visibility = Visibility.Visible;
            BookData bd = new BookData();
            bd.ClearCart();
            List<string> report = new List<string>();
            report = bd.CreateReport();
            foreach (var item in report)
            {
                listBox_report.Items.Add(item);
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)//add book through OpenLibrary.org
        {
            BookData bd = new BookData();
            //show isbn entry field

            //collect isbn and check if valid
                //string isbn = someTextBox
            //if valid send to openlibrary api
                //bd.AccessOpenLibrary(isbn); <-- this will return a book
            //add returned book to database <-- maybe we can move this step to AccessOpenLibrary()

        }


        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Book se = new Book();
            //se.SearchBook(searchtxt.Text);

        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            UpdateAndDeletePage ud = new UpdateAndDeletePage();
            ud.Show();
            this.Close();
        }

        private void button_hide_Click(object sender, RoutedEventArgs e)
        {
            listBox_report.Visibility = Visibility.Collapsed;
            button_hide.Visibility = Visibility.Collapsed;
            button_copy.Visibility = Visibility.Collapsed;
        }

        private void button4_Click_1(object sender, RoutedEventArgs e)
        {

            if(listBox_report.SelectedItems.Count >= 1)
            {
                string item = listBox_report.SelectedItem.ToString();
                if (item.Contains("["))
                {
                    string isbn;
                    int index = item.LastIndexOf("[");
                    int index2 = item.LastIndexOf("]");
                    isbn = item.Substring(index + 1, index2 - index - 1);
                    Clipboard.SetText(isbn);
                }
            }
            //Clipboard.SetText("hey");
        }
    }
}
