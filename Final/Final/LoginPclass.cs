﻿using System;
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
        public bool ClerkLogin()
        {
            return true;
        }
        public DatabaseConnection conn = new DatabaseConnection();
        public bool AdminLogin(string username, string password)
        {
            try
            {

                if (ConnectionState.Closed == conn.con.State)//this needs to be a try catch
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
            catch(Exception x)
            {
                throw new Exception ("error"+ x);
            }
            
          }

            
            //if (ConnectionState.Closed == conn.con.State)//does this need to be a try catch?
            //{
            //    conn.con.Open();
            //}
            //SqlCommand ad = new SqlCommand("select * from Admins where UserName ='" + username + "' and Password = '" + password + "' ", conn.con);
            //DataTable dt = new DataTable();
            //SqlDataReader rd = ad.ExecuteReader();
            //dt.Load(rd);

            //if (dt.Rows.Count == 1)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

//        }




        public Boolean UserLogin(string uname, string pass)
        {
            try
            {
                if (ConnectionState.Closed == conn.con.State)
                {
                    conn.con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username = '" + uname + "' and Password = '" + pass + "'", conn.con);
                DataTable dt = new DataTable();
                SqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);

                if(dt.Rows.Count == 1)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            MessageBox.Show("Something happened");
            return false;
        }
    }
    }
