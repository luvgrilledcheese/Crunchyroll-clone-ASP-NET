using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1e18.Models.DataModels;

namespace tp1e18.Areas.Gestion.Controllers
{
    public class GenreController : Controller
    {
        //[Authorize(Users = "Admin")]
        private Media database = new Media();

        public ActionResult Index()
        {
            return View(database.Genre.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View(new Genre());
        }

        [HttpPost]
        public ActionResult Create(Genre g)
        {
            try 
            {
                if (this.ModelState.IsValid)
                {
                    this.database.Genre.Add(g);
                    this.database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
                else
                {
                    return this.View(g);
                }
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("", e.Message);
                return this.View(g);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Genre g = this.database.Genre.Find(id);
            if (g == null) 
            { 
                return this.HttpNotFound(); 
            }
            return this.View(g);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            try
            {
                if (this.ModelState.IsValid)
                {
                    Genre g = this.database.Genre.Find(genre.GenreId);

                    g.Nom = genre.Nom;
                    g.GenreId = g.GenreId;

                    this.database.SaveChanges();
                    return this.RedirectToAction("Index");
                }
                else
                {
                    return this.View(genre);
                }

            }
            catch (Exception e)  
            {
                this.ModelState.AddModelError("", e.Message);
                return this.View(e);
            }
        }

        public ActionResult Delete(int id)
        {
            Genre g = this.database.Genre.Find(id);
            if (g == null) { this.RedirectToAction("Index"); }
            return this.View(g);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(Genre g)
        {
            try
            {
                Genre Genre = this.database.Genre.Find(g.GenreId);
                this.database.Genre.Remove(Genre);
                this.database.SaveChanges();
                return this.RedirectToAction("Index");
            }
            catch (Exception e)
            {
                this.ModelState.AddModelError("", e.Message);
                return this.View(g);
            }
        }
    }
}