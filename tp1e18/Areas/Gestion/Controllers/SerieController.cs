using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1e18.Models.DataModels;
using tp1e18.Models.ViewModels.Serie;

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
            return this.View(new CreateSerie());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSerie cs)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Serie s = new Serie();
                    s.Annee = cs.Annee;
                    s.Desc = cs.Desc;
                    s.GuideParental = cs.GuideParental;
                    s.GuideParentalId = cs.GuideParentalId;
                    s.NbrEpisodes = s.NbrEpisodes;
                    s.Nom = cs.Nom;
                    s.Studio = cs.Studio;
                    s.StudioId = cs.StudioId;
                    this.database.Serie.Add(s);
                    this.database.SaveChanges();

                    if (cs.Cover != null && cs.Cover.ContentLength > 0)
                    {
                        cs.Cover.SaveAs(this.Server.MapPath(s.CoverPath));
                    }
                    else
                    {
                        System.IO.File.Copy(this.Server.MapPath("/Content/Images/Serie/defaultcover.jpg"),
                                            this.Server.MapPath(s.CoverPath));
                    }
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
                database.Entry(serie).State = System.Data.Entity.EntityState.Deleted;
                // OR DO database.Serie.Remove(database.Serie.Find(serie.SerieId));
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