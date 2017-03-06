using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLocal.Models
{
    public class Address
    {
        public long id { get; set; }
        public long businessId { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string googleMapUrl { get; set; }
    }
}