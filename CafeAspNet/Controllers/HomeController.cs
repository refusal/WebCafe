using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using CafeAspNet.Models;

namespace CafeAspNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var albums = GetTopSellingAlbums(5);

            return View(albums);
        }

        private List<Dish> GetTopSellingAlbums(int count)
        {
            return MusicStoreEntities.Dishs
            .OrderByDescending(a => a.OrderDetails?.Count())
            .Take(count)
            .ToList();
        }
    }
}
