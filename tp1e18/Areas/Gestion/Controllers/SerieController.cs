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
                    s.NbrEpisodes = cs.NbrEpisodes;
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
            return this.View(new CreateSerie());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Serie serie = this.database.Serie.Find(id);
            if (serie == null)
            {
                return this.HttpNotFound();
            }
            EditSerie es = new EditSerie();
            es.EditSerieId = serie.SerieId;
            es.Annee = serie.Annee;
            es.Desc = serie.Desc;
            es.GuideParental = serie.GuideParental;
            es.GuideParentalId = serie.GuideParentalId;
            es.NbrEpisodes = serie.NbrEpisodes;
            es.Nom = serie.Nom;
            es.Studio = serie.Studio;
            es.StudioId = serie.StudioId;
            return this.View(es);
        }

        [HttpPost]
        public ActionResult Edit(EditSerie es)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Serie serie = this.database.Serie.Find(es.EditSerieId);
                    serie.Annee = es.Annee;
                    serie.Desc = es.Desc;
                    serie.GuideParental = es.GuideParental;
                    serie.GuideParentalId = es.GuideParentalId;
                    serie.NbrEpisodes = es.NbrEpisodes;
                    serie.Nom = es.Nom;
                    serie.Studio = es.Studio;
                    serie.StudioId = es.StudioId;
                    this.database.SaveChanges();
                    if (es.Cover != null && es.Cover.ContentLength > 0)
                    {
                        es.Cover.SaveAs(this.Server.MapPath(serie.CoverPath));
                    }
                    return this.RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new EditSerie());
        }

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