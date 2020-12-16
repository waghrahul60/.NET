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

using System.Data.SqlClient;
using System.Data;

namespace WpfApp2
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            //cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb;Initial Catlog=JKDec20;Id=sdjhf;Password=hsd;";

            //Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True; Pooling = False Copy From Property
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "insert into Employees values(1,'Rahul',100000,10)";
            cmd.CommandText = "insert into Employees values("+ txtEmpNo.Text+",'"+txtName.Text + "',"+txtBasic.Text+","+ txtDeptNo.Text+")";
            MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Okey");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
    
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);


            MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Okey");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            cn.Close();


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);
            //delete from employee where 1 = 1;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Okey");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            cn.Close();

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "";

            
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);
            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            //delete from employee where 1 = 1;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Okey");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            cn.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";

            cn.Open();
            SqlTransaction t = cn.BeginTransaction();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = t;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into Employees values (200,'new emp',12345,10)";


            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;
            cmd2.Transaction = t;
            cmd2.CommandType = System.Data.CommandType.Text;
            cmd2.CommandText = "insert into Employees values (200,'new emp2',12345,10)";
           
            try
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                t.Commit();
                MessageBox.Show("Okey");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                t.Rollback();
            }
            finally
            {
                cn.Close();
            }
        }

        private void btnExecute_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();
         
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select Name from Employees";
            //cmd.ExecuteScalar();

            MessageBox.Show(cmd.ExecuteScalar().ToString());

            cn.Close();
        }
    }
}
