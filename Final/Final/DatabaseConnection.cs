using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Final
{
   public class DatabaseConnection
    {
        public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elhanan\Desktop\FinalProject\Final\Final\MainDB.mdf;Integrated Security=True");
    }
}

    

