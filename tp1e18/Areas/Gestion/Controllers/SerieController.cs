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
            return View(database.Serie.ToList());
        }

        public ActionResult Create()
        {
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
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new Serie());
        }

        //public ActionResult Edit(int id)
        //{
        //    Serie serie = this.database.Serie.Find(id);
        //    if (serie == null)
        //    {
        //        return this.HttpNotFound();
        //    }
        //    return this.View(serie);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Serie serie)
        //{
        //    if (this.ModelState.IsValid)
        //    {
        //        //this.db.Entry(etudiant).State = EntityState.Modified;
        //        var s = this.database.Serie.Find(serie.SerieId);
        //        s.Desc = serie.Nom;
        //        s.NbrEpisodes = serie.NbrEpisodes;
        //        s.Annee = serie.Annee;
        //        if (serie.Cover != null && serie.Cover.LongCount() > 0)
        //        {
        //        }
        //        this.database.SaveChanges();
        //        return this.RedirectToAction("Index");
        //    }
        //    return this.View(serie);
        //}

        public ActionResult Delete(int id)
        {
            Serie serie = this.database.Serie.Find(id);
            if (serie == null)
            {
                return this.HttpNotFound();
            }
            return this.View(serie);
        }

        [HttpPost]
        public ActionResult Delete(Serie serie)
        {
            try
            {
                this.database.Serie.Remove(serie);
                this.database.SaveChanges();
                //if (System.IO.File.Exists(this.Server.MapPath(serie.Cover)))
                //{
                //    System.IO.File.Delete(this.Server.MapPath(serie.Cover));
                //}
                return this.RedirectToAction("Index");
            }
            catch (Exception e)
            {
                this.ModelState.Clear();
                this.ModelState.AddModelError("", e.Message);
                return this.View(serie);
            }
        }
    }
}