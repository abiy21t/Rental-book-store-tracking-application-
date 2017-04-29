using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
//        private void button_Click_1(object sender, RoutedEventArgs e) //placeholder?
//        {
//           /* Microsoft.Win32.OpenFileDialog dlg =
//new Microsoft.Win32.OpenFileDialog();
//            dlg.ShowDialog();

//            FileStream fs = new FileStream(dlg.FileName, FileMode.Open,
//FileAccess.Read);

//            byte[] data = new byte[fs.Length];
//            fs.Read(data, 0, System.Convert.ToInt32(fs.Length));

//            fs.Close();
//            ImageSourceConverter imgs = new ImageSourceConverter();
//            imagebox.SetValue(Image.SourceProperty, imgs.
//            ConvertFromString(dlg.FileName.ToString()));*/
//        }
        private void button_Click(object sender, RoutedEventArgs e)//register button
        {
            Book book = new Book();
            int stock;
            Double price;
            Boolean okay = book.ISBN_Cheker(txtIsbn.Text);//check isbn is valid
            Boolean testPrice = Double.TryParse(txtPrice.Text, out price);//check price is valid
            Boolean testStock = Int32.TryParse(txtStock.Text, out stock);//check stock is a valid number
            if (txtTitle.Text != "" && txtAuthor.Text != "" && txtPrice.Text != "" && txtStock.Text != "" && txtIsbn.Text != "")//make sure no fields are empty
            {
                string title, author;
                title = Regex.Replace(txtTitle.Text, @"[^\w\d\s]+", "");//remove any special characters 
                author = Regex.Replace(txtAuthor.Text, @"[^\w\d\s]+", "");
                if (okay && testPrice && testStock)//if everything is valid
                    {
                        book.Title = title;
                        book.Author = author;
                        if (txtEdition.Text == "")//if no edition is entered it will be considered 1st edition
                        {
                            book.Edition = "1st";
                        }
                        else
                        {
                            book.Edition = txtEdition.Text.Replace("edition", "").Replace("Edition", "").Replace("ed.", "");//removes edition
                        }
                        book.Price = Convert.ToDouble(txtPrice.Text);
                        book.ISBN = txtIsbn.Text;
                        Boolean added = book.ADD_Book(book.Title, book.Author, book.Edition, book.Price, book.ISBN, 0, stock);//adds book to database
                        if (added)//if add is successfull
                        {
                            AdminHome ah = new AdminHome();
                            ah.Show();
                            this.Close();
                        }
                    }
                    else if (!testPrice)//if price is invalid
                    {
                        MessageBox.Show("Invalid Price. Do not include \"$\".");
                    }
                    else if (!testStock)//if stock entry is invalid
                    {
                        MessageBox.Show("Invalid stock. Whole Numbers only!");
                    }
                }else//if fields are empty
                {
                    MessageBox.Show("Make sure all fields are filled.");
                }
        }

        private void button2_Click(object sender, RoutedEventArgs e)//back button -- return to admin homepage
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
            txtStock.Text = "";
          //  txtCoverimage.Text = "";
        }

        private void button_Click_2(object sender, RoutedEventArgs e)//add from open library
        {
            string isbn = txtIsbn.Text.Replace("-","");
            Book b = new Book();
            Boolean okay = b.ISBN_Cheker(isbn);//check isbn is valid
            if (okay)
            {
                BookData bd = new BookData();
                OLBook book = bd.AccessOpenLibrary(isbn);
                if(book.title != null)//if a book was found
                {
                    txtTitle.Text = book.title;
                    txtAuthor.Text = book.authors[0].name;
                    if(book.edition_name != null)//if edition was included in json
                    {
                        txtEdition.Text = book.edition_name.Replace("edition", "").Replace("Edition", "").Replace("ed.", "");
                    }                    
                }
                
            }else
            {
                MessageBox.Show("Invalid ISBN-10. Try again.");
            }
            
        }
    }
}
