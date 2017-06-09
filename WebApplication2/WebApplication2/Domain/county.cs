using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class county
    {
        public int countyId { get; set; }
        public string countyName { get; set; }


        public List<city> cityCollection { get; set; }
    }
}