using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FileIO.BLL;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using FileIO.DBL;
namespace FileIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EmployeeBLL objbll = new EmployeeBLL();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            //EmployeeBLL objbll = new EmployeeBLL();
            dataGrid.ItemsSource =objbll.getEmployee().DefaultView;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //System.Globalization.DateTimeFormatInfo dateInfo = new System.Globalization.DateTimeFormatInfo();
            //dateInfo.ShortDatePattern = "dd/MM/yyyy";
            //DateTime validDate = Convert.ToDateTime(dobtxt.Text, dateInfo);
            EmployeeInfo emp = new EmployeeInfo();
            emp.id = Convert.ToInt32(idtxt.Text);
            emp.fname = fnametxt.Text;
            emp.lname = lnametxt.Text;
            
            emp.DoB = Convert.ToDateTime( dobtxt.Text);
            emp.Salary = Convert.ToDouble(salarytxt.Text);
            emp.position = positiontxt.Text;
            EmployeeBLL bl = new EmployeeBLL();
            bl.insertEmpInfo(emp.id, emp.fname,emp.lname, emp.DoB, emp.Salary, emp.position);
        }
    }
}
