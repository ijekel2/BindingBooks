﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BindingBooks.Models;

namespace BindingBooks.Controllers
{
    public class GenreController : Controller
    {
        private ApplicationDbContext db;

        public GenreController()
        {
            db = new ApplicationDbContext();
            
        }
        
        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            
            return View(genre);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            
            return View(genre);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Genre genre = db.Genres.Find(id);

            if (genre == null)
            {
                return HttpNotFound();
            }
            
            return View(genre);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }


        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}