using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1e18.Models.DataModels;

namespace tp1e18.Areas.Gestion.Controllers
{
    public class SerieGenreController : Controller
    {
        Media database = new Media();
        // GET: Gestion/SerieGenre
        public ActionResult Index()
        {
            return this.View(this.database.Serie.ToList());
        }

        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(int SerieId, int GenreId)
        {
            try
            {
                Serie s = this.database.Serie.Find(SerieId);
                Genre g = this.database.Genre.Find(GenreId);
                s.Genres.Add(g);
                this.database.SaveChanges();
            }
            catch (Exception)
            {
                this.ModelState.AddModelError("", "Ce genre est deja dans la serie.");
            }
            return this.RedirectToAction(actionName: "Index", controllerName: "SerieGenre", routeValues: new { area = "Gestion" });
        }

        [HttpGet]
        public ActionResult Delete(int SerieId, int GenreId)
        {
            Serie s = this.database.Serie.Find(SerieId);
            Genre g = this.database.Genre.Find(GenreId);
            s.Genres.Remove(g);
            this.database.SaveChanges();
            return this.RedirectToAction(actionName:"Index", controllerName:"SerieGenre", routeValues: new { area = "Gestion" });
        }
    }
}