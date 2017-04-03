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
        public SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nik\Documents\Visual Studio 2015\Projects\Final_Project\Final\Final\MainDB.mdf;Integrated Security = True");//replace with necessary source file
    }
}

//Abiy data source file
//Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elhanan\Desktop\FinalProject\Final\Final\MainDB.mdf;Integrated Security = True

//Nik data source file
//Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nik\Documents\Visual Studio 2015\Projects\Final_Project\Final\Final\MainDB.mdf;Integrated Security = True


