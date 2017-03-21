using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
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
        public bool AdminLogin()
        {
            return true;
        }
        public bool ClerkLogin()
        {
            return true;
        }
        public DatabaseConnection conn = new DatabaseConnection();
        public bool AdminLogin(string username, string password)
        {
            
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }
            SqlCommand ad = new SqlCommand("select * from Admins where UserName ='" + username + "' and Password = '" + password + "' ", conn.con);
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

    }

