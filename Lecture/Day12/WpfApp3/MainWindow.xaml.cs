using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees";


            SqlDataReader dr = cmd.ExecuteReader();  //null(EOF)

            while (dr.Read())
            {
                lstNames.Items.Add(dr["Name"]);
            }
            
            dr.Close();

            cn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees;select * from Departments";


            SqlDataReader dr = cmd.ExecuteReader();  //null(EOF)

            while (dr.Read())
            {
                lstNames.Items.Add(dr["Name"]);
            }
            dr.NextResult();  //Used in DO While Loop
            while (dr.Read())
            {
                lstNames.Items.Add(dr[1]);
            }

            dr.Close();

            cn.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True; MultipleActiveResultSets = True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = System.Data.CommandType.Text;
          //  cmdEmps.CommandText = "select * from Departments";


            SqlDataReader dr = cmd.ExecuteReader();  //null(EOF)
            while (dr.Read())
            {
                lstNames.Items.Add(dr[1]);
                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + dr["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    lstNames.Items.Add("   "+drEmps["Name"]);
                }
                drEmps.Close();
            }
            dr.Close();

            cn.Close();
        }

        /*privte SqlDataReadwe GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True; MultipleActiveResultSets = True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Departments";
            return 0;
        }*/
    }
}
