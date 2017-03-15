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
        [ValidateInput(false)]
        public ActionResult Rules()
        {
            var content = db.Contents;
            return View(content);
        }

        public ActionResult Terms()
        {
            var term = db.Terms;
            return View(term);
        }
    }
}