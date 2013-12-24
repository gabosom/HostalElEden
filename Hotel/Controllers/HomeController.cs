using HotelEden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelEden.Models
{
    public class HomeController : Controller
    {
        private IReservationRepository _reservationRepository;

        public HomeController()
        {
        }

        public HomeController(IReservationRepository reservationRepository)
        {
            this._reservationRepository = reservationRepository;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
