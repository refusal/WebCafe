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
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var albums = MusicStoreEntities.Dishs;
            return View(albums.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Dish album = MusicStoreEntities.Dishs.FirstOrDefault(item => item.Id == id);
            return View(album);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(MusicStoreEntities.Genres, "GenreId", "Name");
            return View();
        }

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Dish album)
        {
            if (ModelState.IsValid)
            {
                MusicStoreEntities.Dishs.Add(album);
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(MusicStoreEntities.Genres, "GenreId", "Name", album.TypeId);
            return View(album);
        }

        //
        // GET: /StoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            Dish album = MusicStoreEntities.Dishs.FirstOrDefault(albumItem => albumItem.Id == id);
            ViewBag.GenreId = new SelectList(MusicStoreEntities.Genres, "GenreId", "Name", album.TypeId);
            return View(album);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Dish album)
        {
            ViewBag.GenreId = new SelectList(MusicStoreEntities.Genres, "GenreId", "Name", album.TypeId);
            return View(album);
        }

        //
        // GET: /StoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            Dish album = MusicStoreEntities.Dishs.FirstOrDefault(albumItem => albumItem.Id == id);
            return View(album);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Dish album = MusicStoreEntities.Dishs.FirstOrDefault(albumItem => albumItem.Id == id);
            MusicStoreEntities.Dishs.Remove(album);
            return RedirectToAction("Index");
        }
    }
}