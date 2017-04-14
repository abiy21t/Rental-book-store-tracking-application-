using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Final
{
  public class LoginPclass
  {
    private string user_name;
    private string password;

    public string UserName
    {
      get { return user_name; }
      set
      {
        user_name = value;
      }

    }
    public string Password
    {
      get
      {
        return password;
      }
      set
      {
        password = value;
      }
    }
    /*public bool AdminLogin()
    {
        return true;
    }*/
    //public bool ClerkLogin()
    //{
    //    return true;
    //}
    public DatabaseConnection conn = new DatabaseConnection();
    public bool AdminLogin(string username, string password)
    {
      try
      {

        using (var connection = conn.con)
        {
          connection.Open();
          SqlCommand ad = new SqlCommand("select * from Admins where UserName ='" + username + "' and Password = '" + password + "' ", connection);
          DataTable dt = new DataTable();
          SqlDataReader rd = ad.ExecuteReader();
          dt.Load(rd);

          if (dt.Rows.Count == 1)
          {
            return true;
          }
          else
          {
            return false;
          }
        }
      }
      catch (Exception x)
      {
        throw new Exception("Error connecting to database. \n" + x);
      }

    }


    public Boolean UserLogin(string uname, string pass)
    {
      try
      {
        /*
         * MS
         * The way you are creating the connection is fine but it really needs to be wrapped in a 'using' statement.
         * What this does is creates a code block inside of which that SQLConnection is valid. 
         * Once it drops out of the code block, it will do 2 things:
         * 1. It will close the connection to the DB
         * 2. It will dispose of the connection. 
         * This last bit is important.. normally we don't care about garbage collection but in this case, since your object created a reference to an
         * external connection (basically a socket to communicate with the database) you have to mark the object for disposal so the GC will collect it. 
         * Dispose() doesn't necessarily immediately free up the memory (GC is non-deterministic) but it will tell the garbage collection routine that it's
         * OK to clean up this object.
         * 
         * Ultimately this was at the root of why I couldn't get your program to run.
         * You will need to follow the same coding pattern I use here in all of your other classes where you access a database. 
         */
        using (var connection = conn.con)
        {
          connection.Open();
          SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = '" + uname + "' and Password = '" + pass + "'", connection);
          DataTable dt = new DataTable();
          SqlDataReader reader = cmd.ExecuteReader();
          dt.Load(reader);

          if (dt.Rows.Count == 1)
          {
            conn.con.Close();
            return true;
          }
          else
          {
            conn.con.Close();
            return false;
          }
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error connecting to database. \n" + ex);
      }
      MessageBox.Show("Something happened");
      return false;
    }
  }
}

