using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using FileIO.DBL;
using System.Windows;
namespace FileIO.BLL
{
    public class EmployeeBLL
    {
        public Connection conn = new Connection();

        public DataTable getEmployee()
        {
            try
            {
                EmployeeDBL obje1 = new EmployeeDBL();
                return obje1.ReadEmployeeData();


            }
            catch (Exception)
            {

                throw;
            }
        }
        public void insertEmpInfo(int id, string fname,string lname,DateTime DoB,double Salary,string position)
        {
            try
            {
                
                
                EmployeeInfo emplp = new EmployeeInfo();
                
                SqlCommand cmd = new SqlCommand("insert into Employee (id,FirstName,LastName,DoB,Salary,Position) values('"+id+"','" +fname + "','" +lname + "',@DoB,'" +Salary + "','" +position + "')", conn.con);
                cmd.Parameters.Add("@DoB", SqlDbType.Date);
                cmd.Parameters["@DoB"].Value = DoB;
                conn.con.Open();
                cmd.ExecuteNonQuery();
                conn.con.Close();
                MessageBox.Show("Data iserted");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("error"+ex);
            }

        }
    }
}
