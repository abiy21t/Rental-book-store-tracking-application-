using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public ClerkHome()
        {
            InitializeComponent();
            
        }

        private void logout_button_Click(object sender, RoutedEventArgs e)//logout
        {
            BookData bd = new BookData();
            bd.ClearCart();
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//show search ISBN
        {
            showSearch("Enter an ISBN - 10 Number:");

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)//display books button
        {
            //get books from database
            BookData bd = new BookData();            
            string[] books = bd.list_books().ToArray();
            //display books in listbox
            foreach (var book in books)
            {
                ListBoxItem tb = new ListBoxItem();
                tb.Width = 310;
                tb.Content = new TextBlock { Text = book, TextWrapping = TextWrapping.Wrap };
                listBox.Items.Add(tb); 
            }
        }

        private void button1_Click_2(object sender, RoutedEventArgs e)//clear list
        {
            listBox.Items.Clear();
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)//search cancel
        {
            hideSearch();
        }

        private void button_checkout_Click(object sender, RoutedEventArgs e)//proceed to checkout
        {
            Checkout co = new Checkout();
            co.Show();
            this.Close();
        }

        private void button_add_Click(object sender, RoutedEventArgs e)//add book to cart
        {
            //removes from listbox and adds to cart
            if (listBox.SelectedItems.Count > 0)
            {
                string book = listBox.SelectedItems[0].ToString();
                listBox.Items.Remove(listBox.SelectedItems[0]);
                BookData bd = new BookData();
                bd.updateCart(book, 1); //updates InCart status to true/1
            }else
            {
                MessageBox.Show("You must first select a book to add.");
            }           
        }

        private void button_isbn_search_Click(object sender, RoutedEventArgs e)//search for book
        {
            BookData bd = new BookData();
            if (label_isbn.Content.ToString().Contains("ISBN"))//search by isbn
            {
                string[] books = new string[1];
                books[0] = bd.Search_Book2(textBox_search.Text);
                if (books[0] != "")
                {
                    FillListbox(books);
                }
            }
            else if (label_isbn.Content.ToString().Contains("title"))//search by title
            {
                string[] books = bd.Search_Title(textBox_search.Text).ToArray();
                FillListbox(books);
            }else if (label_isbn.Content.ToString().Contains("Author"))
            {
                string[] books = bd.Search_Author(textBox_search.Text).ToArray();
                FillListbox(books);
            }                       
        }

        private void hideSearch()//hides the search display
        {
            label_isbn.Visibility = Visibility.Collapsed;
            textBox_search.Visibility = Visibility.Collapsed;
            searchbox.Visibility = Visibility.Collapsed;
            button_cancel.Visibility = Visibility.Collapsed;
            button_isbn_search.Visibility = Visibility.Collapsed;
        }

        private void button2_Click(object sender, RoutedEventArgs e)//search by title
        {
            showSearch("Enter a book title:");           
        }
        private void showSearch(string type)//shows the search display and changes title of search
        {
            label_isbn.Visibility = Visibility.Visible;
            textBox_search.Visibility = Visibility.Visible;
            searchbox.Visibility = Visibility.Visible;
            button_cancel.Visibility = Visibility.Visible;
            button_isbn_search.Visibility = Visibility.Visible;
            label_isbn.Content = type;
        }

        private void button_author_Click(object sender, RoutedEventArgs e)
        {
            showSearch("Enter an Author name:");

        }

        private void FillListbox(string[] books)
        {
            listBox.Items.Clear();
            hideSearch();
            foreach (var book in books)
            {
                ListBoxItem tb = new ListBoxItem();
                tb.Width = 310;
                tb.Content = new TextBlock { Text = book, TextWrapping = TextWrapping.Wrap };
                listBox.Items.Add(tb);
            }
        }
    }
}
