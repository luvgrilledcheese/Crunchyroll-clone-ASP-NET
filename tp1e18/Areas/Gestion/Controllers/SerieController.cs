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
            return View(database.Serie);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View(new Serie());
        }
    }
}