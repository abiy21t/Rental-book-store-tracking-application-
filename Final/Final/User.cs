using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Final
{
    public class User
    {
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
                //if fname doesnt contain numbers or symbols
                _fname = value;
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
                _lname = value;
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
                _username = value;
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
                    MessageBox.Show("required");
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
                _email = value;
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

        
    }
}
