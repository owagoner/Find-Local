using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FindLocal.Models
{
    public class BusinessViewModel
    {
        public Business business { get; set; }
        public List<Business> relatedBusiness { get; set; } 
        
    }
}