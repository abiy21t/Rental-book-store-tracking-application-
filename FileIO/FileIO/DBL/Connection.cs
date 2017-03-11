using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace FileIO.DBL
{
   public  class Connection
    {

        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elhanan\Desktop\IO_Ass\FileIO\FileIO\FileIO.mdf;Integrated Security=True");
    }
}
