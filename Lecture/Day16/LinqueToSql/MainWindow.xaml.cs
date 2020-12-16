using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
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

namespace LinqueToSql
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

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();

            Employee o = new Employee();

            try
            {
                o.EmpNo = Convert.ToInt32(txtEmpNo.Text);// Call property and in property your validation code run first
                o.Name = txtName.Text;
                o.Basic = Convert.ToInt32(txtBasic.Text);
                o.DeptNo = Convert.ToInt32(txtDeptNo.Text);
                dbContext.Employees.InsertOnSubmit(o);
                dbContext.SubmitChanges();
            }
            catch (InvalidBasicException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (InvalidEmpNoException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (InvalidNameException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            Employee o = dbContext.Employees.SingleOrDefault(emp => emp.EmpNo == Convert.ToInt32(txtEmpNo.Text));
            if (o != null)
            {
                try
                {

                    o.Name = txtName.Text;
                    o.Basic = Convert.ToDecimal(txtBasic.Text);
                    o.DeptNo = Convert.ToInt32(txtDeptNo.Text);

                    dbContext.SubmitChanges();
                }

                catch (InvalidEmpNoException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                catch (InvalidNameException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                catch (InvalidBasicException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else MessageBox.Show("Employee with given employee number doesnt exists");
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();

            DataTable dt = dbContext.Employees.ToDataTable();
            dt.Columns.Remove("Department");
            //dgBox.ItemsSource = dbContext.Employees;
            dgBox.ItemsSource = dt.DefaultView;

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            Employee o = dbContext.Employees.SingleOrDefault(emp => emp.EmpNo == Convert.ToInt32(txtEmpNo.Text));
            if (o!=null)
            {
                dbContext.Employees.DeleteOnSubmit(o);
                dbContext.SubmitChanges();
            }
        }
    }
    public static class ListHelper
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            DataTable dt = new DataTable();
            Type listType = list.ElementAt(0).GetType();
            //get element properties nad datatable columns 
            PropertyInfo[] properties = listType.GetProperties();

            foreach (PropertyInfo property in properties)
                dt.Columns.Add(new DataColumn() { ColumnName = property.Name });
            foreach (object item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                    dr[col] = listType.GetProperty(col.ColumnName).GetValue(item, null);
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}