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
            List<AttractionViewModel> thingsToDo = new List<AttractionViewModel>
            {
                new AttractionViewModel{
                    Title = "Paseos en caballo",
                    ImageURL = "horsebackriding.jpg",
                    Description = SpanishResources.BanosHorsebackRiding
                },
                new AttractionViewModel{
                    Title = "Ziplining",
                    ImageURL = "ziplining.jpg", //http://commons.wikimedia.org/wiki/File:Zip-line_over_rainforest_canopy_4_January_2005,_Costa_Rica.jpg
                    Description = SpanishResources.BanosZiplining
                },
                new AttractionViewModel{
                    Title = "Recorrer Baños en moto o go-kart",
                    ImageURL = "quadbike.jpg", //http://commons.wikimedia.org/wiki/File:Aeon_Cobra_220_ATV_Quad_bike.JPG
                    Description = SpanishResources.BanosMoto
                }
                ,new AttractionViewModel{
                    Title = "Rafting",
                    ImageURL = "rafting.jpg",
                    Description = SpanishResources.BanosRafting
                }        
                ,new AttractionViewModel{
                    Title = "Pailon del Diablo",
                    ImageURL = "diablo_2.jpg",
                    Description = SpanishResources.BanosPailonDelDiablo
                }
                ,new AttractionViewModel{
                    Title = "Volcan Tungurahua",
                    ImageURL = "tungurahua.jpg", //http://commons.wikimedia.org/wiki/File:Equador_Tungurahua.JPG
                    Description = SpanishResources.BanosTungurahua
                }
            };

            return View(thingsToDo);
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

