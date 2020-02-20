using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using tp1e18.Models.DataModels;
using tp1e18.Models.ViewModels.Episode;

namespace tp1e18.Areas.Gestion.Controllers
{
    public class EpisodeController : Controller
    {
        Media database = new Media();
        // GET: Gestion/Episode
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return this.View(new CreateEpisode());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEpisode ce)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Episode episode = new Episode();
                    episode.Titre = ce.Titre;
                    episode.NoEpisode = ce.NoEpisode;
                    episode.Desc = ce.Desc;
                    episode.Duree = ce.Duree;
                    //episode.Saison = ce.Saison;
                    //episode.SaisonId = ce.SaisonId;

                    this.database.Episode.Add(episode);
                    this.database.SaveChanges();
                    if (ce.Cover != null && ce.Cover.ContentLength > 0)
                    {
                        ce.Cover.SaveAs(this.Server.MapPath(episode.Cover));
                    }
                    else
                    {
                        System.IO.File.Copy(this.Server.MapPath("/Content/Images/Saison/defaultcover.jpg"),
                                            this.Server.MapPath(episode.Cover));
                    }


                    return this.RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new CreateEpisode());
        }

        public ActionResult Edit(int id)
        {
            Episode episode = this.database.Episode.Find(id);
            if (episode == null)
            {
                return this.HttpNotFound();
            }
            return this.View(episode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Episode episode)
        {
            if (this.ModelState.IsValid)
            {
                Episode e = this.database.Episode.Find(episode.EpisodeId);
                e.Titre = episode.Titre;
                e.NoEpisode = episode.NoEpisode;
                e.Desc = episode.Desc;
                e.Duree = episode.Duree;
                e.Saison = episode.Saison;
                e.SaisonId = episode.SaisonId;
                this.database.SaveChanges();
                return this.RedirectToAction("Index");
            }
            return this.View(episode);
        }

        public ActionResult Delete(int id)
        {
            Episode episode = this.database.Episode.Find(id);
            if (episode == null)
            {
                return this.HttpNotFound();
            }
            return this.View(episode);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Episode episode = this.database.Episode.Find(id);
            this.database.Episode.Remove(episode);
            this.database.SaveChanges();
            System.IO.File.Delete(this.Server.MapPath(episode.Cover));
            return this.RedirectToAction("Index");
        }
    }
}