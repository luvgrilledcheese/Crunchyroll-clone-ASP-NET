﻿using System;
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

        // GET: Gestion/Saison
        public ActionResult Index()
        {
            return View(database.Episode);
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
                    episode.NoEpisode = ce.NoEpisode;
                    episode.Saison = ce.Saison;
                    episode.SaisonId = ce.SaisonId;
                    episode.Titre = ce.Titre;
                    episode.Duree = ce.Duree; //i wanna kms for a 2nd time, maybe i should sleep
                    episode.Desc = ce.Desc;
                    episode.Duree = ce.Duree;
                    episode.Saison = ce.Saison;
                    episode.SaisonId = ce.SaisonId;

                    this.database.Episode.Add(episode);
                    this.database.SaveChanges();
                    if (ce.Cover != null && ce.Cover.ContentLength > 0)
                    {
                        ce.Cover.SaveAs(this.Server.MapPath(episode.CoverPath));
                    }
                    else
                    {
                        System.IO.File.Copy(this.Server.MapPath("/Content/Images/Episode/defaultcover.jpg"),
                                            this.Server.MapPath(episode.Cover));
                    }

                    if (ce.Video != null && ce.Video.ContentLength > 0)
                    {
                        ce.Video.SaveAs(this.Server.MapPath(episode.Video));
                    }
                    else
                    {
                        System.IO.File.Copy(this.Server.MapPath("/Content/Videos/defaultvideo.mp4"),
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Episode episode = this.database.Episode.Find(id);
            if (episode == null)
            {
                return this.HttpNotFound();
            }

            EditEpisode ee = new EditEpisode();
            ee.Titre = episode.Titre;
            ee.EditEpisodeId = episode.EpisodeId;
            ee.Desc = episode.Desc;
            ee.Duree = episode.Duree;
            ee.NoEpisode = episode.NoEpisode;
            ee.Saison = episode.Saison;
            ee.SaisonId= episode.SaisonId;
            return this.View(ee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEpisode ee)
        {
            if (this.ModelState.IsValid)
            {
                try
                {
                    Episode episode = this.database.Episode.Find(ee.EditEpisodeId);
                    episode.Titre = ee.Titre;
                    episode.Desc = ee.Desc;
                    episode.Duree = ee.Duree;
                    episode.NoEpisode = ee.NoEpisode;
                    episode.Saison = ee.Saison;
                    episode.SaisonId = ee.SaisonId;
                    this.database.SaveChanges();
                    if (ee.Cover != null && ee.Cover.ContentLength > 0)
                    {
                        ee.Cover.SaveAs(this.Server.MapPath(episode.Cover));
                    }
                    return this.RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    this.ModelState.AddModelError("", e.Message);
                }
            }
            return this.View(new EditEpisode());
        }


        public ActionResult Delete(int id)
        {
            Episode episode = this.database.Episode.Find(id);
            if (episode == null)
            {
                this.RedirectToAction("Index");
            }
            return this.View(episode);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Delete(Episode e)
        {
            Episode varEpisode = this.database.Episode.Find(e.EpisodeId);
            this.database.Episode.Remove(varEpisode);
            this.database.SaveChanges();
            System.IO.File.Delete(this.Server.MapPath(varEpisode.Cover));
            return this.RedirectToAction("Index");
        }
    }
}