using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyNureRulesApp.Models;
using System.Web.UI.HtmlControls;

namespace ApplyNureRulesApp.Controllers
{
    public class DashboardController : Controller
    {
        ApplyRulesDBEntities db = new Models.ApplyRulesDBEntities();

        // GET: Dashboard
        [Authorize]
        public ActionResult Index()
        {
            //var content = (from cont in db.Contents
            //               join us in db.UserCategories
            //                on cont.CategoryId equals us.Id
            //               select new { cont.Title, cont.Description, catTitile = us.Title }).ToList();

            var content = (from cont in db.Contents select cont).ToList();
            return View(content);
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            string title = form["Title"].ToString();
            string description = form["Description"].ToString();

            //TODO add checking list items

            Content content = new Content();

            content.AdminId = 1;
            content.CategoryId = 1;
            content.Description = description;
            content.Title = title;

            db.Contents.Add(content);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        public ActionResult Edit(int id) {

            var content = db.Contents.Where(x => x.Id == id).FirstOrDefault();
            return View(content);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(form["Id"].ToString());
            var content = db.Contents.Where(x => x.Id == id).FirstOrDefault();

            string title = form["Title"].ToString();
            string description = form["Description"].ToString();

            content.AdminId = 1;
            content.CategoryId = 1;
            content.Description = description;
            content.Title = title;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}