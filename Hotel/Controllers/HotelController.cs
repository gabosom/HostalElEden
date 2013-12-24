using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelEden.Models;

namespace HotelEden.Models
{
    public class HotelController : Controller
    {
        private HotelContext db = new HotelContext();

        //
        // GET: /Hotel/

        public ActionResult Index()
        {
            return View(db.Hotels.ToList());
        }

        //
        // GET: /Hotel/Details/5

        public ActionResult Details(int id = 0)
        {
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        //
        // GET: /Hotel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hotel/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel);
        }

        //
        // GET: /Hotel/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        //
        // POST: /Hotel/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel);
        }

        //
        // GET: /Hotel/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        //
        // POST: /Hotel/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}