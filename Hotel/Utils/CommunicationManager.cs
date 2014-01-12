using HotelEden.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEden.Utils
{
    public class CommunicationManager
    {
        public void SendReservationToHotel(Reservation reservation)
        {
            //complete roomtype information
            foreach (RoomType roomType in reservation.ReservedRoomTypes)
                roomType.CompletePropertiesFromKeyword();


            //mandar email al hostal con la reservacion
            Emailer emailer = new Emailer();
            emailer.AddToDestinatary(Settings.HostalEmail);
            emailer.EmailSubject = "Reservacion de " + reservation.FirstName + " " + reservation.LastName;

            //Detalles del cliente
            emailer.AddLine("Nombre: " + reservation.FirstName + " " + reservation.LastName);
            emailer.AddLine("Email: " + reservation.Email);
            emailer.AddLine("Fecha de Llegada: " + reservation.CheckInDate.ToShortDateString());
            emailer.AddLine("Fecha de Salida: " + reservation.CheckOutDate.ToShortDateString());
            emailer.AddLine("Numero de noches: " + reservation.NumNights);
            emailer.AddLine("Total de habitaciones: " + reservation.ReservedRoomTypes.Count);
            emailer.AddHTML("<h3>Total: $" + reservation.TotalPrice + "</h3>");

            int count = 1;
            foreach (RoomType room in reservation.ReservedRoomTypes)
            {
                emailer.AddHTML("<h3>Habitacion " + count++ + "</h3>");
                emailer.AddLine("Tipo de habitacion: " + room.Title);
                emailer.AddLine("Numero de huespedes: " + room.CurrentGuests);
                emailer.AddHTML("<br/>");
            }

            emailer.SendEmail();
        }

        internal void SendReservationToGuest(Reservation reservation)
        {
            //complete roomtype information
            foreach (RoomType roomType in reservation.ReservedRoomTypes)
                roomType.CompletePropertiesFromKeyword();


            //mandar email al hostal con la reservacion
            Emailer emailer = new Emailer();
            emailer.AddToDestinatary(Settings.HostalEmail);
            emailer.EmailSubject = SpanishResources.HotelName + " - Reservacion de " + reservation.FirstName + " " + reservation.LastName;

            //Detalles del cliente
            emailer.AddHTML("<p>Se ha enviado la siguiente reservacion a nuestro staff. Nos pondremos en contacto con usted en la brevedad posible.</p> <br /><hr /><br />");
            emailer.AddLine("Nombre: " + reservation.FirstName + " " + reservation.LastName);
            emailer.AddLine("Email: " + reservation.Email);
            emailer.AddLine("Fecha de Llegada: " + reservation.CheckInDate.ToShortDateString());
            emailer.AddLine("Fecha de Salida: " + reservation.CheckOutDate.ToShortDateString());
            emailer.AddLine("Numero de noches: " + reservation.NumNights);
            emailer.AddLine("Total de habitaciones: " + reservation.ReservedRoomTypes.Count);
            emailer.AddHTML("<h3>Total: $" + reservation.TotalPrice + "</h3>");

            int count = 1;
            foreach (RoomType room in reservation.ReservedRoomTypes)
            {
                emailer.AddHTML("<h3>Habitacion " + count++ + "</h3>");
                emailer.AddLine("Tipo de habitacion: " + room.Title);
                emailer.AddLine("Numero de huespedes: " + room.CurrentGuests);
                emailer.AddHTML("<br/>");
            }

            emailer.SendEmail();
        }
    }
}