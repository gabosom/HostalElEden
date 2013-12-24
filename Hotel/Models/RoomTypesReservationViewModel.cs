using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace HotelEden.Models
{
    public class RoomTypesReservationViewModel
    {
        private Dictionary<string, int> _AddedRooms { get; set; }

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public int MatrimonialCount { get; set; }
        public int DoubleSimpleCount  { get; set; }

        public int MatrimonialAndSimpleCount { get; set; }

        public int MatrimonialAndDoubleSimpleCount { get; set; }

        public int DoubleMatrimonialCount { get; set; }
        public int TripleSimpleCount { get; set; }

        public int QuadrupleSimpleCount { get; set; }

        public Dictionary<string, int> GetSelectedRooms()
        {
            Dictionary<string, int> selectedRooms = new Dictionary<string, int>();

            //navigate through its properties and add if >0
            foreach(PropertyInfo propertyInfo in this.GetType().GetProperties())
            {
                if(propertyInfo.Name.Contains("Count") && (int)propertyInfo.GetValue(this,null) > 0)
                {
                    string keywordValue = propertyInfo.Name.Replace("Count", "");
                    selectedRooms.Add(keywordValue, (int)propertyInfo.GetValue(this, null));
                }
            }
            return selectedRooms;
        }
    }
}