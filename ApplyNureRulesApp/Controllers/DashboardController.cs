using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyNureRulesApp.Models;
using System.Web.UI.HtmlControls;
using System.Net;

namespace ApplyNureRulesApp.Controllers
{
    public class DashboardController : Controller
    {
        ApplyRulesDBEntities db = new Models.ApplyRulesDBEntities();

        // GET: Dashboard
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Index()
        {
            //var content = (from cont in db.Contents
            //               join us in db.UserCategories
            //                on cont.CategoryId equals us.Id
            //               select new { cont.Title, cont.Description, catTitile = us.Title }).ToList();

            var content = (from cont in db.Contents select cont).ToList();
            return View(content);
        }

        [ChildActionOnly]
        public ActionResult FormOptions(int categoryId = 0)
        {
            var Items = db.UserCategories;
            string str = "";
            foreach (var item in Items)
            {
                if (categoryId == item.Id)
                {
                    str += "<option value=" + item.Id + " selected>" + item.Title + "</option>";
                }
                else
                {
                    str += "<option value=" + item.Id + " >" + item.Title + "</option>";
                }
            }
            return Content(str);
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
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

            var content = db.Contents.Find(id);
            return View(content);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(form["Id"].ToString());
            var content = db.Contents.Where(x => x.Id == id).FirstOrDefault();

            string title = form["Title"].ToString();
            string description = form["Description"].ToString();

            content.AdminId = 1;
            content.Description = description;
            content.Title = title;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }

            db.Contents.Remove(content);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}