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
                    Description = @"<p>Baños es de los lugares más hermosos para hacer paseos en caballo de todo el Ecuador. Encontrarán unas magníficas vistas de las cascadas a las faldas del Volcan Tungurahua. Estos paseos son fenomenales para los amantes de la naturaleza.</p><p>Duración: 2 horas</p>"
                },
                new AttractionViewModel{
                    Title = "Ziplining",
                    ImageURL = "ziplining.jpg", //http://commons.wikimedia.org/wiki/File:Zip-line_over_rainforest_canopy_4_January_2005,_Costa_Rica.jpg
                    Description = @"<p>Ziplining es una de las actividades más populares de baños que involucra cruzar 2000 metros colgado a diferentes velocidades y alturas. El canopy esta en Puntzan, que está aproximadamente a 10 minutos del centro de Baños y tendrá la oportunidad de ver increíbles paisajes y biodiversidad. Esta actividad se realiza con estándares de seguridad y nos aseguraremos de que sea increíble.</p>"
                },
                new AttractionViewModel{
                    Title = "Recorrer Banos en moto o go-kart",
                    ImageURL = "quadbike.jpg", //http://commons.wikimedia.org/wiki/File:Aeon_Cobra_220_ATV_Quad_bike.JPG
                    Description = "<p>Puede rentar una cuatri-moto o un kart para 2 personas para recorrer Baños y conocer hasta las más secretas partes de la ciudad.</p>"
                }
                ,new AttractionViewModel{
                    Title = "Rafting",
                    ImageURL = "rafting.jpg",
                    Description = "<p>Ecuador tiene una de las concentraciones más grandes de ríos en el mundo y un gran número de ellos desembocan en el Río Amazonas. A 15 minutos del centro de la ciudad va a encontrar uno de los rios mas claros y escénicos de la region para ir rio abajo y disfrutar de la naturaleza.</p>"
                }        
                ,new AttractionViewModel{
                    Title = "Pailon del Diablo",
                    ImageURL = "diablo_2.jpg",
                    Description = "<p>El Pailón del Diablo es una joya de cascada y se encuentra muy cerca de la ciudad. Al llegar al sitio, caminará 15 minutos para llegar a la cascada e inclusive caminara por unos caminos en forma de cuevas hasta encontrarse con la imponente cascada.</p>"
                }
                ,new AttractionViewModel{
                    Title = "Volcan Tungurahua",
                    ImageURL = "tungurahua.jpg", //http://commons.wikimedia.org/wiki/File:Equador_Tungurahua.JPG
                    Description = "<p>Puede realizar una caminata en uno de los volcanes mas grandes del mundo.</p>"
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

