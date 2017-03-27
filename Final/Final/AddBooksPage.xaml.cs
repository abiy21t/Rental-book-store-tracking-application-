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
    /// Interaction logic for AddBooksPage.xaml
    /// </summary>
    public partial class AddBooksPage : Window
    {
        public AddBooksPage()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)//resiter button
        {
            Book book = new Book();
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Edition = txtEdition.Text;
            book.Price = Convert.ToDouble(txtPrice.Text);
            book.ISBN = txtIsbn.Text.Replace("-","");
            book.CoverImage = txtCoverimage.Text;

            Boolean added = book.ADD_Book(book.Title, book.Author, book.Edition, book.Price, book.ISBN, book.CoverImage);
            if (added)
            {
                AdminHome ah = new AdminHome();
                ah.Show();
                this.Close();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)//back button
        {
            AdminHome ad = new AdminHome();
            ad.Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)//clear button
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            txtEdition.Text = "";
            txtPrice.Text = "";
            txtIsbn.Text = "";
            txtCoverimage.Text = "";
        }
    }
}
