using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LoginRegister.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<users> objUsers = new List<users>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;MultipleActiveResultSets=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Users";


            SqlCommand cmdCities = new SqlCommand();
            cmdCities.Connection = cn;
            cmdCities.CommandType = System.Data.CommandType.Text;
            cmdCities.CommandText = "select * from cities";


            SqlDataReader dr = cmd.ExecuteReader();  //null(EOF)

            while (dr.Read())
            {
                users usr = new users();
                usr.UserId = Convert.ToInt32(dr["UserId"]);
                usr.LoginName = dr["LoginName"].ToString();
                usr.Password = dr["Password"].ToString();
                usr.FullName = dr["FullName"].ToString();
                usr.Email = dr["Email"].ToString();
                usr.CityId = Convert.ToInt32(dr["CityId"]);
                usr.Phone = dr["Phone"].ToString();

                SqlDataReader dr2 = cmdCities.ExecuteReader();
                List<SelectListItem> ctList = new List<SelectListItem>();
                while (dr2.Read())
                {

                    SelectListItem objItem = new SelectListItem();
                    objItem.Text = dr2["CityName"].ToString();
                    objItem.Value = dr2["CityId"].ToString();
                    ctList.Add(objItem);
                    usr.cities = ctList;
                }
                dr2.Close();

                objUsers.Add(usr);

            }

            dr.Close();

            cn.Close();

            return View(objUsers);
        }

        // GET: Users/Details/5
        public ActionResult Details(int UserId = 0)
        {
            users usr = new users();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from users where UserId =" + UserId;



            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usr.UserId = Convert.ToInt32(dr["UserId"]);
                usr.LoginName = dr["LoginName"].ToString();
                usr.Password = dr["Password"].ToString();
                usr.FullName = dr["FullName"].ToString();
                usr.Email = dr["Email"].ToString();
                usr.CityId = Convert.ToInt32(dr["CityId"]);
                usr.Phone = dr["Phone"].ToString();

            }
            dr.Close();

            cn.Close();

            return View(usr);

        }

        // GET: Users/Create
        public ActionResult Create()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from cities";

            users o = new users();

            SqlDataReader dr = cmd.ExecuteReader();
            List<SelectListItem> clist = new List<SelectListItem>();
            while (dr.Read())
            {
                SelectListItem objItem = new SelectListItem();
                objItem.Text = dr["CityName"].ToString();
                objItem.Value = dr["CityId"].ToString();
                clist.Add(objItem);
                
            }
            o.cities = clist;
            return View(o);
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(users usr)
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
                    cmdCreate.CommandText = "insert into [users] values(@UserId,@LoginName,@Password,@FullName,@Email,@CityId,@Phone)";

                    cmdCreate.Parameters.AddWithValue("@UserId", usr.UserId);
                    cmdCreate.Parameters.AddWithValue("@LoginName", usr.LoginName);
                    cmdCreate.Parameters.AddWithValue("@Password", usr.Password);
                    cmdCreate.Parameters.AddWithValue("@FullName", usr.FullName);
                    cmdCreate.Parameters.AddWithValue("@Email", usr.Email);
                    cmdCreate.Parameters.AddWithValue("@CityId", usr.CityId);
                    cmdCreate.Parameters.AddWithValue("@Phone", usr.Phone);


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

        //login
        [HttpGet]
        public ActionResult Login()
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
                 return RedirectToAction("HomePage", "Home");
            }
           
        }

        //login Post
        [HttpPost]
        public ActionResult Login(userLogin login)
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


                    return RedirectToAction("HomePage","Home");
                }
                else
                {
                    return RedirectToAction("Login");
                }

                dr.Close();
               
            }
            
        }

        //Logout
        
        [ChildActionOnly]
        public ActionResult Logout()
        {
            //return RedirectToAction("Login");
            Session.Abandon();
            HttpCookie objCookie = new HttpCookie("DarkChoco");
            objCookie.Expires = DateTime.Now.AddDays(-1);
            return View();
        }

        [HttpGet]
        public ActionResult Logout1()
        {
            //return RedirectToAction("Login");
            Session.Abandon();
            HttpCookie objCookie = new HttpCookie("DarkChoco");
            objCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Response.Cookies.Add(objCookie);

            return RedirectToAction("login");
        }

        //Home
        [HttpGet]
        public ActionResult HomePage()
        {
            string a = (string)Session["LoginName"];

            HttpCookie objCookie = Request.Cookies["DarkChoco"];


            if (objCookie == null && a == null) 
            {
                /*string s1 = null;
                string s2 = null;

                s1 = objCookie.Values["LoginName"];
                s1 = objCookie.Values["Password"];*/

                return RedirectToAction("Login");
            }
            else if (a == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
           
        }

        [HttpPost]
        public ActionResult HomePage(userLogin login)
        {
            users usr = new users();
            
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from users where LoginName =" + login.LoginName;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usr.UserId = Convert.ToInt32(dr["UserId"]);
                usr.LoginName = dr["LoginName"].ToString();
                usr.Password = dr["Password"].ToString();
                usr.FullName = dr["FullName"].ToString();
                usr.Email = dr["Email"].ToString();
                usr.CityId = Convert.ToInt32(dr["CityId"]);
                usr.Phone = dr["Phone"].ToString();

            }
            dr.Close();

            cn.Close();

            return View(usr);

           
        }



        // GET: Users/Edit/5
        public ActionResult Edit(int UserId = 0)
        {
            users usr = new users();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from users where UserId = @UserId";
            cmd.Parameters.AddWithValue("@userId", UserId);

            SqlCommand cmdCity = new SqlCommand();
            cmdCity.Connection = cn;
            cmdCity.CommandType = System.Data.CommandType.Text;

            SqlCommand cmdCities = new SqlCommand();
            cmdCities.Connection = cn;
            cmdCities.CommandType = System.Data.CommandType.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usr.UserId = Convert.ToInt32(dr["UserId"]);
                usr.LoginName = dr["LoginName"].ToString();
                usr.Password = dr["Password"].ToString();
                usr.FullName = dr["FullName"].ToString();
                usr.Email = dr["Email"].ToString();
                usr.CityId = Convert.ToInt32(dr["CityId"]);
                usr.Phone = dr["Phone"].ToString();

                cmdCity.CommandText = "select * from cities where CityId = "+usr.CityId;
                SqlDataReader dr2 = cmdCity.ExecuteReader();
                string name = null;
                while (dr2.Read())
                {
                     name = dr2["CityName"].ToString();
                }
                dr2.Close();

                cmdCities.CommandText = "select * from cities";
                SqlDataReader dr3 = cmdCities.ExecuteReader();

                List<SelectListItem> ctList = new List<SelectListItem>();
                while (dr3.Read())
                {
                    if(name.Equals(dr3["CityName"].ToString()))
                    {
                        ctList.Add(new SelectListItem { Text = dr3["CityName"].ToString(), Value = dr3["CityId"].ToString(), Selected = true });

                    }
                    else
                    {
                        ctList.Add(new SelectListItem { Text = dr3["CityName"].ToString(), Value = dr3["CityId"].ToString()});
                    }
                    usr.cities = ctList;
                }
                dr2.Close();
            }
            dr.Close();

            cn.Close();

            return View(usr);

        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int UserId, users usr)
        {
            try
            {
                // TODO: Add update logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
                cn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "update users set LoginName=@LoginName,Password=@Password,FullName=@FullName,Email=@Email,CityId=@CityId,Phone=@Phone where UserId = @UserId";

                cmdUpdate.Parameters.AddWithValue("@UserId", usr.UserId);
                cmdUpdate.Parameters.AddWithValue("@LoginName", usr.LoginName);
                cmdUpdate.Parameters.AddWithValue("@Password", usr.Password);
                cmdUpdate.Parameters.AddWithValue("@FullName", usr.FullName);
                cmdUpdate.Parameters.AddWithValue("@Email", usr.Email);
                cmdUpdate.Parameters.AddWithValue("@CityId", usr.CityId);
                cmdUpdate.Parameters.AddWithValue("@Phone", usr.Phone);



                cmdUpdate.ExecuteScalar();

                cn.Close();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                throw ex;
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int UserId = 0)
        {
            users usr = new users();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from users where UserId = @UserId";
            cmd.Parameters.AddWithValue("@UserId", usr.UserId);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                usr.UserId = Convert.ToInt32(dr["UserId"]);
                usr.LoginName = dr["LoginName"].ToString();
                usr.Password = dr["Password"].ToString();
                usr.FullName = dr["FullName"].ToString();
                usr.Email = dr["Email"].ToString();
                usr.CityId = Convert.ToInt32(dr["CityId"]);
                usr.Phone = dr["Phone"].ToString();

            }
            dr.Close();

            cn.Close();

            return View(usr);
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int UserId, users usr)
        {
            try
            {
                // TODO: Add update logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = (localdb)\MsSqlLocalDb; Initial Catalog = JKDec20; Integrated Security = True;";
                cn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "DELETE FROM users WHERE UserId = @UserId" ;
                cmdUpdate.Parameters.AddWithValue("@UserId", usr.UserId);

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
