using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// The repo
        /// </summary>
        protected ProductRepository Repo = RepositoryHelper.GetProductRepository();

        /// <summary>
        /// 當要求符合這個控制器，但在控制器中找不到指定動作名稱的方法時呼叫。
        /// </summary>
        /// <param name="actionName">嘗試之動作的名稱。</param>
        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/").ExecuteResult(this.ControllerContext);
            //base.HandleUnknownAction(actionName);
        }
    }
}