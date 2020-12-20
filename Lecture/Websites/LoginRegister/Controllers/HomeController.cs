using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginRegister.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
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

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
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

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
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
