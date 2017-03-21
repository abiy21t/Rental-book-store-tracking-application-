using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Final
{
    class Book
    {
        private string _Title;
        private string _Author;
        private string _Edition;
        private double _Price;
        private string _ISBN;
        private string _CoverImage;

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {

                _Title = value;
            }
        }

        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {

                _Author = value;
            }
        }
        public string Edition
        {
            get
            {
                return _Edition;
            }
            set
            {

                _Edition = value;
            }
        }
        public double Price
        {
            get
            {
                return _Price;
            }
            set
            {

                _Price = value;
            }
        }

        public string ISBN
        {
            get
            {
                return _ISBN;
            }
            set
            {

                _ISBN = value;
            }
        }
        public string CoverImage
        {
            get
            {
                return _CoverImage;
            }
            set
            {

                _CoverImage = value;
            }
        }

        public void ADD_Book(string title,string author,string edition,double price,string isbn,string coverimage)
        {
            try
            {


                DatabaseConnection conn = new DatabaseConnection();

                SqlCommand cmd = new SqlCommand("insert into Books (Title,Author,Edition,Price,ISBN,CoverImage) values('" + @title + "','" + @author + "',@edition,'" + @price + "','" + @isbn + "','" + @coverimage + "')", conn.con);

                cmd.Parameters.AddWithValue("@title", title);

                cmd.Parameters.AddWithValue("@author", author);

                cmd.Parameters.AddWithValue("@edition", edition);

                cmd.Parameters.AddWithValue("@price", price);

                cmd.Parameters.AddWithValue("@isbn", isbn);

                cmd.Parameters.AddWithValue("@covrimage", coverimage);

                conn.con.Open();
                cmd.ExecuteNonQuery();
                conn.con.Close();
                MessageBox.Show("Data iserted");

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
        }
        public bool ISBN_Cheker()
        {

            return true;
        }
        public void Update_Book()
        {

        }
        public void Delete_Book()
        {

        }
        public void Search_Book()
        {

        }
    }
}