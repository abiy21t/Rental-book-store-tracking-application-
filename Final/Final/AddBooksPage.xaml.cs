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
            Book bok = new Book();
            bok.Title = txtTitle.Text;
            bok.Author = txtAuthor.Text;
            bok.Edition = txtEdition.Text;
            bok.Price = Convert.ToDouble(txtPrice.Text);
            bok.ISBN = txtIsbn.Text;
            bok.CoverImage = txtCoverimage.Text;

            bok.ADD_Book(bok.Title, bok.Author, bok.Edition, bok.Price, bok.ISBN, bok.CoverImage);
        }

        private void button2_Click(object sender, RoutedEventArgs e)//back button
        {
            AdminHome ad = new AdminHome();
            ad.Show();
            this.Hide();
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
