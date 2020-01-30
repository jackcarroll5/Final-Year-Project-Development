using GeofencingApplicationPrototype.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GeofencingApplicationPrototype.Controllers
{
    public class HomeController : Controller
    {    
        public ActionResult Index()
        {
            string resultFormula;
            string info;
            string inOutCircle;
            string outcircleAlt;
            
            Location loc1 = new Location(52.343348, -8.970760); //End point of section of local field in home village on edge of field boundary at one side of the field
            Location loc2 = new Location(52.343095, -8.972363); //  Middle point of section of local field in home village
            Location loc3 = new Location(52.350095, -8.962363); //Asset outside geofence test

            Circle circleGeofence = new Circle(52.343095, -8.972363, 0.2);
            Debug.Write("The centre of the circle formed is at (" + circleGeofence.XPoint + " ," + circleGeofence.YPoint + ")");
            Debug.Write("\nRadius of circle geofence is " + circleGeofence.Rad);

            HaversineFormula formula = new HaversineFormula();
            double res = formula.Dist(loc1, loc2, HaversineFormula.TypeOfDistance.Kilometres);
      
            resultFormula = "Result of Haversine Formula based on distance between 2 points of field at home village (Notably middle of field whose real-world coordinates are (" + loc1.Lat + ", " + loc1.Lon + ") " +
                "and point at edge of field boundary whose real-world coordinates (" + loc2.Lat + ", " + loc2.Lon + ")) is " + res + " km. ";
            info = "\nValues in Haversine Formula Equation based on real-world coordinates seen at starting point of map where custom-made marker is situated with custom made circle representing a geofence.";

            bool checker = CheckInside(loc1,loc2,circleGeofence);
         
            if(checker)
            {
                inOutCircle = "\n1st Check\nThe predefined cattle asset point before the addition of markers for testing which is not the point at the middle of the field represented as (" +  loc1.Lat + ", " + loc1.Lon + ") " + " is inside the geofence.";
            }
            else
            {
                inOutCircle = "\n1st Check\nThe predefined cattle asset point before the addition of markers for testing which is not the point at the middle of the field represented as (" + loc1.Lat + ", " + loc1.Lon + ") " + " is outside the geofence";
            }

            bool checkOut = CheckInside(loc2, loc3, circleGeofence);

            if (checkOut)
            {
               outcircleAlt = "\n\n2nd Check\nAnother predefined cattle asset point before the addition of markers for testing which is not the point at the middle of the field represented as (" + loc3.Lat + ", " + loc3.Lon + ") " + " is inside the geofence.";
            }
            else
            {
                outcircleAlt = "\n\n2nd Check\nAnother predefined cattle asset point before the addition of markers for testing which is not the point at the middle of the field represented as (" + loc3.Lat + ", " + loc3.Lon + ") " + " is outside the geofence";
            }

            ViewBag.Message = resultFormula + info + inOutCircle + outcircleAlt;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

       private static bool CheckInside(Location loc1, Location loc2, Circle circle)
        {
            HaversineFormula haversineFormula = new HaversineFormula();

            return haversineFormula.Dist(
               loc1, loc2,HaversineFormula.TypeOfDistance.Kilometres) < circle.Rad;
        }
    }
}