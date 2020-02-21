using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1e18.Models.DataModels;
using tp1e18.Models.ViewModels.Saison;

namespace tp1e18.Areas.Gestion.Controllers
{
    public class SaisonController : Controller
    {
        Media database = new Media();

        // GET: Gestion/Saison
        public ActionResult Index()
        {
            return View(database.Saison);
        }

        public ActionResult Create()
        {
            return this.View(new CreateSaison());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSaison cs)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Saison saison = new Saison();
                    saison.NoSaison = cs.NoSaison;
                    saison.Serie = cs.Serie;
                    saison.SerieId = cs.SerieId;
                    this.database.Saison.Add(saison);
                    this.database.SaveChanges();
                    if (cs.Cover != null && cs.Cover.ContentLength > 0)
                    {
                        cs.Cover.SaveAs(this.Server.MapPath(saison.CoverPath));
                    }
                    else
                    {
                        System.IO.File.Copy(this.Server.MapPath("/Content/Images/Saison/defaultcover.jpg"),
                                            this.Server.MapPath(saison.CoverPath));
                    }
                    return this.RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new CreateSaison());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Saison saison = this.database.Saison.Find(id);
            if (saison == null)
            {
                return this.HttpNotFound();
            }
            EditSaison es = new EditSaison();
            es.EditSaisonId = saison.SaisonId;
            es.NoSaison = saison.NoSaison;
            es.Serie = saison.Serie;
            es.SerieId = saison.SerieId;
            return this.View(es);
        }

        [HttpPost]
        public ActionResult Edit(EditSaison es)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Saison saison = this.database.Saison.Find(es.EditSaisonId);
                    saison.NoSaison = es.NoSaison;
                    saison.Serie = es.Serie;
                    saison.SerieId = es.SerieId;
                    this.database.SaveChanges();
                    if (es.Cover != null && es.Cover.ContentLength > 0)
                    {
                        es.Cover.SaveAs(this.Server.MapPath(saison.CoverPath));
                    }
                    return this.RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new EditSaison());
        }

        public ActionResult Delete(int id)
        {
            Saison saison = this.database.Saison.Find(id);
            if (saison == null)
            {
                this.RedirectToAction("Index");
            }
            return this.View(saison);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(Saison s)
        {
            try
            {
                Saison varSaison = this.database.Saison.Find(s.SaisonId);
                this.database.Saison.Remove(varSaison);
                if (System.IO.File.Exists(this.Server.MapPath(varSaison.CoverPath)))
                {
                    System.IO.File.Delete(this.Server.MapPath(varSaison.CoverPath));
                }
                this.database.SaveChanges();
                
                return this.RedirectToAction("Index");
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("", e.Message);
                return this.View(s);
            }

        }
    }
}