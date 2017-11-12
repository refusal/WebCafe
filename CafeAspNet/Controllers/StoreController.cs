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
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = MusicStoreEntities.Genres.ToList();

            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = MusicStoreEntities.Genres.FirstOrDefault(g => g.Name == genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var album = MusicStoreEntities.Dishs.FirstOrDefault(albumItem => albumItem.Id == id);

            return View(album);
        }

        //
        // GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = MusicStoreEntities.Genres.ToList();

            return PartialView(genres);
        }
    }
}
