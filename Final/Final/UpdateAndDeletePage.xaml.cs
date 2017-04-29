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
    /// Interaction logic for UpdateAndDeletePage.xaml
    /// </summary>
    public partial class UpdateAndDeletePage : Window
    {
        public UpdateAndDeletePage()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, RoutedEventArgs e)//search for isbn
        {
             Book se = new Book();
             Boolean okay = se.ISBN_Cheker(searchtxt.Text);//checks if valid isbn entry
            Boolean test2 = se.bookExists(searchtxt.Text);//checks if the book exists, used for editing current books with bad isbns
            if (okay || test2)
            {
                Book foundb = se.SearchBook(searchtxt.Text);
                SearchedValue(foundb.Title, foundb.Author, foundb.Edition, foundb.Price, foundb.ISBN, foundb.Stock.ToString());
            }
            else
            {
                MessageBox.Show("Invalid ISBN-10.");
            }
        }

         public void SearchedValue(string title, string author, string edition, double price, string isbn, string stock)//puts the book information into the textboxes
         {
             txtTitle.Text = title;
             txtAuthor.Text = author;
             txtEdition.Text = edition;
             txtPrice.Text = Convert.ToString(price);
             txtStock.Text = stock;
            if (isbn != null)//if old isbn cant be returned
            {
                txtIsbn.Text = isbn;
                label_isbnholder.Content = isbn;
            }
            else
            {
                txtIsbn.Text = "";
                label_isbnholder.Content = searchtxt.Text;
            }             
         }                  

        private void deletebook(object sender, RoutedEventArgs e)//deletes the book
        {
            Book se = new Book();
            if (txtTitle.Text != "" && txtAuthor.Text != "" && !label_isbnholder.Content.Equals(""))//makes sure a book has been searched
            {
                bool result = se.Delete_Book(searchtxt.Text);
                if (result == true)
                {
                    AdminHome ah = new AdminHome();
                    ah.Show();
                    this.Close();
                }
            }else
            {
                MessageBox.Show("Make sure this is the right book before deleting!\nDon't remove book information before deleting.");
            }
        }

        private void updatebook(object sender, RoutedEventArgs e)//updates the book with the entered data
        {
            Book se = new Book();
            int stock;
            Double price;
            Boolean okay = se.ISBN_Cheker(txtIsbn.Text);//check for valid isbn
            Boolean testPrice = Double.TryParse(txtPrice.Text, out price);//check for valid price
            Boolean testStock = Int32.TryParse(txtStock.Text, out stock);//check for valid stock
            if (!label_isbnholder.Content.Equals("") && okay && testPrice && testStock) {//makes sure data is valid and book has been searched
                if (txtTitle.Text != "" && txtAuthor.Text != "" && txtEdition.Text != "" && txtPrice.Text != "" && txtStock.Text != "") {
                    bool result = se.Update_Book(txtTitle.Text, txtAuthor.Text, txtEdition.Text, Convert.ToDouble(txtPrice.Text), label_isbnholder.Content.ToString(), Convert.ToInt32(txtStock.Text), txtIsbn.Text);
                    if (result == true)
                    {
                        AdminHome ah = new AdminHome();
                        ah.Show();
                        this.Close();
                    }
                }else//if fields are empty
                {
                    MessageBox.Show("Make sure all data inputs are filled in!");
                }
            }else if (!testPrice || !testStock)
            {
                if (!testPrice)//error in price entry
                {
                    MessageBox.Show("Invalid price entered. Do not include \"$\".");
                }
                else//error in stock entry
                {
                    MessageBox.Show("Invalid stock. Whole numbers only.");
                }
            }
            else
            {
                if (label_isbnholder.Content.Equals("") && txtAuthor.Text != "" && txtTitle.Text != "" && txtEdition.Text != "" && txtStock.Text != "")
                {
                    MessageBox.Show("Please enter a valid ISBN-10.");
                }
                else if (label_isbnholder.Content.Equals(""))//user hasnt searched for a book
                {
                    MessageBox.Show("You must have a book to update! Search for a book.");
                    
                }else if(!okay)//isbn is invalid
                {
                    MessageBox.Show("Invalid ISBN-10");
                }
            }
         }

        private void clear(object sender, RoutedEventArgs e)//clears textboxes
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtEdition.Text = "";
            txtPrice.Text = "";
            txtIsbn.Text = "";
            txtStock.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)//return user to admin homepage
        {
            AdminHome ah = new AdminHome();
            ah.Show();
            this.Close();
        }
    }
    }


