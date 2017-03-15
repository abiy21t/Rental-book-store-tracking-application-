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
                /*
                 * MS see comment below
                 */

                if (value.All(char.IsLetter))
                {
                    _fname = value;
                }else
                {
                    throw new InvalidNameException("Name cannot contain numbers");
                }
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
