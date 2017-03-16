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
        [ValidateInput(false)]
        public ActionResult Terms()
        {
            var term = db.Terms;
            return View(term);
        }

        public ActionResult School() {
            var content = (from cont in db.Contents
                           where cont.CategoryId == 1
                           select cont).ToList();
            return View(content);
        }

        public ActionResult College()
        {
            var content = (from cont in db.Contents
                           where cont.CategoryId == 2
                           select cont).ToList();
            return View(content);
        }

        public ActionResult Bachelor()
        {
            var content = (from cont in db.Contents
                           where cont.CategoryId == 3
                           select cont).ToList();
            return View(content);
        }

        public ActionResult Master()
        {
            var content = (from cont in db.Contents
                           where cont.CategoryId == 4
                           select cont).ToList();
            return View(content);
        }
        
        public ActionResult Redemption()
        {
            var content = (from cont in db.Contents
                           where cont.CategoryId == 5
                           select cont).ToList();
            return View(content);
        }

    }
}