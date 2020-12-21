using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FullAppliation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string a = (string)Session["LoginName"];

            HttpCookie objCookie = Request.Cookies["DarkChoco"];


            if (objCookie == null && a == null)
            {
                /*string s1 = null;
                string s2 = null;

                s1 = objCookie.Values["LoginName"];
                s1 = objCookie.Values["Password"];*/

                return RedirectToAction("Login","Student");
            }
            /*else if (a == null)
            {
                return RedirectToAction("Login","Student");
            }*/
            else
            {
                return View();
            }
           
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}