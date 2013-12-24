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
    public class RoomController : Controller
    {
        private IRoomRepository _roomRepository { get; set; }

        public RoomController(IRoomRepository roomRepository)
        {
            this._roomRepository = roomRepository;
        }

        //
        // GET: /Admin/Room/

        public ActionResult Index()
        {
            return View(_roomRepository.GetAll());
        }

        //
        // GET: /Admin/Room/Details/5

        public ActionResult Details(int id = 0)
        {
            return View(_roomRepository.Get(id));
        }

        //
        // GET: /Admin/Room/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Room/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Add(room);
                return RedirectToAction("Index");
            }

            return View(room);
        }

        //
        // GET: /Admin/Room/Edit/5

        public ActionResult Edit(int id = 0)
        {
            return View(_roomRepository.Get(id));
        }

        //
        // POST: /Admin/Room/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                _roomRepository.Edit(room);
                return RedirectToAction("Index");
            }
            return View(room);
        }

        //
        // GET: /Admin/Room/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Room room = _roomRepository.Get(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // POST: /Admin/Room/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _roomRepository.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _roomRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}