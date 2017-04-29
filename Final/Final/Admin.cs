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
    public class Admins : User
    {
        //public DatabaseConnection conn = new DatabaseConnection(); dont need inherited from user class

        public Boolean Add_Admin(string fname, string lname, string uname, string password, string email, long phone)//add admin account to database
        {
            Firstname = fname;
            Lastname = lname;
            Username = uname;
            Password = password;
            Email = email;
            PhoneNumber = phone;
            Boolean done = false;
            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }

                    //SqlCommand cmd = new SqlCommand("insert into Admins (FirstName,LastName,UserName,Password,Email,PhoneNumber) values('" + Firstname + "','" + Lastname + "',@Username,'" + Password + "','" + Email + "','" + PhoneNumber + "')", connection);
                    SqlCommand cmd = new SqlCommand("insert into Admins (FirstName,LastName,UserName,Password,Email,PhoneNumber) values(@Firstname,@Lastname,@Username,@Password,@Email,@PhoneNumber)", connection);
                    //replace entries with their values
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted. Admin has been added to the system.");
                    done = true;
                    return done;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bad data detected. Account was not created.");// + ex);
            }
            return done;

        }

        public bool get_Admin_by_username(string username)//finds admin accounts matching the given username
        {
            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("select * from Admins where UserName ='" + username + "'  ", connection);//retuns datarows with that username
                    DataTable dt = new DataTable();
                    SqlDataReader rd = ad.ExecuteReader();
                    dt.Load(rd);
                    if (dt.Rows.Count == 1)//if account is found
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception x)
            {
                throw new Exception("error" + x);
            }
        }
      }
    }
