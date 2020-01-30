using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeofencingApplicationPrototype;
using GeofencingApplicationPrototype.Controllers;
using GeofencingApplicationPrototype.Models;
using static GeofencingApplicationPrototype.Models.HaversineFormula;

namespace GeofencingApplicationPrototype.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void HaversineFormula()
        {
            Location loc = new Location(48.54, 50.56);

            Location location = new Location(55.55, 52.80);

            HaversineFormula haversine = new HaversineFormula();

            double res = haversine.Dist(loc, location, TypeOfDistance.Kilometres);

            HaversineFormula haversine1 = new HaversineFormula();

            double res1 = haversine.Dist(loc, location, TypeOfDistance.Kilometres);


            Assert.AreEqual(res,res1);


        }

        [TestMethod]
        public void LocationTest()
        {
            Location loc = new Location(48.54, 50.56);

            Location location = new Location(55.55, 52.80);

            Assert.AreNotEqual(loc, location);

        }

    }
}
