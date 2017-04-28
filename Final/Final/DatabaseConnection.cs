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
    /*
     * MS 
     * This property looks for the MainDB file in the same folder as the .exe is running in. 
     * This way you dont' have to change the connection string based on which compouter you are running it on. 
     * It will always be in this folder because it is relative to Visual Studio.
     */
    private string connectionString
    {
      get
      {
        var db = Environment.CurrentDirectory + @"\MainDB.mdf";
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" + db + ";Integrated Security=True;";
        return connectionString;
      }
    }

    /*
     * MS 
     * I changed this to a property which effectively makes this class a connction factory. Every time you get con, you get a brand new 
     * SQLConnection object with the correct connection string. 
     * If I wanted to, I could open the connection here so I don't have to do it every time I use it...might be a change you want to make. 
     */
    public SqlConnection con
    {
      get
      {
        return new SqlConnection(connectionString);//replace with necessary source file
      }
    }
  }
}

//Abiy data source file
//Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elhanan\Desktop\FinalProject\Final\Final\MainDB.mdf;Integrated Security = True

//Nik data source file
//Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nik\Documents\Visual Studio 2015\Projects\Final_Project\Final\Final\MainDB.mdf;Integrated Security = True

//var db = Environment.CurrentDirectory + @"\MainDB.mdf";
//string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFileName=" + db + ";Integrated Security=True;";
//        return connectionString;


