using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeofencingApplicationPrototype.Models
{
    public class Circle
    {
        public double XPoint
        {
            get;
            set;
        }

       public double YPoint
        {
            get;
            set;
        }

        public double Rad
        {
            get;
            set;
        }

        public Circle(double xPoint, double yPoint, double rad)
        {
            this.XPoint = xPoint;
            this.YPoint = yPoint;
            this.Rad = rad;
        }
    }
}