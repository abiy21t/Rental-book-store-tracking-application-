using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;

namespace Final
{
    class BookData
    {

        public List<string> list_books()//returns list of all the books that are in stock and not in cart
        {
            List<string> books = new List<string>();           
            string title, author, edition, price,isbn;
            DatabaseConnection con = new DatabaseConnection();

            try
            {
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE Stock > 0 and InCart = 0", con.con);
                DataTable dt = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    title = dt.Rows[a]["Title"].ToString();
                    author = dt.Rows[a]["Author"].ToString();
                    edition = dt.Rows[a]["Edition"].ToString();
                    price = dt.Rows[a]["Price"].ToString();
                    isbn = dt.Rows[a]["ISBN"].ToString();
                    books.Add(title + " " + edition + " edition, by " + author + " for $" + price + " -ISBN[" + isbn + "]");
                }
                con.con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            return books;

        }

        public Book Search_Book(string ISBN)//searches for books by isbn returns book class
        {
            DatabaseConnection dc = new DatabaseConnection();
            ISBN = ISBN.Replace("-", "");
            //string title, author, edition, isbn;
            double price;
            int inCart, stock;
            try
            {

                if (ConnectionState.Closed == dc.con.State)
                {
                    dc.con.Open();
                }
                SqlCommand ad = new SqlCommand("SELECT * from Books where ISBN ='" + ISBN + "' ", dc.con);
                DataTable dt = new DataTable();
                SqlDataReader rd = ad.ExecuteReader();
                dt.Load(rd);
                dc.con.Close();
                if (dt.Rows.Count == 1)
                {
                    Book book = new Book();
                    book.Title = dt.Rows[0]["Title"].ToString();
                    book.Author = dt.Rows[0]["Author"].ToString();
                    book.Edition = dt.Rows[0]["Edition"].ToString();
                    double.TryParse(dt.Rows[0]["Price"].ToString(),out price);
                    book.Price = price;
                    book.ISBN = dt.Rows[0]["ISBN"].ToString();
                    int.TryParse(dt.Rows[0]["InCart"].ToString(),out inCart);
                    int.TryParse(dt.Rows[0]["Stock"].ToString(), out stock);
                    book.InCart = inCart;
                    book.Stock = stock;
                    return book;
                }
                else
                {
                    Book b = new Book();
                    MessageBox.Show("No results found.");
                    return b;
                }
               
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }
            
        }

        public Boolean ADD_Book(string title, string author, string edition, double price, string isbn, int inCart, int stock)//adds book to database
        {
            Boolean okay = false;
            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                //,'" + @coverimage + "'
                SqlCommand cmd = new SqlCommand("insert into Books (Title,Author,Edition,Price,ISBN,InCart,Stock) values('" + @title + "','" + @author + "',@edition,'" + @price + "','" + @isbn + "','" + inCart + "','" + @stock + "')", conn.con);

                cmd.Parameters.AddWithValue("@title", title);

                cmd.Parameters.AddWithValue("@author", author);

                cmd.Parameters.AddWithValue("@edition", edition);

                cmd.Parameters.AddWithValue("@price", price);

                cmd.Parameters.AddWithValue("@isbn", isbn);
                cmd.Parameters.AddWithValue("@inCart", inCart);
                cmd.Parameters.AddWithValue("@stock", stock);

                // cmd.Parameters.AddWithValue("@covrimage", coverimage);

                conn.con.Open();
                cmd.ExecuteNonQuery();
                conn.con.Close();
                MessageBox.Show("Book Registered");
                okay = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            return okay;
        }

        public List<string> list_books_incart()//returns a list of all the books that are inCart
        {
            List<string> books = new List<string>();
            string title, author, edition, price, isbn;
            DatabaseConnection con = new DatabaseConnection();

            try
            {
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE InCart = 1", con.con); //Title, Author, Price, ISBN
                DataTable dt = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    title = dt.Rows[a]["Title"].ToString();
                    author = dt.Rows[a]["Author"].ToString();
                    edition = dt.Rows[a]["Edition"].ToString();
                    price = dt.Rows[a]["Price"].ToString();
                    isbn = dt.Rows[a]["ISBN"].ToString();
                    books.Add(title + " " + edition + " edition, by " + author + " for $" + price + " -ISBN[" + isbn + "]");
                }
                con.con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            return books;

        }

        public void updateCart(string book, int num)//if num = 0 remove from cart, 1 = add to cart
        {
            string isbn;

            int index = book.LastIndexOf("[");
            int index2 = book.LastIndexOf("]");
            isbn = book.Substring(index + 1, index2 - index - 1);
            DatabaseConnection dc = new DatabaseConnection();
            try
            {

                if (ConnectionState.Closed == dc.con.State)
                {
                    dc.con.Open();
                }
                SqlCommand ad = new SqlCommand(String.Format("Update Books SET InCart = {0} where ISBN ='" + isbn + "'", num.ToString()), dc.con);
                ad.ExecuteNonQuery();
                dc.con.Close();
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }
        }

        public string Search_Book2(string ISBN)//searches books by ISBN returns string
        {
            DatabaseConnection dc = new DatabaseConnection();
            ISBN = ISBN.Replace("-", "");
            string title, author, edition, isbn,book, price;

            try
            {

                if (ConnectionState.Closed == dc.con.State)
                {
                    dc.con.Open();
                }
                SqlCommand ad = new SqlCommand("SELECT * from Books where ISBN ='" + ISBN + "' ", dc.con);
                DataTable dt = new DataTable();
                SqlDataReader rd = ad.ExecuteReader();
                dt.Load(rd);
                dc.con.Close();
                if (dt.Rows.Count > 0)
                {
                    title = dt.Rows[0]["Title"].ToString();
                    author = dt.Rows[0]["Author"].ToString();
                    edition = dt.Rows[0]["Edition"].ToString();
                    price = dt.Rows[0]["Price"].ToString();
                    isbn = dt.Rows[0]["ISBN"].ToString();
                    book = title + " " + edition + " edition, by " + author + " for $" + price + " -ISBN[" + isbn + "]";
                    return book;
                }
                else
                {
                    //Book b = new Book();
                    MessageBox.Show("No results found.");
                    return "";
                }

            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }

        }


        public List<string> Search_Title(string query)//searchs books and returns books containing search phrase query
        {
            DatabaseConnection dc = new DatabaseConnection();
            string title, author, edition, isbn, price;
            List<string> books = new List<string>();
            int total = 0;

            try
            {

                if (ConnectionState.Closed == dc.con.State)
                {
                    dc.con.Open();
                }
                SqlCommand ad = new SqlCommand("SELECT * from Books where Stock > 0", dc.con);
                DataTable dt = new DataTable();
                SqlDataReader rd = ad.ExecuteReader();
                dt.Load(rd);
                dc.con.Close();

                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    
                    title = dt.Rows[a]["Title"].ToString();
                    if (title.ToUpper().Contains(query.ToUpper()))
                    {
                        total += 1;
                        author = dt.Rows[a]["Author"].ToString();
                        edition = dt.Rows[a]["Edition"].ToString();
                        price = dt.Rows[a]["Price"].ToString();
                        isbn = dt.Rows[a]["ISBN"].ToString();
                        books.Add(title + " " + edition + " edition, by " + author + " for $" + price + " -ISBN[" + isbn + "]");
                    }
                    
                }
                dc.con.Close();
                if (total == 0)
                {
                    MessageBox.Show("No results found.");
                }
                return books;
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }

        }

        public void ClearCart()//removes all books from cart (InCart = 0/False)
        {
            DatabaseConnection dc = new DatabaseConnection();
            try
            {

                if (ConnectionState.Closed == dc.con.State)
                {
                    dc.con.Open();
                }
                SqlCommand ad = new SqlCommand("Update Books SET InCart = 0", dc.con);
                ad.ExecuteNonQuery();
                dc.con.Close();
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }
        }

        public List<string> Search_Author(string query)//searchs books and returns books containing search phrase query
        {
            DatabaseConnection dc = new DatabaseConnection();
            string title, author, edition, isbn, price;
            List<string> books = new List<string>();
            int total = 0;

            try
            {

                if (ConnectionState.Closed == dc.con.State)
                {
                    dc.con.Open();
                }
                SqlCommand ad = new SqlCommand("SELECT * from Books where Stock > 0", dc.con);
                DataTable dt = new DataTable();
                SqlDataReader rd = ad.ExecuteReader();
                dt.Load(rd);
                dc.con.Close();

                for (int a = 0; a < dt.Rows.Count; a++)
                {

                    author = dt.Rows[a]["Author"].ToString();
                    if (author.ToUpper().Contains(query.ToUpper()))
                    {
                        total += 1;
                        title = dt.Rows[a]["Title"].ToString();
                        edition = dt.Rows[a]["Edition"].ToString();
                        price = dt.Rows[a]["Price"].ToString();
                        isbn = dt.Rows[a]["ISBN"].ToString();
                        books.Add(title + " " + edition + " edition, by " + author + " for $" + price + " -ISBN[" + isbn + "]");
                    }

                }
                dc.con.Close();
                if (total == 0)
                {
                    MessageBox.Show("No results found.");
                }
                return books;
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }

        }

        public void CreateReport()
        {
            //write books to csv file
            //connect to database

            //books in stock

            //books out of stock

            //rented books

            //overdue books


            //show/open report
        }

        public Book AccessOpenLibrary(string isbn)
        {
            Book book = new Book();
            //connect to api

            //read in json

            //convert to book


            return book;
        }
    }
}
