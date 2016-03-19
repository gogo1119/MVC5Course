using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class AjaxTestController : Controller
    {
        // GET: AjaxTest
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Product vmProduct)
        {
            //寫入資料庫
            //取得序號
            ViewData["serial"] = 10;

            //重新取得資料
            FabricsEntities db = new FabricsEntities();
            var data = db.Product.Take(1).ToList()[0];

            //return RedirectToAction("ConfirmView", new { data });
            return View("ConfirmView", data);
        }

        public ActionResult ConfirmView(Product data)
        {
            //var b = ViewData["serial"].ToString();
            return View(data);
        }
    }
}