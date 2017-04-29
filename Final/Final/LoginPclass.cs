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

    public DatabaseConnection conn = new DatabaseConnection();

    public bool AdminLogin(string username, string password)//checks login credentials against admin database
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
          if (dt.Rows.Count == 1)//account is found
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


    public Boolean UserLogin(string uname, string pass)//checks login credentials against user/clerk database
        {
      try
      {
        using (var connection = conn.con)
        {
          connection.Open();
          SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = '" + uname + "' and Password = '" + pass + "'", connection);
          DataTable dt = new DataTable();
          SqlDataReader reader = cmd.ExecuteReader();
          dt.Load(reader);
          if (dt.Rows.Count == 1)//acount is found
          {
            return true;
          }
          else
          {
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

