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
                        cs.Cover.SaveAs(this.Server.MapPath(saison.Cover));
                    }
                    else
                    {
                        System.IO.File.Copy(this.Server.MapPath("/Content/Images/Saison/defaultcover.jpg"),
                                            this.Server.MapPath(saison.Cover));
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

        public ActionResult Edit(int id)
        {
            Saison saison = this.database.Saison.Find(id);
            if (saison == null)
            {
                return this.HttpNotFound();
            }
            return this.View(saison);
        }


        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Saison saison)
        {
            this.database.Saison.Remove(saison);
            this.database.SaveChanges();
            System.IO.File.Delete(this.Server.MapPath(saison.Cover));
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Saison saison)
        {
            if (this.ModelState.IsValid)
            {
                Saison s = this.database.Saison.Find(saison.SaisonId);
                s.SaisonId = saison.SaisonId;
                s.NoSaison = saison.NoSaison;
                s.Serie = saison.Serie;
                s.SerieId = saison.SerieId;
                this.database.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(saison);
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
                if (System.IO.File.Exists(this.Server.MapPath(varSaison.Cover)))
                {
                    System.IO.File.Delete(this.Server.MapPath(varSaison.Cover));
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