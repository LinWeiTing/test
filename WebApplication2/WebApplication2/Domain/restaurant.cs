using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class restaurant
    {
        public int restaurantId { get; set; }
        public string restaurantName { get; set; }
        public string restaurantAddress { get; set; }
        public string restaurantPhone { get; set; }
        public string restaurantNote { get; set; }
        public string restaurantPicture { get; set; }
        public string restaurantURL { get; set; }
        public int? cityId { get; set; }
        public int providerId { get; set; }
    }
}