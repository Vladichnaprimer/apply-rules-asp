using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplyNureRulesApp.Models;

namespace ApplyNureRulesApp.Controllers
{
    public class TermsController : Controller
    {
        ApplyRulesDBEntities db = new Models.ApplyRulesDBEntities();

        // GET: Terms
        [Authorize]
        public ActionResult Index()
        {
            var terms = (from t in db.Terms select t).ToList();
            return View(terms);
        }

        [Authorize]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            string termin = form["Title"].ToString();
            string definition = form["Description"].ToString();

            //TODO add checking list items

            Term term = new Term();

            term.AdminId = 1;
            term.Definition = definition;
            term.Term1 = termin;

            db.Terms.Add(term);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {

            var term = db.Contents.Where(x => x.Id == id).FirstOrDefault();
            return View(term);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int id = Convert.ToInt32(form["Id"].ToString());
            var term = db.Terms.Where(x => x.Id == id).FirstOrDefault();
            string termin = form["Title"].ToString();
            string definition = form["Description"].ToString();

            string title = form["Title"].ToString();
            string description = form["Description"].ToString();

            term.AdminId = 1;
            term.Definition = definition;
            term.Term1 = termin;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}