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

        public List<string> list_books()
        {
            List<string> books = new List<string>();           
            string title, author, edition, price;
            DatabaseConnection con = new DatabaseConnection();

            try
            {
                if (ConnectionState.Closed == con.con.State)
                {
                    con.con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Books", con.con); //Title, Author, Price, ISBN
                DataTable dt = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    title = dt.Rows[a]["Title"].ToString();
                    author = dt.Rows[a]["Author"].ToString();
                    edition = dt.Rows[a]["Edition"].ToString();
                    price = dt.Rows[a]["Price"].ToString();
                    books.Add(title + " " + edition +" edition, by " + author + " for $" + price);
                }
                con.con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

            return books;

        }


    }
}
