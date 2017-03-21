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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Book bok = new Book();
            bok.Title = txttitle.Text;
            bok.Author = txttitle.Text;
            bok.Edition = txtedition.Text;
            bok.Price = Convert.ToDouble(txtprice.Text);
            bok.ISBN = txtisbn.Text;
            bok.CoverImage = txtcoverimage.Text;

            bok.ADD_Book(bok.Title, bok.Author, bok.Edition, bok.Price, bok.ISBN, bok.CoverImage);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            AdminHome ad = new AdminHome();
            ad.Show();
            this.Hide();
        }
    }
}
