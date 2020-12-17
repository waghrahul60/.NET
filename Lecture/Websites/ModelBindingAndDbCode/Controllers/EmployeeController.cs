
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelBindingAndDbCode.Models;

namespace ModelBindingAndDbCode.Controllers
{
    public class EmployeeController : Controller
    {
        

        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> objEmpList = new List<Employee>();
            
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
                Employee emp = new Employee();
                emp.EmpNo = Convert.ToInt32(dr["EmpNo"]);
                emp.Name = dr["Name"].ToString();
                emp.Basic = Convert.ToInt32(dr["Basic"]);
                emp.DeptNo = Convert.ToInt32(dr["DeptNo"]);

                objEmpList.Add(emp);
            }

            dr.Close();

            cn.Close();

            return View(objEmpList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id=0)
        {
            Employee emp = new Employee();
 
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees where EmpNo ="+id;

            SqlDataReader dr = cmd.ExecuteReader();  //null(EOF)

            while (dr.Read())
            {
     
                emp.EmpNo = Convert.ToInt32(dr["EmpNo"]);
                emp.Name = dr["Name"].ToString();
                emp.Basic = Convert.ToInt32(dr["Basic"]);
                emp.DeptNo = Convert.ToInt32(dr["DeptNo"]);
            }
            dr.Close();

            cn.Close();

            return View(emp);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
                cn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdUpdate.Parameters.AddWithValue("@Name", emp.Name);
                cmdUpdate.Parameters.AddWithValue("@Basic", emp.Basic);
                cmdUpdate.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
                cmdUpdate.Parameters.AddWithValue("@EmpNo", emp.EmpNo);

                cmdUpdate.ExecuteNonQuery();

                cn.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id=0)
        {
            Employee emp = new Employee();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees where EmpNo =" + id;

            SqlDataReader dr = cmd.ExecuteReader();  //null(EOF)

            while (dr.Read())
            {

                emp.EmpNo = Convert.ToInt32(dr["EmpNo"]);
                emp.Name = dr["Name"].ToString();
                emp.Basic = Convert.ToInt32(dr["Basic"]);
                emp.DeptNo = Convert.ToInt32(dr["DeptNo"]);
            }
            dr.Close();

            cn.Close();
            return View(emp);

        }

        /*
          [HttpPost]
                public ActionResult Edit(int? id, FormCollection collection)
                {
                    try
                    {
                        // TODO: Add update logic here
                        int EmpNo = Convert.ToInt32(collection["EmpNo"]);
                        string Name = collection["Name"];


                        return RedirectToAction("Index");
                    }
                    catch
                    {
                        return View();
                    }
                }
         */
        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, Employee emp)
        {
            try
            {
               
                
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
                cn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = "+id;


                cmdUpdate.Parameters.AddWithValue("@Name",emp.Name);
                cmdUpdate.Parameters.AddWithValue("@Basic", emp.Basic);
                cmdUpdate.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
               

                cmdUpdate.ExecuteScalar();
          

                cn.Close();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id=0)
        {
            Employee emp = new Employee();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Employees where EmpNo =" + id;

            SqlDataReader dr = cmd.ExecuteReader();  //null(EOF)


            while (dr.Read())
            {

                emp.EmpNo = Convert.ToInt32(dr["EmpNo"]);
                emp.Name = dr["Name"].ToString();
                emp.Basic = Convert.ToInt32(dr["Basic"]);
                emp.DeptNo = Convert.ToInt32(dr["DeptNo"]);
            }
            dr.Close();

            cn.Close();
            return View(emp);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee obj)
        {
            try
            {
                // TODO: Add delete logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
                cn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "DELETE FROM Employees WHERE EmpNo =" + id;
                cmdUpdate.ExecuteScalar();


                cn.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
