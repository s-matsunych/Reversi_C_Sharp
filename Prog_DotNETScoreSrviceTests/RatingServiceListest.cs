using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prog_DotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET.Tests
{
    [TestClass()]
    public class RatingServiceListestTest
    {
        RatingServiceList service = new RatingServiceList();

      

        [TestMethod()]
        public void AddRatingTest()
        {
            service.AddRating(new Rating("Stasik", 5));

            Assert.AreEqual<string>("Stasik",service.GetRatings()[0].Name);
            Assert.AreEqual<int>(5, service.GetRatings()[0].rating);


        }
        


        [TestMethod()]
        public void ClearRatingTest()
        {
            service.AddRating(new Rating("Stasik", 5));
            service.ClearRating();
            var scores = service.GetRatings();
            Assert.AreEqual<int>(0, scores.Count);
        }

        [TestMethod()]
        public void GetRatingTest()
        {
            service.AddRating(new Rating("Stasik", 1));
            service.AddRating(new Rating("Stasik", 2));
            service.AddRating(new Rating("Stasik", 4));
            service.AddRating(new Rating("Stasik", 4));
            service.AddRating(new Rating("Stasik", 4));
            service.AddRating(new Rating("Stasik", 5));
            service.AddRating(new Rating("Stasik", 0));
            service.AddRating(new Rating("Stasik", 5));
           // var scores = service.GetRatings();
            Assert.AreEqual<int>(3, service.GetRating());
        }


    }
}