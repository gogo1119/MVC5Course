using Microsoft.Web.Mvc;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            return Content("Content Test", "text/html", Encoding.UTF8);
        }

        public ActionResult FileTest(string FileName)
        {
            return File(Server.MapPath("~/Content/bootstrap.css"), "text/css", FileName + ".css");
        }

        //[AjaxOnly]
        public ActionResult JsonTest()
        {
            FabricsEntities db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;

            var data = db.Product.Take(3);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectTest()
        {
            return RedirectToAction("Edit", "Products", new { id = 1 });
        }
    }
}