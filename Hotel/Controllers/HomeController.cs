using HotelEden.Models;
using HotelEden.Utils;
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

        public ActionResult Banos()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
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

        [HttpGet]
        public ActionResult Contact()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel contact)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Emailer commentEmail = new Emailer();
                    commentEmail.AddToDestinatary(Settings.HostalEmail);
                    commentEmail.EmailSubject = "Comentario de: " + contact.Name;
                    commentEmail.AddLine("Nombre: " + contact.Name);
                    commentEmail.AddLine("Email: " + contact.Email);
                    commentEmail.AddLine("Commentario");
                    commentEmail.AddLine(contact.Comment);
                    commentEmail.SendEmail();

                    ViewBag.CommentSent = true;
                }
                catch(Exception e)
                {
                    //todo: catch exception
                }
            }
            return View();
        }

        public ActionResult Opcion2()
        {
            return View();
        }
    }
}

