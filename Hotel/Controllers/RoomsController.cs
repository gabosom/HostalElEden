using HotelEden.Models;
using HotelEden.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelEden.Models
{
    public class RoomsController : Controller
    {
        //
        // GET: /Room/

        public ActionResult Reserve(RoomTypesReservationViewModel roomsCountDetails)
        {
            try{
                Reservation reservation = new Reservation();
                reservation.CheckInDate = roomsCountDetails.CheckInDate;
                reservation.CheckOutDate = roomsCountDetails.CheckOutDate;

                foreach(KeyValuePair<string, int> roomTypeCount in roomsCountDetails.GetSelectedRooms())
                {
                    for(int i = 0; i < roomTypeCount.Value; i++)
                    {
                        try
                        {
                            RoomTypes parsedRoomType = (RoomTypes)Enum.Parse(typeof(RoomTypes), roomTypeCount.Key);
                            RoomType roomTypeInReservation = RoomFactory.GetSpecificRoomType(parsedRoomType);
                            reservation.AddRoomToReservation(roomTypeInReservation);
                        }
                        catch(Exception e){
                            //TODO: handle exception
                        }
                    }
                }

                return View(reservation);
            }
            catch(Exception e)
            {
                //TODO:Exception stuff
                return View();
            }
            
            
        }

        public ActionResult Index()
        {
            //TODO: get room data from somewhere else           
            return View(RoomFactory.GetAllRooms());
        }

        public ActionResult Search(RoomTypesReservationViewModel reservationSearch)
        {
            if(ModelState.IsValid && reservationSearch.CheckInDate != null && reservationSearch.CheckOutDate != null)
            {
                RoomTypesReservationViewModel viewModel = new RoomTypesReservationViewModel
                {
                    CheckInDate = reservationSearch.CheckInDate,
                    CheckOutDate = reservationSearch.CheckOutDate,
                    DoubleMatrimonialCount = 0,
                    DoubleSimpleCount = 0,
                    MatrimonialAndSimpleCount = 0,
                    MatrimonialCount = 0,
                    QuadrupleSimpleCount = 0,
                    TripleSimpleCount = 0
                };

                ViewBag.AllRooms = RoomFactory.GetAllRooms();
                return View(viewModel);
            }
            else
            {
                //TODO: show errors
                return View("Index", reservationSearch);
            }
        }

        public ActionResult SubmitReserve(Reservation fullReservation)
        {
            if (ModelState.IsValid)
            {
                //complete roomtype information
                foreach (RoomType roomType in fullReservation.ReservedRoomTypes)
                    roomType.CompletePropertiesFromKeyword();


                //mandar email al hostal con la reservacion
                Emailer emailer = new Emailer();
                emailer.AddToDestinatary(Settings.HostalEmail);
                emailer.EmailSubject= "Reservacion de " + fullReservation.FirstName + " " + fullReservation.LastName;

                //Detalles del cliente
                emailer.AddLine("Nombre: " + fullReservation.FirstName + " " + fullReservation.LastName);
                emailer.AddLine("Email: " + fullReservation.Email);
                emailer.AddLine("Fecha de Llegada: " + fullReservation.CheckInDate.ToShortDateString());
                emailer.AddLine("Fecha de Salida: " + fullReservation.CheckOutDate.ToShortDateString());
                emailer.AddLine("Numero de noches: " + fullReservation.NumNights);
                emailer.AddLine("Total de habitaciones: " + fullReservation.ReservedRoomTypes.Count);
                emailer.AddHTML("<h3>Total: $" + fullReservation.TotalPrice + "</h3>");

                int count = 1;
                foreach(RoomType room in fullReservation.ReservedRoomTypes)
                {
                    emailer.AddHTML("<h3>Habitacion " + count++ + "</h3>");
                    emailer.AddLine("Tipo de habitacion: " + room.Title);
                    emailer.AddLine("Numero de huespedes: " + room.CurrentGuests);
                    emailer.AddHTML("<br/>");
                }

                emailer.SendEmail();
                return RedirectToAction("Success", fullReservation);
            }
            else
            {
                //TODO: handle error
                return RedirectToAction("Index");
            }
        }

        public ActionResult Success(Reservation successfulReservation)
        {

            return View(successfulReservation);
        }




        /****NO USE ***/
        //
        // GET: /Room/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Room/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Room/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Room/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Room/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Room/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Room/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
