using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        [AllowAnonymous]
        // GET: Member
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ChekcLogin(login.Email, login.Password))
            {
                FormsAuthentication.RedirectFromLoginPage(login.Email, login.RememberMe);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤");

            return View();
        }

        private bool ChekcLogin(string email, string password)
        {
            return (
                email == "gogo1119@gmail.com" && password == "123"
                );
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}