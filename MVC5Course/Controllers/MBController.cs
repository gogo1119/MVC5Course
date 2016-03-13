using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : Controller
    {
        // GET: MB
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 使用簡單型別
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Birthday">The birthday.</param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult Index(string Name, DateTime Birthday)
        //{
        //    return Content(string.Format("{0} - {1}", Name, Birthday));
        //}

        [HttpPost]
        public ActionResult Index(MemberViewModel data)
        {
            return Content(string.Format("{0} - {1}", data.Name, data.Birthday));
        }

        /// <summary>
        /// 使用Request
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="Birthday">The birthday.</param>
        /// <returns></returns>
        //[HttpPost]
        //public ActionResult Index(int a)
        //{
        //    return Content(string.Format("{0} - {1}", Request.Form["Name"], Request.Form["Birthday"]));
        //}
    }
}