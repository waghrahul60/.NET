using FullAppliation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullAppliation.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/login
        public ActionResult login()
        {
            HttpCookie objCookie = Request.Cookies["DarkChoco"];
            /*string s1 = null;
            string s2 = null;

            s1 = objCookie.Values["LoginName"];
            s1 = objCookie.Values["Password"];*/

            if (objCookie == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index", "Home");
            }
            
        }

        // POST: Student/login
        [HttpPost]
        public ActionResult login(Students login)
        {
            if (login.LoginName == null || login.Password == null)
            {
                return View();
            }
            else
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;MultipleActiveResultSets=true";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from students where LoginName = @LoginName and Password = @Password";
                cmd.Parameters.AddWithValue("@LoginName", login.LoginName);
                cmd.Parameters.AddWithValue("@Password", login.Password);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    Session["LoginName"] = login.LoginName;
                    Session["Password"] = login.Password;
                    HttpCookie objCookie = new HttpCookie("DarkChoco");

                    /* objCookie.Values["LoginName"] = login.LoginName;
                     objCookie.Values["Password"] = login.Password;
                     objCookie.Expires = DateTime.Now.AddDays(1);
                     objCookie.HttpOnly = true;
                     Response.Cookies.Add(objCookie);*/
                    if (login.RememberMe == true)
                    {
                        objCookie.Expires = DateTime.Now.AddDays(1);
                        objCookie.Values["LoginName"] = login.LoginName;
                        objCookie.Values["Password"] = login.Password;
                        objCookie.HttpOnly = true;
                        Response.Cookies.Add(objCookie);
                    }
                    else
                    {
                        objCookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(objCookie);
                    }


                    return RedirectToAction("index","Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }

                dr.Close();

            }
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from cities";

            Students std = new Students();

            SqlDataReader dr = cmd.ExecuteReader();
            List<SelectListItem> clist = new List<SelectListItem>();
            while (dr.Read())
            {
                SelectListItem objItem = new SelectListItem();
                objItem.Text = dr["CityName"].ToString();
                objItem.Value = dr["CityId"].ToString();
                clist.Add(objItem);

            }
            std.cities = clist;
            return View(std);
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Students std)
        {
            try
            {
                // TODO: Add insert logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
                cn.Open();

                SqlCommand cmdCreate = new SqlCommand();
                cmdCreate.Connection = cn;
                cmdCreate.CommandType = System.Data.CommandType.Text;
                cmdCreate.CommandText = "insert into students values(@LoginName,@Password,@FullName,@Email,@CityId,@Phone)";

                
                cmdCreate.Parameters.AddWithValue("@LoginName", std.LoginName);
                cmdCreate.Parameters.AddWithValue("@Password", std.Password);
                cmdCreate.Parameters.AddWithValue("@FullName", std.FullName);
                cmdCreate.Parameters.AddWithValue("@Email", std.Email);
                cmdCreate.Parameters.AddWithValue("@CityId", std.CityId);
                cmdCreate.Parameters.AddWithValue("@Phone", std.Phone);


                cmdCreate.ExecuteNonQuery();

                cn.Close();
                return RedirectToAction("Login");
            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }

        //Logout
        [HttpGet]
        public ActionResult Logout()
        {
            //return RedirectToAction("Login");
            Session.Abandon();
            HttpCookie objCookie = new HttpCookie("DarkChoco");
            objCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Response.Cookies.Add(objCookie);

            return RedirectToAction("login");
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
