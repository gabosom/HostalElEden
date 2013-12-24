using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelEden.Models;

namespace HotelEden.Areas.Admin.Controllers
{
    public class RoomTypeController : Controller
    {
        private HotelContext db = new HotelContext();

        //
        // GET: /Admin/RoomType/

        public ActionResult Index()
        {
            return View(db.RoomTypes.ToList());
        }

        //
        // GET: /Admin/RoomType/Details/5

        public ActionResult Details(int id = 0)
        {
            RoomType roomtype = db.RoomTypes.Find(id);
            if (roomtype == null)
            {
                return HttpNotFound();
            }
            return View(roomtype);
        }

        //
        // GET: /Admin/RoomType/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/RoomType/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoomType roomtype)
        {
            if (ModelState.IsValid)
            {
                db.RoomTypes.Add(roomtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomtype);
        }

        //
        // GET: /Admin/RoomType/Edit/5

        public ActionResult Edit(int id = 0)
        {
            RoomType roomtype = db.RoomTypes.Find(id);
            if (roomtype == null)
            {
                return HttpNotFound();
            }
            return View(roomtype);
        }

        //
        // POST: /Admin/RoomType/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoomType roomtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomtype);
        }

        //
        // GET: /Admin/RoomType/Delete/5

        public ActionResult Delete(int id = 0)
        {
            RoomType roomtype = db.RoomTypes.Find(id);
            if (roomtype == null)
            {
                return HttpNotFound();
            }
            return View(roomtype);
        }

        //
        // POST: /Admin/RoomType/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomType roomtype = db.RoomTypes.Find(id);
            db.RoomTypes.Remove(roomtype);
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