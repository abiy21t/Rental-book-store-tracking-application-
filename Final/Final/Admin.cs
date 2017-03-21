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
            try
            {


                //EmployeeInfo emplp = new EmployeeInfo();

                SqlCommand cmd = new SqlCommand("insert into Admins (FirstName,LastName,UserName,Password,Email,PhoneNumber) values('" + @fname + "','" + @lname + "',@uname,'" + @password + "','" + @email + "','" + @phone + "')", conn.con);
                
                cmd.Parameters.AddWithValue("@fname", fname);
                
                cmd.Parameters.AddWithValue("@lname", lname);
                
                cmd.Parameters.AddWithValue("@uname", uname);
                
                cmd.Parameters.AddWithValue("@password", password);
               
                cmd.Parameters.AddWithValue("@email", email);
               
                cmd.Parameters.AddWithValue("@phone", phone);
                
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
