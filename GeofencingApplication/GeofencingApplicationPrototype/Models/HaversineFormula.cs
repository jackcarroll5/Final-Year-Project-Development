using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GeofencingApplicationPrototype.Models
{
    public class HaversineFormula
    {
        public double Dist(Location l1, Location l2, TypeOfDistance type)
        {
            double Rad = (type == TypeOfDistance.Kilometres) ? 6371 : 3960;
            double dLatitude = ToRadians(l2.Lat - l1.Lat);
            double dLongitude = ToRadians(l2.Lon - l1.Lon);

            double a = Math.Sin(dLatitude / 2) * Math.Sin(dLatitude / 2) +
                Math.Cos(ToRadians(l1.Lat)) * Math.Cos(ToRadians(l2.Lat)) *
                Math.Sin(dLongitude / 2) * Math.Sin(dLongitude / 2);
               Debug.Write("\nThe a value is " + a);

            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            Debug.Write("\nThe c value is " + c);

            double d = Rad * c;
            Debug.Write("\nThe distance between the 2 points is " + d);
             Debug.Write("\nThe radius is " + Rad);

            if (d < Rad)
            {
                Debug.Write("\nThe point is within the circle");
            }
            else
            {
                Debug.Write("\nThe point is outside the circle");
            }
            return d;
        }

        private double ToRadians(double value) {
            return (Math.PI / 180) * value;
        }

        public enum TypeOfDistance
        {           
            Kilometres,
            Miles
        };
    }
}