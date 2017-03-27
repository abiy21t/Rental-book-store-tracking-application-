using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
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
        
        
        //private date _birthday;

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
                    //throw new Exception("hello");
                    //throw new InvalidNameException("hello");
                    //throw new ArgumentException("hello");
                    //how can we throw an error so it stops at this message?
                }
                else
                {
                    throw new InvalidNameException("First name cannot contain numbers");
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
                    throw new InvalidNameException("Last name cannot contain numbers");
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
                else if (value.Length < 5 || value.Length > 25)
                {
                    MessageBox.Show("Password length should be at least 6 and at most 25");
                }
                
                else
                {
                    _password = value;
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

        public Boolean Add_User(string uname, string pass, string fname, string lname, string email, long phone)
        {
            Boolean done = false;
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username,Password,FirstName,LastName,Email,PhoneNumber) values('" + @uname + "','" + @pass + "','" + @fname +"','" + @lname + "','" + @email + "','" + @phone + "')", conn.con);

                cmd.Parameters.AddWithValue("@fname", fname);

                cmd.Parameters.AddWithValue("@lname", lname);

                cmd.Parameters.AddWithValue("@uname", uname);

                cmd.Parameters.AddWithValue("@password", pass);

                cmd.Parameters.AddWithValue("@email", email);

                cmd.Parameters.AddWithValue("@phone", phone);

                conn.con.Open();
                //cmd.Connection = conn.con;
                cmd.ExecuteNonQuery();
                conn.con.Close();
                MessageBox.Show("User has been added");
                done = true;
                return done;

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }
            return done;
        }



        /*public User(string fn, string ln, string un, string pass, string email, int pn)
        {
            this._fname = fn;
            this._lname = ln;
            this._password = pass;
            this._username = un;
            this._phoneNum = pn;
        }
        */
        //are either of these setups correct for professional coding? or should all of this be done through database?
        /*
         * MS
         * I think what you are asking is: should we be validating things before sending to the database. 
         * 
         * The answer generally is "yes". A lot of that depends on your architecture but it's pretty rare to put all of your validation
         * in the database. Mostly this is because the cost (in CPU cycles and bandwidth) is too high to push things all the way to the DB
         * only to find out it is invalid.
         * 
         * So what you are doing here makes sense... and yes, you are correctly checking things inside the code block for the set{} 
         * Some programmers would prefer to make actual validation classes and tap into those at the UI level. The way you are doing 
         * it here you would probably need to throw an exception if validation failed. Philosophically, some programmers
         * are very averse to using Exceptions for anything other than failures of the system. Many however see exceptions as
         * a perfectly valid method of returning information from a method (or property set). 
         * 
         * Considering that Microsoft allows you to extend the Exception class to make your own, I have seen this used 
         * effectively to pass information back.  For instance, here you could create your own exception and throw it in the code above.  
         * 
         * (I put an example in the code)
         */
        
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
