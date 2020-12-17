using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstAppliction.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Method2()
        {
            return View();
        }
        public ActionResult First(int id=0)  //Default parameter //Make int Nullable int?
        {
            ViewBag.Id = id;
            return View();
        }

        //http://localhost:54622/Default/Second/100?a=10&b=55&c=Rahul
        public ActionResult Second(int id = 0,int a=0,int b=0,string c ="")
        {
            ViewBag.Id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;


            return View();
        }

        /*public string Index()
        {
            return "Hello World";
        }*/
    }
}