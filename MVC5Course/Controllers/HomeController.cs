using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [ExecuteTime]
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

        public ActionResult Test()
        {
            return View();
        }

        [HandleError(ExceptionType = typeof(ArgumentException), View = "ErrorArgument")]
        public ActionResult ErrorTest(string e)
        {
            if (e == "1")
            {
                throw new Exception("Error 1");
            }

            if (e == "2")
            {
                throw new ArgumentException("Error 2");
            }

            return Content("No Error");
        }

        public ActionResult RazorTest()
        {
            int[] data = new int[] { 1, 2, 3, 4, 5 };
            return PartialView(data);
        }
    }
}