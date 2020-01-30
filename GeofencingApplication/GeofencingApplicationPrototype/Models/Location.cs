using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeofencingApplicationPrototype.Models
{
    public class Location
    {
        public double Lat
        {
            get;
            set;
        }

        public double Lon
        {
            get;
            set;
        }


        public Location(double lat, double lon)
        {
            this.Lat = lat;
            this.Lon = lon;
        }

    }
}