using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1e18.Models.DataModels;

namespace tp1e18.Areas.Gestion.Controllers
{
    public class SerieController : Controller
    {
        Media database = new Media();

        // GET: Gestion/Serie
        public ActionResult Index()
        {
            return View(database.Serie);
        }

        public ActionResult Create(){
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Serie Serie)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    this.database.Serie.Add(Serie);
                    this.database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
                catch (Exception e) {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new Serie());
        }




    }
}