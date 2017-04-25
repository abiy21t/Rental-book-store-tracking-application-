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



        private void button5_Click(object sender, RoutedEventArgs e)
        {
             Book se = new Book();
             Book foundb = se.SearchBook(searchtxt.Text);

            SearchedValue(foundb.Title,foundb.Author,foundb.Edition,foundb.Price,foundb.ISBN,foundb.Stock.ToString());
            //this.SearchedValue(string title, string author, string edition, string price, string isbn)
        }

         public void SearchedValue(string title, string author, string edition, double price, string isbn, string stock)
         {
             txtTitle.Text = title;
             txtAuthor.Text = author;
             txtEdition.Text = edition;
             txtPrice.Text = Convert.ToString(price);
             txtIsbn.Text = isbn;
             txtStock.Text = stock;
         }
            

        

        private void deletebook(object sender, RoutedEventArgs e)
        {
            Book se = new Book();
           bool result= se.Delete_Book(searchtxt.Text);
            if (result==true)
            {
                AdminHome ah = new AdminHome();
                ah.Show();
                this.Close();
             }
        }

        private void updatebook(object sender, RoutedEventArgs e)
        {
            Book se = new Book();
            bool result = se.Update_Book(txtTitle.Text, txtAuthor.Text, txtEdition.Text, Convert.ToDouble(txtPrice.Text), txtIsbn.Text, Convert.ToInt32(txtStock.Text));
             if(result==true)
            {
                AdminHome ah = new AdminHome();
                ah.Show();
                this.Close();
            }
         }

        private void clear(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtEdition.Text = "";
            txtPrice.Text = "";
            txtIsbn.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ah = new AdminHome();
            ah.Show();
            this.Close();
        }
    }
    }


