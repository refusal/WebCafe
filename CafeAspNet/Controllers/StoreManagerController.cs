using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeAspNet.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreManagerController : Controller
    {

        public ActionResult Index()
        {
            var dishs = CafeEntities.Dishs;
            return View(dishs.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ActionResult Details(int id)
        {
            Dish album = CafeEntities.Dishs.FirstOrDefault(item => item.Id == id);
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(CafeEntities.Genres, "GenreId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Dish album)
        {
            if (ModelState.IsValid)
            {
                CafeEntities.Dishs.Add(album);
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(CafeEntities.Genres, "GenreId", "Name", album.TypeId);
            return View(album);
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            Dish album = CafeEntities.Dishs.FirstOrDefault(albumItem => albumItem.Id == id);
            ViewBag.GenreId = new SelectList(CafeEntities.Genres, "GenreId", "Name", album.TypeId);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Dish album)
        {
            ViewBag.GenreId = new SelectList(CafeEntities.Genres, "GenreId", "Name", album.TypeId);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            Dish album = CafeEntities.Dishs.FirstOrDefault(albumItem => albumItem.Id == id);
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dish album = CafeEntities.Dishs.FirstOrDefault(albumItem => albumItem.Id == id);
            CafeEntities.Dishs.Remove(album);
            return RedirectToAction("Index");
        }
    }
}