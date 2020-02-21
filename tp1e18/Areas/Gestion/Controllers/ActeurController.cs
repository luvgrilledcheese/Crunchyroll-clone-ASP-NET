using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1e18.Models.DataModels;
using tp1e18.Models.ViewModels.Acteur;

namespace tp1e18.Areas.Gestion.Controllers
{
    public class ActeurController : Controller
    {
        Media database = new Media();

        // GET: Gestion/Acteur
        public ActionResult Index()
        {
            return View(database.Acteur);
        }

        public ActionResult Create()
        {
            return this.View(new CreateActeur());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateActeur ca)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Acteur acteur = new Acteur();
                    acteur.Nom = ca.Nom;
                    acteur.Prenom = ca.Prenom;
                    acteur.Personnage = ca.Personnage;
                    this.database.Acteur.Add(acteur);
                    this.database.SaveChanges();

                    if (ca.Cover != null && ca.Cover.ContentLength > 0)
                    {
                        ca.Cover.SaveAs(this.Server.MapPath(acteur.CoverPath));
                    }
                    else
                    {
                        System.IO.File.Copy(this.Server.MapPath("/Content/Images/Acteur/defaultcover.jpg"),
                                            this.Server.MapPath(acteur.CoverPath));
                    }
                    return this.RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new CreateActeur());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Acteur acteur = this.database.Acteur.Find(id);
            if (acteur == null)
            {
                return this.HttpNotFound();
            }
            EditActeur ea = new EditActeur();
            ea.EditActeurId = acteur.ActeurId;
            ea.Nom = acteur.Nom;
            ea.Prenom = acteur.Prenom;
            ea.Personnage = acteur.Personnage;
            return this.View(ea);
        }

        [HttpPost]
        public ActionResult Edit(EditActeur ea)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Acteur acteur = this.database.Acteur.Find(ea.EditActeurId);
                    acteur.Nom = ea.Nom;
                    acteur.Prenom = ea.Prenom;
                    acteur.Personnage = ea.Personnage;
                    this.database.SaveChanges();
                    if (ea.Cover != null && ea.Cover.ContentLength > 0)
                    {
                        ea.Cover.SaveAs(this.Server.MapPath(acteur.CoverPath));
                    }
                    return this.RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new EditActeur());
        }

        public ActionResult Delete(int id)
        {
            Acteur acteur = this.database.Acteur.Find(id);
            if (acteur == null)
            {
                this.RedirectToAction("Index");
            }
            return this.View(acteur);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(Acteur a)
        {
            try
            {
                Acteur varActeur = this.database.Acteur.Find(a.ActeurId);
                this.database.Acteur.Remove(varActeur);
                if (System.IO.File.Exists(this.Server.MapPath(varActeur.CoverPath)))
                {
                    System.IO.File.Delete(this.Server.MapPath(varActeur.CoverPath));
                }
                this.database.SaveChanges();

                return this.RedirectToAction("Index");
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("", e.Message);
                return this.View(a);
            }

        }
    }
}