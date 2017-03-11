using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace FileIO.DBL
{
    public class EmployeeDBL
    {
        DataTable datat = new DataTable();
        public DataTable ReadEmployeeData()
        {
            Connection conn = new Connection();
            if (ConnectionState.Closed == conn.con.State)
            {
                conn.con.Open();
            }
            SqlCommand cmd = new SqlCommand("select * from Employee", conn.con);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                datat.Load(rd);
                return datat;
            }
            catch
            {

                throw;
            }

        }

    }
}
