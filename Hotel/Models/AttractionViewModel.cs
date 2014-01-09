using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelEden.Models
{
    public class AttractionViewModel
    {
        private string _ImageURL { get; set; }
        public string Title { get; set; }
        public string ImageURL
        {
            get
            {
                return this._ImageURL;
            }
            set
            {
                this._ImageURL = "/Content/" + value;
            }
        }
        public string Description { get; set; }
    }
}