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
    /// Interaction logic for Checkout.xaml
    /// </summary>
    public partial class Checkout : Window
    {
        public Checkout()
        {
            InitializeComponent();
            numBooks();
            totalPrice();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//cancel checkout
        {
            cancelbox.Visibility = Visibility.Visible;
            button_no.Visibility = Visibility.Visible;
            button_yes.Visibility = Visibility.Visible;
            label_cancelWarning.Visibility = Visibility.Visible;
        }

        private void button_no_Click(object sender, RoutedEventArgs e)//do not cancel
        {
            cancelbox.Visibility = Visibility.Collapsed;
            button_no.Visibility = Visibility.Collapsed;
            button_yes.Visibility = Visibility.Collapsed;
            label_cancelWarning.Visibility = Visibility.Collapsed;
        }

        private void numBooks()//calculates the total number of books in the cart
        {
            label_numberOfBooks.Content = listBox.Items.Count.ToString();
        }

        private void totalPrice()//calculates the price for all items in the cart
        {
            listBox.Items.Add("Title,Author, $420.00");//test example

            double price = 0;
            double total = 0;
            bool okay = false;
            foreach(var book in listBox.Items)
            {
                string line = book.ToString();
                int index = line.LastIndexOf("$");
                line = line.Substring(index + 1);
                okay = Double.TryParse(line, out price);
                if (okay)
                {
                    total += price;
                    price = 0;
                }
                else
                {
                    MessageBox.Show("Error with list display. Make sure price is the last item.");
                }
            }
            total = Math.Round(total, 2);
            label_totalCost.Content = "$ " + total.ToString();   
        }

        private void button_yes_Click(object sender, RoutedEventArgs e)//yes cancel
        {
            //remove all items from cart

            ClerkHome ch = new ClerkHome();
            ch.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)//remove selected item
        {
                listBox.Items.Remove(listBox.SelectedItems[0]);
        }

        private void button_add_Click(object sender, RoutedEventArgs e)//add another button returns to clerk page again
        {
            //returns you without emptying cart
            ClerkHome ch = new ClerkHome();
            ch.Show();
            this.Close();
        }
    }
}
