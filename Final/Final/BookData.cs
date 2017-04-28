using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Web;
//using System.Web.Extensions.dll;
//using System.Web.Script.Serialization;

namespace Final
{
    class BookData
    {
        public DatabaseConnection conn = new DatabaseConnection();
        public List<string> list_books(int num)//returns list of all the books that are in stock and not in cart
        {
            List<string> books = new List<string>();           
            string title, author, edition, price,isbn,value;
            if(num == 0)
            {
                value = " = 0 ";
            }else
            {
                value = " > 0 ";
            }

            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand cmd = new SqlCommand(String.Format("SELECT * FROM Books WHERE Stock{0} and InCart = 0",value), connection);
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
                    //con.con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            return books;

        }

        public Book Search_Book(string ISBN)//searches for books by isbn returns book class
        {
            //DatabaseConnection dc = new DatabaseConnection();
            ISBN = ISBN.Replace("-", "");
            //string title, author, edition, isbn;
            double price;
            int inCart, stock;
            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("SELECT * from Books where ISBN ='" + ISBN + "' ", connection);
                    DataTable dt = new DataTable();
                    SqlDataReader rd = ad.ExecuteReader();
                    dt.Load(rd);
                    connection.Close();
                    if (dt.Rows.Count == 1)
                    {
                        Book book = new Book();
                        book.Title = dt.Rows[0]["Title"].ToString();
                        book.Author = dt.Rows[0]["Author"].ToString();
                        book.Edition = dt.Rows[0]["Edition"].ToString();
                        double.TryParse(dt.Rows[0]["Price"].ToString(), out price);
                        book.Price = price;
                        book.ISBN = dt.Rows[0]["ISBN"].ToString();
                        int.TryParse(dt.Rows[0]["InCart"].ToString(), out inCart);
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
                using (var connection = conn.con)
                {
                    //DatabaseConnection conn = new DatabaseConnection();
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

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Book Registered");
                    okay = true;

                }
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
            //DatabaseConnection con = new DatabaseConnection();

            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Books WHERE InCart = 1", connection); //Title, Author, Price, ISBN
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
                    connection.Close();
                }
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
            //DatabaseConnection dc = new DatabaseConnection();
            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand(String.Format("Update Books SET InCart = {0} where ISBN ='" + isbn + "'", num.ToString()), connection);
                    ad.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }
        }

        public string Search_Book2(string ISBN)//searches books by ISBN returns string
        {
            //DatabaseConnection dc = new DatabaseConnection();
            ISBN = ISBN.Replace("-", "");
            string title, author, edition, isbn,book, price;

            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("SELECT * from Books where ISBN ='" + ISBN + "' ", connection);
                    DataTable dt = new DataTable();
                    SqlDataReader rd = ad.ExecuteReader();
                    dt.Load(rd);
                    //connection.Close();
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
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }

        }


        public List<string> Search_Title(string query)//searchs books and returns books containing search phrase query
        {
            //DatabaseConnection dc = new DatabaseConnection();
            string title, author, edition, isbn, price;
            List<string> books = new List<string>();
            int total = 0;

            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("SELECT * from Books where Stock > 0", connection);
                    DataTable dt = new DataTable();
                    SqlDataReader rd = ad.ExecuteReader();
                    dt.Load(rd);
                    //dc.con.Close();

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
                    //dc.con.Close();
                    if (total == 0)
                    {
                        MessageBox.Show("No results found.");
                    }
                    return books;
                }
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }

        }

        public void ClearCart()//removes all books from cart (InCart = 0/False)
        {
            //DatabaseConnection dc = new DatabaseConnection();
            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("Update Books SET InCart = 0", connection);
                    ad.ExecuteNonQuery();
                    //dc.con.Close();
                }
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }
        }

        public List<string> Search_Author(string query)//searchs books and returns books containing search phrase query
        {
            //DatabaseConnection dc = new DatabaseConnection();
            string title, author, edition, isbn, price;
            List<string> books = new List<string>();
            int total = 0;

            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("SELECT * from Books where Stock > 0", connection);
                    DataTable dt = new DataTable();
                    SqlDataReader rd = ad.ExecuteReader();
                    dt.Load(rd);
                    //dc.con.Close();

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
                    if (total == 0)
                    {
                        MessageBox.Show("No results found.");
                    }
                    return books;
                }
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }

        }

        public List<string> CreateReport()
        {
            List<String> items = new List<string>();
            //books in stock
            items.Add("Books in stock:\n");
            items.AddRange(list_books(1));
            //books out of stock
            items.Add("\nBooks out of stock:\n");
            if (list_books(0).Any())
            {
                items.AddRange(list_books(0));
            }else
            {
                items.Add("\tAll books in stock!");
            }
            //overdue books
            items.Add("\nOverdue rentals:\n");
            if (ShowLate().Any())
            {
                items.AddRange(ShowLate());
            }
            else
            {
                items.Add("\tNo overdue rentals!");
            }
            //return report
            return items;
        }

        public OLBook AccessOpenLibrary(string isbn)//this will take a given isbn number and check it against open library
        {
            OLBook book = new OLBook();
            WebClient wc = new WebClient();
            string path = string.Format(@"https://openlibrary.org/api/books?bibkeys=ISBN:{0}&jscmd=details&format=json", isbn);
            //connect to api
            string data = wc.DownloadString(path);
            if (data == "{}")
            {
                MessageBox.Show("No results found on OpenLibrary.");
            }else
            {
                return convertToOLBook(data, isbn);
            }
            return book;
        }

        public OLBook convertToOLBook(string data, string isbn)//this takes the json and makes an OLBook object
        {
            JObject rawbook = JObject.Parse(data);
            List<JToken> tokens = rawbook[string.Format("ISBN:{0}", isbn)].Children().ToList();
            OLBook book = new OLBook();
            int index = 0;
            foreach (var token in tokens)
            {
                if (token.ToString().Contains("\"details\""))// index == 4)
               {
                    List<JToken> t = token.Children().ToList(); 
                    book = t.First().ToObject<OLBook>();
                    return book;
                }
                index += 1;
            }
            return book;
        }

        public Boolean addRent(string fname, string lname, string isbns, Double price, string email, DateTime today)//this adds rental details to the database after checkout
        {
            Boolean okay = false;
            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                using (var connection = conn.con)
                {
                    connection.Open();

                    //,'" + @coverimage + "'
                    SqlCommand cmd = new SqlCommand("INSERT into Rented (FirstName,LastName,BookISBNs,AmountPaid,Email,RentalDate,ReturnDate) values('" + @fname + "','" + @lname + "','" + @isbns +"','" + @price + "','" + @email + "','" + today +"','" + today.AddMonths(6) + "')", connection);

                    cmd.Parameters.AddWithValue("@fname", fname);

                    cmd.Parameters.AddWithValue("@lname", lname);

                    cmd.Parameters.AddWithValue("@isbns", isbns);

                    cmd.Parameters.AddWithValue("@price", price);

                    cmd.Parameters.AddWithValue("@email", email);

                    cmd.ExecuteNonQuery();
                    conn.con.Close();
                    MessageBox.Show("Rental Registered");
                    okay = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
                return okay;
            }
            return okay;
        }

        public void RentBook(string isbn)//this updates the book database when books are rented
        {
            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("Update Books SET InCart = 0, Stock = Stock-1  where ISBN ='" + isbn + "'", connection);
                    ad.Parameters.AddWithValue("@isbn", isbn);
                    ad.ExecuteNonQuery();

                }
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }
        }

        private List<string> ShowLate()//this returns a list of rentals that are past due
        {
            List<string> renters = new List<string>();
            string fname, lname, email, isbns, date;
            DateTime today = DateTime.Today;

            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("SELECT * from Rented where ReturnDate <= '" + today +"'", connection);// + today
                    DataTable dt = new DataTable();
                    SqlDataReader rd = ad.ExecuteReader();
                    dt.Load(rd);
                    //dc.con.Close();

                    for (int a = 0; a < dt.Rows.Count; a++)
                    {
                        fname = dt.Rows[a]["FirstName"].ToString();
                        lname = dt.Rows[a]["LastName"].ToString();
                        email = dt.Rows[a]["Email"].ToString();
                        isbns = dt.Rows[a]["BookISBNs"].ToString();
                        date = dt.Rows[a]["ReturnDate"].ToString();                       
                        renters.Add(lname + ", " + fname + ", " + email +", Books: "+ isbns + "; Due: "+date);
                    }

                    return renters;
                }
            }
            catch (Exception x)
            {
                throw new Exception("Error connecting to database. \n" + x);
            }
        }
    }
}
