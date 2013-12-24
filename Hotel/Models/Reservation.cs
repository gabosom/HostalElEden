using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelEden.Models
{

    #region Interfaces
    public interface IReservationRepository
    {
        Reservation Add(Reservation reservation);
        IQueryable<Reservation> GetAll();
        Reservation Get(int id);
        Reservation Edit(Reservation reservation);
        void Delete(int id);
        void Dispose();
        //List<RoomType> SearchAvailabity(DateTime CheckInDate, DateTime CheckOutDate, int NumPeople);
    }

    #endregion

    public class ReservationRepository : IReservationRepository
    {
        
        private HotelContext _db { get; set; }

        public ReservationRepository()
            : this(new HotelContext())
        { }

        public ReservationRepository(HotelContext db)
        { 
            _db = db; 
        }

        public Reservation Add(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
            return reservation;
        }

        public IQueryable<Reservation> GetAll()
        {
            return _db.Reservations.Include("Room");
        }

        public Reservation Get(int id)
        {
            return _db.Reservations.SingleOrDefault(r => r.Id == id);
        }

        public Reservation Edit(Reservation reservation)
        {
            _db.Entry(reservation).State = System.Data.EntityState.Modified;
            _db.SaveChanges();
            return reservation;
        }

        public void Delete(int id)
        {
            Reservation res = _db.Reservations.SingleOrDefault(r => r.Id == id);
            _db.Reservations.Remove(res);
            _db.SaveChanges();
        }

        //public List<RoomType> SearchAvailabity(DateTime CheckInDate, DateTime CheckOutDate, int NumPeople)
        //{
        //    //get rooms that are available and can fit the number of people
        //    List<RoomType> RoomTypesOccupied = (from reservation in _db.Reservations
        //                                        where 
        //                                        //find overlap with ending
        //                                        (CheckOutDate > reservation.CheckInDate && CheckOutDate <= reservation.CheckOutDate)
        //                                        ||
        //                                        //find overlap with beginning
        //                                        (CheckInDate < reservation.CheckOutDate && CheckInDate >= reservation.CheckInDate)
        //                                        //find outer overlaps overlaps, innver overlaps are take care of with both above
        //                                        ||
        //                                        (CheckInDate <= reservation.CheckInDate && CheckOutDate >= reservation.CheckOutDate)
        //                                   select reservation.Room.RoomType).Distinct().ToList();

        //    //room types that can fit that many people
        //    List<RoomType> RoomTypesAvailable = (from roomType in _db.RoomTypes
        //                                             where roomType.MaxGuestNo >= NumPeople
        //                                             select roomType).ToList();

        //    return RoomTypesAvailable.Except(RoomTypesOccupied).ToList();
        //}

        public void Dispose()
        {
            _db.Dispose();
        }
    }

    public class Reservation
    {
        

        public int Id { get; set; }

        [Required(ErrorMessageResourceName = "ValidationRequiredFirstName", ErrorMessageResourceType = typeof(SpanishResources))]
        public string FirstName { get; set; }
        [Required(ErrorMessageResourceName = "ValidationRequiredLastName", ErrorMessageResourceType = typeof(SpanishResources))]
        public string LastName { get; set; }
        [Required(ErrorMessageResourceName = "ValidationRequiredEmail", ErrorMessageResourceType = typeof(SpanishResources))]
        [EmailAddress(ErrorMessageResourceName = "ValidationIncorrectEmail", ErrorMessageResourceType = typeof(SpanishResources), ErrorMessage = null)] //aha: http://stackoverflow.com/questions/12474876/either-errormessagestring-or-errormessageresourcename-must-be-set-but-not-both
        public string Email { get; set; }
        public DateTime ReservedDate { get; set; }
        public int NumNights { get; set; }
        public int NumGuests { get; set; }
        [Required(ErrorMessageResourceName = "ValidationRequiredCheckInDate", ErrorMessageResourceType=typeof(SpanishResources))]
        public DateTime CheckInDate { get; set; }
        [Required(ErrorMessageResourceName = "ValidationRequiredCheckOutDate", ErrorMessageResourceType = typeof(SpanishResources))]
        public DateTime CheckOutDate { get; set; }
        public double TotalPrice { get; set; }

        public List<RoomType> ReservedRoomTypes { get; set; }

        public Reservation()
        {
            this.TotalPrice = 0;
            this.ReservedRoomTypes = new List<RoomType>();
        }
        public void AddRoomToReservation(RoomType room)
        {
            this.ReservedRoomTypes.Add(room);
        }
    }
}