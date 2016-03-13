using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    internal class ExecuteTimeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.StartTime = DateTime.Now;
            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            TimeSpan ts = (DateTime.Now - filterContext.Controller.ViewBag.StartTime);
            filterContext.Controller.ViewBag.Message = "Your application description page. ("+ ts.TotalSeconds + " sec)";

            base.OnActionExecuted(filterContext);
        }
    }
}