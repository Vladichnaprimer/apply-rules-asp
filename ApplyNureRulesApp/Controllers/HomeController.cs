using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApplyNureRulesApp.Controllers
{
    public class HomeController : Controller
    {

        private Models.ApplyRulesDBEntities db = new Models.ApplyRulesDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Rules()
        {
            var content = db.Contents;
            return View(content);
        }
    }
}