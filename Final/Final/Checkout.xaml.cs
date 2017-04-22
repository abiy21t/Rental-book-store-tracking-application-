﻿using System;
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
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Window
    {
        
        public Checkout()
        {
            InitializeComponent();
            fillListBox();
            checkoutTotals();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//cancel checkout
        {
            cancelbox.Visibility = Visibility.Visible;
            button_no.Visibility = Visibility.Visible;
            button_yes.Visibility = Visibility.Visible;
            label_cancelWarning.Visibility = Visibility.Visible;
        }

        private void button_no_Click(object sender, RoutedEventArgs e)//do not cancel checkout
        {
            cancelbox.Visibility = Visibility.Collapsed;
            button_no.Visibility = Visibility.Collapsed;
            button_yes.Visibility = Visibility.Collapsed;
            label_cancelWarning.Visibility = Visibility.Collapsed;
        }

        private void button_yes_Click(object sender, RoutedEventArgs e)//yes cancel
        {
            //remove all items from cart
            BookData bd = new BookData();
            bd.ClearCart();
            listBox.Items.Clear();
            //send user back to clerk homepage
            ClerkHome ch = new ClerkHome();
            ch.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)//remove selected item
        {
            if (listBox.SelectedItems.Count > 0)
            {
                //get selected item
                string book = listBox.SelectedItems[0].ToString();
                listBox.Items.Remove(listBox.SelectedItems[0]);//removes item from listbox display
                BookData bd = new BookData();
                bd.updateCart(book, 0);//changes specific book's "InCart" status to false/0
                //recalculate checkout totals
                checkoutTotals();
            }
            else
            {
                MessageBox.Show("You must first choose a book to remove.");
            }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)//add another button returns to clerk page again
        {
            //returns user to clerkhomepage without emptying the cart
            ClerkHome ch = new ClerkHome();
            ch.Show();
            this.Close();
        }
        private void fillListBox()//fills the listbox with books that are "InCart"
        {
            //get books that are in cart
            BookData bd = new BookData();
            List<string> books = new List<string>();
            books = bd.list_books_incart();
            //put books into listbox
            foreach (var book in books)
            {
                ListBoxItem tb = new ListBoxItem();
                tb.Width = 440;
                tb.Content = new TextBlock { Text = book, TextWrapping = TextWrapping.Wrap };//+ "\n"
                listBox.Items.Add(tb);
            }
        }

        private void checkoutTotals()
        {
            //calculate number of books for current order
            label_numberOfBooks.Content = listBox.Items.Count.ToString();
            //calculate total price for books in cart
            Cart cart = new Cart();
            double price;
            price = cart.calcPrice(listBox);
            label_totalCost.Content = "$ " + price.ToString();
        }

        private void rect_cancel_btn_Click(object sender, RoutedEventArgs e)//cancel purchase
        {
            rect.Visibility = Visibility.Collapsed;
            rect_cancel_btn.Visibility = Visibility.Collapsed;
            rect_confirm_btn.Visibility = Visibility.Collapsed;
            rect_fname.Visibility = Visibility.Collapsed;
            rect_fname_textBox.Visibility = Visibility.Collapsed;
            rect_lname.Visibility = Visibility.Collapsed;
            rect_lname_textBox.Visibility = Visibility.Collapsed;
            rect_email.Visibility = Visibility.Collapsed;
            rect_email_textBox.Visibility = Visibility.Collapsed;
            rect_label.Visibility = Visibility.Collapsed;

        }

        private void button_confirm_Click(object sender, RoutedEventArgs e)//checkout button
        {
            rect.Visibility = Visibility.Visible;
            rect_cancel_btn.Visibility = Visibility.Visible;
            rect_confirm_btn.Visibility = Visibility.Visible;
            rect_fname.Visibility = Visibility.Visible;
            rect_fname_textBox.Visibility = Visibility.Visible;
            rect_lname.Visibility = Visibility.Visible;
            rect_lname_textBox.Visibility = Visibility.Visible;
            rect_email.Visibility = Visibility.Visible;
            rect_email_textBox.Visibility = Visibility.Visible;
            rect_label.Visibility = Visibility.Visible;
        }

        private void rect_confirm_btn_Click(object sender, RoutedEventArgs e)//process order
        {
            BookData bd = new BookData();
            List<string> isbns = listISBNs();
            foreach(var item in isbns)
            {
                bd.RentBook(item);
            }
            //MessageBox.Show(listISBNs().toArray().ToString());
            //listISBNs().ToArray<string>.ToString();
           // BookData bd = new BookData();
            //Boolean dbupdated = true;
            //Boolean processed = bd.addRent(rect_fname_textBox.Text, rect_lname_textBox.Text, label_numberOfBooks.Content + " Books, ISBNs: " + listISBNs().ToString(), Convert.ToDouble(label_totalCost.Content),rect_email_textBox.Text);
            //if (processed && dbupdated)
            //{
                //MessageBox.Show("Order has been processed. Books rented = " + label_numberOfBooks.Content + " for a total price: " + label_totalCost.Content);
           // }
        }

        private List<string> listISBNs()//returns a list of all the isbns of the books in cart
        {
            List<string> isbns = new List<string>();
            foreach (var book in listBox.Items)
            {
                string isbn;
                string book2 = book.ToString();
                int index = book2.LastIndexOf("[");
                int index2 = book2.LastIndexOf("]");
                isbn = book2.Substring(index + 1, index2 - index - 1);// + "; ";
                isbns.Add(isbn);
            }
            return isbns;
        }
    }
}
