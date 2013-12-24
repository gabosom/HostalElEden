using HotelEden.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace HotelEden.Models
{
    //http://net.tutsplus.com/tutorials/building-an-asp-net-mvc4-application-with-ef-and-webapi/

    #region Interfaces
    public interface IRoomRepository
    {
        Room Add(Room room);
        IQueryable<Room> GetAll();
        Room Get(int id);
        Room Edit(Room room);
        void Delete(int id);
        void Dispose();
    }

    #endregion

    #region Repositories
    public class RoomRepository : IRoomRepository, IDisposable
    {
        private HotelContext _db { get; set; }

        public RoomRepository()
            : this(new HotelContext())
        { }

        public RoomRepository(HotelContext db)
        { 
            _db = db; 
        }

        public Room Add(Room room)
        {
            _db.Rooms.Add(room);
            _db.SaveChanges();
            return room;
        }

        public IQueryable<Room> GetAll()
        {
            return _db.Rooms.Include("RoomType");
        }

        /// <summary>
        /// Returns List of SelectListItems for available rooms. Useful when creating dropdowns for options
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SelectListItem> GetAvailableRoomsAsListItems()
        {
            IQueryable<Room> rooms = GetAll();
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (Room r in rooms)
            {
                list.Add(new SelectListItem
                {
                    Text="" + r.RoomNumber,
                    Value= "" + r.Id
                });
            }

            return list;
        }

        public Room Get(int id)
        {
            return _db.Rooms.Include("RoomType").SingleOrDefault(r => r.Id == id);
        }

        public Room Edit(Room room)
        {
            _db.Entry(room).State = System.Data.EntityState.Modified;
            _db.SaveChanges();
            return room;
        }

        public void Delete(int id)
        {
            Room room = _db.Rooms.SingleOrDefault(r => r.Id == id);
            _db.Rooms.Remove(room);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            this._db.Dispose();
            
        }
    }

    public class RoomTypeRepository : IDisposable
    {
        private HotelContext _db { get; set; }

        public RoomTypeRepository()
            : this(new HotelContext())
        { }

        public RoomTypeRepository(HotelContext db)
        {
            _db = db;
        }

        public RoomType Add(RoomType roomType)
        {
            _db.RoomTypes.Add(roomType);
            _db.SaveChanges();
            return roomType;
        }

        public IQueryable<RoomType> GetAll()
        {
            return _db.RoomTypes;
        }

        public IEnumerable<SelectListItem> GetAllAsSelectListItems()
        {
            IQueryable<RoomType> allRoomTypes = _db.RoomTypes.AsQueryable();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (RoomType rt in allRoomTypes)
                list.Add(new SelectListItem
                {
                    Text=rt.Description,
                    Value="" + rt.Id
                });
            return list;
        }

        public RoomType Get(int id)
        {
            return _db.RoomTypes.SingleOrDefault(r => r.Id == id);
        }

        public RoomType Edit(RoomType roomType)
        {
            _db.Entry(roomType).State = System.Data.EntityState.Modified;
            _db.SaveChanges();
            return roomType;
        }

        public void Delete(int id)
        {
            RoomType roomType = _db.RoomTypes.SingleOrDefault(r => r.Id == id);
            _db.RoomTypes.Remove(roomType);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            this._db.Dispose();

        }
    }

    #endregion
        
    #region Classes
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }

        //Relationships
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
    

    public class RoomType
    {
        private string _ImageURL;
        private string _ThumbURL;

        //Rate is per person
        public int Id { get; set; }
        public double Rate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public int MaxGuestNo { get; set; }
        public string URL { get; set; }

        public string Keyword { get; set; }

        public int CurrentGuests { get; set; }

        public string ImageURL
        {
            get {
                return this._ImageURL;
            }
            set {
                this._ImageURL = "/Content/"+ value;
            } 
        }

        public string ThumbURL
        {
            get
            {
                return this._ThumbURL;
            }
            set
            {
                this._ThumbURL = "/Content/" + value;
            }
        }

        public void CompletePropertiesFromKeyword()
        {
            RoomType tmpRoom = RoomFactory.GetSpecificRoomType(this.Keyword);

            foreach(PropertyInfo propertyInfo in typeof(RoomType).GetProperties())
            {
                //current guests is per reservation and shouldn't be overriden
                if (propertyInfo.Name != "CurrentGuests")
                    propertyInfo.SetValue(this, propertyInfo.GetValue(tmpRoom));
            }
        }
    }
    #endregion
}