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
                if (value=="")
                {
                    MessageBox.Show("ISBN required!");
                }
                bool isbnchecker = ISBN_Cheker(value);
                if (isbnchecker==true)
                {
                    _ISBN = value;
                }
                else
                {
                    MessageBox.Show("You enterd invalid ISBN please enter 10 digit valid one");
                }
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
        public bool ISBN_Cheker(string isbn)
        {
            
            char[] Use_input_parsed_to_char = isbn.ToCharArray();
            Console.WriteLine("\n");
            char[] ISBN_number;
            ISBN_number = new char[10];

            char letter;
            for (int j = 0; j < isbn.Length; j++)
            {
                letter = Use_input_parsed_to_char[j];

                ISBN_number[j] = letter;
            }

            int Multiplier = 10;
            int sum = 0;
            int mod;
            int subst;
            int parsed_number1 = 0;
            for (int i = 0; i < ISBN_number.Length; i++)
            {
                if (Multiplier == 1)
                {
                    break;
                }

                int parsed_number = (int)Char.GetNumericValue(ISBN_number[i]);


                sum = sum + parsed_number * Multiplier;
                Multiplier--;

            }

            mod = sum % 11;
            subst = 11 - mod;
            parsed_number1 = (int)Char.GetNumericValue(ISBN_number[9]);
            if (ISBN_number[9].Equals('x'))
            {

                parsed_number1 = (int)Char.GetNumericValue(ISBN_number[9]);
            }
            if (subst == 10 && ISBN_number[9].Equals('x'))
            {
                return true;
                
            }

            else if (subst == parsed_number1)
            {
                return true;
                

            }

            else
            {
                return false;
            }
                        
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