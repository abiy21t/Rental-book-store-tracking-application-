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
        public DatabaseConnection conn = new DatabaseConnection();
        
        
        public void Add_Admin(string fname,string lname, string uname, string password, string email, long phone)
        {
            Firstname = fname;
            Lastname = lname;
            Username = uname;
            Password = password;
            Email = email;
            PhoneNumber = phone;



            try
            {
                

                //EmployeeInfo emplp = new EmployeeInfo();

                SqlCommand cmd = new SqlCommand("insert into Admins (FirstName,LastName,UserName,Password,Email,PhoneNumber) values('" + Firstname + "','" + Lastname + "',@Username,'" + Password + "','" + Email + "','" + PhoneNumber + "')", conn.con);
                
                cmd.Parameters.AddWithValue("@Firstname", Firstname);
                
                cmd.Parameters.AddWithValue("@Lastname", Lastname);
                
                cmd.Parameters.AddWithValue("@Username", Username);
                
                cmd.Parameters.AddWithValue("@Password", Password);
               
                cmd.Parameters.AddWithValue("@Email", Email);
               
                cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                
                conn.con.Open();
                cmd.ExecuteNonQuery();
                conn.con.Close();
                MessageBox.Show("Data iserted");

            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex);
            }

        }

    }
}
