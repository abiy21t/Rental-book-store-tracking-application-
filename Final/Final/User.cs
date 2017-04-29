using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

namespace Final
{
    public class User
    {
        public DatabaseConnection conn = new DatabaseConnection();
        private string _fname;
        private string _lname;
        private string _username;
        private string _password;
        private string _email;
        private long _phoneNum;

        public string Firstname
        {
            get
            {
                return _fname;
            }
            set
            {
                if (value.All(char.IsLetter) && value != "")
                {
                    _fname = value;
                }
                else if (value == "")
                {
                    MessageBox.Show("First name field required");
                }
                else
                {
                    MessageBox.Show("Name cannot contain number");
                }
            }
        }
        public string Lastname
        {
            get
            {
                return _lname;
            }
            set
            {
                if (value.All(char.IsLetter) && value != "")
                {
                    _lname = value;
                }
                else if (value == "")
                {
                    MessageBox.Show("Last name field required");
                }
                else
                {
                    MessageBox.Show("Last name cannot contain numbers");
                }
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                if (value == "")
                {
                    MessageBox.Show("Username field required");
                }
                else
                {
                    _username = value;
                }                
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (value == "")
                {
                    MessageBox.Show("Password field required");
                }
                else if (value.Length > 5 && value.Length < 25)
                {
                    _password = value;
                }
                
                else
                {
                    MessageBox.Show("Password length should be at least 6");                    
                }
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                Regex rg = new Regex("[a-zA-Z0-9]{1,25}@[a-zA-Z0-9]{1,25}.[a-zA-Z]{2,3}");
                if (rg.IsMatch(value) && (value.Contains(".com") || value.Contains(".net") || value.Contains(".edu") || value.Contains(".gov") || value.Contains(".org")) && value != "")
                {
                    _email = value;
                }
                else if (value == "")
                {
                    MessageBox.Show("Email field required!");
                }
                else
                {
                    MessageBox.Show("Please enter email xxxxxxx@xxxxx.xxx format");
                }                
            }
        }

        public long PhoneNumber
        {
            get
            {
                return _phoneNum;
            }
            set
            {
                    _phoneNum = value;
            }
        }

        public Boolean Add_User(string uname, string pass, string fname, string lname, string email, long phone)//adds clerk account to user database
        {
            Boolean done = false;
            done = get_User_by_username(uname);//checks if username already exists
            if (!done)
            {
                done = false;
                try
                {
                    using (var connection = conn.con)
                    {
                        if (ConnectionState.Closed == connection.State)
                        {
                            connection.Open();
                        }
                        //SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username,Password,FirstName,LastName,Email,PhoneNumber) values('" + @uname + "','" + @pass + "','" + @fname + "','" + @lname + "','" + @email + "','" + @phone + "')", connection);
                        SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username,Password,FirstName,LastName,Email,PhoneNumber) values(@uname,@pass,@fname,@lname,@email,@phone)", connection);
                        cmd.Parameters.AddWithValue("@fname", fname);
                        cmd.Parameters.AddWithValue("@lname", lname);
                        cmd.Parameters.AddWithValue("@uname", uname);
                        cmd.Parameters.AddWithValue("@pass", pass);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("User has been added");
                        done = true;
                        return done;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bad data detected. Account was not created.");// + ex);

                }
                return done;
            }else
            {
                MessageBox.Show("That username is already taken." );
                return false;
            }
        }

        public bool get_User_by_username(string username)//checks if username already exists in user database
        {
            try
            {
                using (var connection = conn.con)
                {
                    if (ConnectionState.Closed == connection.State)
                    {
                        connection.Open();
                    }
                    SqlCommand ad = new SqlCommand("select * from Users where Username ='" + username + "'  ", connection);
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
                throw new Exception("error" + x);
            }

        }

    }

    /*
     * MS
     * See this link: https://msdn.microsoft.com/en-us/library/87cdya3t(v=vs.110).aspx
     * In practice you would put this in it's own file.  Sometimes we put all of our custom exceptions in a file
     * named "CustomExceptions.cs" but practice varies on that. 
     */
    public class InvalidNameException : Exception {
        public InvalidNameException(string message) : base(message) { }
    }
}
