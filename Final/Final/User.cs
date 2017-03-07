using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    class User
    {
        private string _fname;
        private string _lname;
        private int _phoneNum;
        private string _email;
        private string _username;
        private string _password;
        //private date _birthday;

        public string Fname
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


        public User(string fn, string ln, string un, string pass, string email, int pn)
        {
            this._fname = fn;
            this._lname = ln;
            this._password = pass;
            this._username = un;
            this._phoneNum = pn;
        }

        //are either of these setups correct for professional coding? or should all of this be done through database?

        
    }
}
