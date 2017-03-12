using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyNureRulesApp.Models;
using System.Web.Security;

namespace ApplyNureRulesApp.Controllers
{
    public class AdminController : Controller
    {
        ApplyRulesDBEntities db = new Models.ApplyRulesDBEntities();
        // GET: Admin
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            string email = form["email"].ToString();
            string password = form["password"].ToString();

            var adm = (from u in db.Users
                       where u.email == email && u.password == password
                       select u).FirstOrDefault();

            if (adm != null)
            {
                //Create session
                FormsAuthentication.SetAuthCookie(adm.email, false);
                return RedirectToAction("Index", "Dashboard");
            }
            TempData["Message"] = "Email and password is wrong!";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}