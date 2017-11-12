using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeAspNet.Models;

namespace CafeAspNet.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            var genres = CafeEntities.Genres.ToList();

            return View(genres);
        }

        public ActionResult Details(int id)
        {
            var album = CafeEntities.Genres.First(type => type.Id == id).Dishs;

            return View(album);
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = CafeEntities.Genres.ToList();

            return PartialView(genres);
        }
    }
}
