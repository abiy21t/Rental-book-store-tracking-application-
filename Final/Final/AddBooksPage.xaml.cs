using System;
using System.Collections.Generic;
using System.IO;
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
        //public byte[] data;
        public AddBooksPage()
        {
            InitializeComponent();
        }
        private void button_Click_1(object sender, RoutedEventArgs e) //placeholder?
        {
           /* Microsoft.Win32.OpenFileDialog dlg =
new Microsoft.Win32.OpenFileDialog();
            dlg.ShowDialog();

            FileStream fs = new FileStream(dlg.FileName, FileMode.Open,
FileAccess.Read);

            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

            fs.Close();
            ImageSourceConverter imgs = new ImageSourceConverter();
            imagebox.SetValue(Image.SourceProperty, imgs.
            ConvertFromString(dlg.FileName.ToString()));*/
        }
        private void button_Click(object sender, RoutedEventArgs e)//register button
        {
            if(txtTitle.Text != "" && txtAuthor.Text != "" && txtPrice.Text != "")
            {
                Book book = new Book();
                book.Title = txtTitle.Text;
                book.Author = txtAuthor.Text;
                if(txtEdition.Text == "")
                {
                    book.Edition = "1st";
                }else
                {
                    book.Edition = txtEdition.Text.Replace("edition", "").Replace("Edition", "").Replace("ed.", "");
                }               
                book.Price = Convert.ToDouble(txtPrice.Text);
                book.ISBN = txtIsbn.Text;
                Boolean added = book.ADD_Book(book.Title, book.Author, book.Edition, book.Price, book.ISBN, 0, 1);
                if (added)
                {
                    AdminHome ah = new AdminHome();
                    ah.Show();
                    this.Close();
                }
            }else
            {
                MessageBox.Show("Invalid input.");
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
          //  txtCoverimage.Text = "";
        }

        private void button_Click_2(object sender, RoutedEventArgs e)//add from open library
        {
            string isbn = txtIsbn.Text.Replace("-","");
            Book b = new Book();
            //if (isbn)
            Boolean okay = b.ISBN_Cheker(isbn);
            if (okay)
            {
                BookData bd = new BookData();
                OLBook book = bd.AccessOpenLibrary(isbn);
                if(book.title != null)
                {
                    txtTitle.Text = book.title;
                    txtAuthor.Text = book.authors[0].name;
                    txtEdition.Text = book.edition_name.Replace("edition", "").Replace("Edition", "").Replace("ed.","");
                }
                
            }else
            {
                MessageBox.Show("Invalid ISBN-10. Try again.");
            }
            
        }
    }
}
