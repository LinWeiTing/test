using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class city
    {
        public int cityId { get; set; }

        public string cityName { get; set; }

        public int? countyId { get; set; }

        public county county { get; set; }

        public List<restaurant> restaurantCollection { get; set; }
    }
}