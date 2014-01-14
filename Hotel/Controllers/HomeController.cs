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
                    Description = @"<p>Ba�os es de los lugares m�s hermosos para hacer paseos en caballo de todo el Ecuador. Encontrar�n unas magn�ficas vistas de las cascadas a las faldas del Volcan Tungurahua. Estos paseos son fenomenales para los amantes de la naturaleza.</p><p>Duraci�n: 2 horas</p>"
                },
                new AttractionViewModel{
                    Title = "Ziplining",
                    ImageURL = "ziplining.jpg", //http://commons.wikimedia.org/wiki/File:Zip-line_over_rainforest_canopy_4_January_2005,_Costa_Rica.jpg
                    Description = @"<p>Ziplining es una de las actividades m�s populares de ba�os que involucra cruzar 2000 metros colgado a diferentes velocidades y alturas. El canopy esta en Puntzan, que est� aproximadamente a 10 minutos del centro de Ba�os y tendr� la oportunidad de ver incre�bles paisajes y biodiversidad. Esta actividad se realiza con est�ndares de seguridad y nos aseguraremos de que sea incre�ble.</p>"
                },
                new AttractionViewModel{
                    Title = "Recorrer Banos en moto o go-kart",
                    ImageURL = "quadbike.jpg", //http://commons.wikimedia.org/wiki/File:Aeon_Cobra_220_ATV_Quad_bike.JPG
                    Description = "<p>Puede rentar una cuatri-moto o un kart para 2 personas para recorrer Ba�os y conocer hasta las m�s secretas partes de la ciudad.</p>"
                }
                ,new AttractionViewModel{
                    Title = "Rafting",
                    ImageURL = "rafting.jpg",
                    Description = "<p>Ecuador tiene una de las concentraciones m�s grandes de r�os en el mundo y un gran n�mero de ellos desembocan en el R�o Amazonas. A 15 minutos del centro de la ciudad va a encontrar uno de los rios mas claros y esc�nicos de la region para ir rio abajo y disfrutar de la naturaleza.</p>"
                }        
                ,new AttractionViewModel{
                    Title = "Pailon del Diablo",
                    ImageURL = "diablo_2.jpg",
                    Description = "<p>El Pail�n del Diablo es una joya de cascada y se encuentra muy cerca de la ciudad. Al llegar al sitio, caminar� 15 minutos para llegar a la cascada e inclusive caminara por unos caminos en forma de cuevas hasta encontrarse con la imponente cascada.</p>"
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

