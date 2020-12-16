using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        DataSet ds;

        private void btnFillDataset_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            ds = new DataSet();
            da.Fill(ds, "Emps");

            cmd.CommandText = "select * from Departments";
            da.Fill(ds, "Depts");

            //Primaary key Validation
            DataColumn[] arrCols = new DataColumn[1]; //How many primaary keys are their

            arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"];
            ds.Tables["Emps"].PrimaryKey = arrCols;


            //Foreign Key Validaation
            ds.Relations.Add(ds.Tables["Depts"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);

            //Column Level Constraints
           // ds.Tables["Depts"].Columns["DeptName"].Unique = true;

            //dgEmps.ItemsSource = ds.Tables[0].DefaultView;
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;
            //dgEmps.ItemsSource = ds.Tables["Depts"].DefaultView;
            cn.Close();
        }

        private void dgEmps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";

            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";


            //cmdUpdate.Parameters.AddWithValue("@Names", ds.Tables["Emps"]);

          /*  SqlParameter p = new SqlParameter();
            p.ParameterName = "@Name";
            p.SourceColumn = "Name";
            p.SourceVersion = DataRowVersion.Current;
            cmdUpdate.Parameters.Add(p);
*/

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name" , SourceVersion = DataRowVersion.Current});
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmpNo = @EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;



            //ds = new DataSet();
            da.Update(ds, "Emps");


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";

            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";


            //cmdUpdate.Parameters.AddWithValue("@Names", ds.Tables["Emps"]);

            /*  SqlParameter p = new SqlParameter();
              p.ParameterName = "@Name";
              p.SourceColumn = "Name";
              p.SourceVersion = DataRowVersion.Current;
              cmdUpdate.Parameters.Add(p);
  */

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmpNo = @EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;

            da.ContinueUpdateOnError = true;

            //ds = new DataSet();
            da.Update(ds, "Emps");


        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";

            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmpNo = @EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;

            DataSet ds2 = ds.GetChanges();
            DataSet ds3 = ds.GetChanges(DataRowState.Modified);
            

            //ds = new DataSet();
            da.Update(ds, "Emps");

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";

            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";

            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "DELETE FROM Employees WHERE EmpNo = @EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });


            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;


            da.Update(ds, "Emps");
            ds.AcceptChanges();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            ds.RejectChanges();
        }


        //when you want to show multiple time data then you need extra view otherwise used defalt view
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
/*
            DataView dv = new DataView(ds.Tables["Emps"]);
            dv.RowFilter = "DeptNo = "+txtFilter.Text;//where clause
            //dv.Sort = "Name"; //order by clause
            dgEmps.ItemsSource = dv;
*/
            ds.Tables["Emps"].DefaultView.RowFilter = "DeptNo =" + txtFilter.Text;
            //ds.Tables["Emps"].DefaultView.RowFilter = "";

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(ds.GetXml());
            //MessageBox.Show(ds.GetXmlSchema());

            ds.WriteXmlSchema("a.xsd");
            ds.WriteXml("a.xml",XmlWriteMode.DiffGram);

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ds = new DataSet();
            ds.ReadXmlSchema("a.xsd");
            ds.ReadXml("a.xml", XmlReadMode.DiffGram);
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView;

        }
    }
}
