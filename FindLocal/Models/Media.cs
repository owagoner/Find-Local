using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLocal.Models
{
    public class Media
    {
        public int id { get; set; }
        public int businessId { get; set; }
        public string featureImage { get; set; }
        public List<string> images { get; set; }
    }
}