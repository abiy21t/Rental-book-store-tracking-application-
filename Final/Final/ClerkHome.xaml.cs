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
    /// Interaction logic for ClerkHome.xaml
    /// </summary>
    public partial class ClerkHome : Window
    {
        //public Cart cart = new Cart();

        public ClerkHome()
        {
            InitializeComponent();
            
        }

        private void logout_button_Click(object sender, RoutedEventArgs e)//logout
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//search ISBN
        {
            label_isbn.Visibility = Visibility.Visible;
            textBox_search.Visibility = Visibility.Visible;
            searchbox.Visibility = Visibility.Visible;
            button_cancel.Visibility = Visibility.Visible;
            button_isbn_search.Visibility = Visibility.Visible;
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)//display books button
        {
            BookData bd = new BookData();            
            string[] books = bd.list_books().ToArray();

            foreach (var book in books)
            {
                listBox.Items.Add(book);
            }

        }

        private void button1_Click_2(object sender, RoutedEventArgs e)//clear list
        {
            listBox.Items.Clear();
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)//search cancel
        {
            label_isbn.Visibility = Visibility.Collapsed;
            textBox_search.Visibility = Visibility.Collapsed;
            searchbox.Visibility = Visibility.Collapsed;
            button_cancel.Visibility = Visibility.Collapsed;
            button_isbn_search.Visibility = Visibility.Collapsed;
        }

        private void button_checkout_Click(object sender, RoutedEventArgs e)//proceed to checkout
        {
            Checkout co = new Checkout();
            co.Show();
            this.Close();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)//add to cart
        {
            //removes from listbox and adds to cart
            string book = listBox.SelectedItems[0].ToString();
            //cart.books.add(book);
            listBox.Items.Remove(listBox.SelectedItems[0]);
        }
    }
}
