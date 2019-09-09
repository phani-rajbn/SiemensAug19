using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMvcApp.Models
{
    public class TravelInfo
    {
        public int TravelID { get; set; }
        public string Destination { get; set; }
        public string Details { get; set; }
        public DateTime TravelDate { get; set; }
        public short Duration { get; set; }

        public override string ToString()
        {
            return string.Format("<h1>The Details to {0}</h1><div><p>{1}", Destination, Details);
        }
    }
}