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
    public class ScoreServiceListTests
    {
        ScoreServiceList service = new ScoreServiceList();

      

        [TestMethod()]
        public void AddScoreTest()
        {
            service.AddScore(new Score("Jacko", 40));
            service.AddScore(new Score("Janko", 10));
            service.AddScore(new Score("Ferko", 20));
            service.AddScore(new Score("Janko", 50));
            service.AddScore(new Score("Jozko", 9));
            service.AddScore(new Score("Janko", 2));
            service.AddScore(new Score("Janko", 54));
            service.AddScore(new Score("Jozko", 1));
            service.AddScore(new Score("Janko", 4));
            service.AddScore(new Score("Janko", 0));
            service.AddScore(new Score("Jozko", 8));
            service.AddScore(new Score("Janko", 4));

            var scores = service.GetScores();
            Assert.AreEqual<int>(12,scores.Count);
            //Assert.AreEqual<string>("Jacko", scores[0].Name);
          //  Assert.AreEqual<int>(40, scores[0].Points);

        }
        [TestMethod()]
        public void GetScoresTest()
        {
            service.AddScore(new Score("Jacko", 40));
            service.AddScore(new Score("Janko", 10));
            service.AddScore(new Score("Ferko", 20));
            service.AddScore(new Score("Janko", 50));
            service.AddScore(new Score("Jozko", 9));
            service.AddScore(new Score("Janko", 2));
            service.AddScore(new Score("Janko", 54));
            service.AddScore(new Score("Jozko", 1));
            service.AddScore(new Score("Janko", 4));
            service.AddScore(new Score("Janko", 0));
            service.AddScore(new Score("Jozko", 8));
            service.AddScore(new Score("Janko", 4));

            var scores = service.GetScores();

            Assert.AreEqual<string>("Jacko", scores[0].Name);
            Assert.AreEqual<int>(40, scores[0].Points);

            Assert.AreEqual<string>("Janko", scores[1].Name);
            Assert.AreEqual<int>(10, scores[1].Points);

            Assert.AreEqual<string>("Ferko", scores[2].Name);
            Assert.AreEqual<int>(20, scores[2].Points);

            Assert.AreEqual<string>("Janko", scores[3].Name);
            Assert.AreEqual<int>(50, scores[3].Points);

            Assert.AreEqual<string>("Jozko", scores[4].Name);
            Assert.AreEqual<int>(9, scores[4].Points);
        }

        [TestMethod()]
        public void GetTopScoresTest()
        {
            service.AddScore(new Score ( "Janko", 10 ));
            service.AddScore(new Score ( "Ferko",  20 ));
            service.AddScore(new Score ( "Janko",  50 ));
            service.AddScore(new Score ("Jozko",  9 ));
            service.AddScore(new Score ("Janko", 2 ));
            service.AddScore(new Score("Janko", 54));
            service.AddScore(new Score("Jozko", 1));
            service.AddScore(new Score("Janko", 4));
            service.AddScore(new Score("Janko", 0));
            service.AddScore(new Score("Jozko", 8));
            service.AddScore(new Score("Janko", 4));

            var scores = service.GetTopScores();
            Assert.AreEqual<int>(5, scores.Count);

            Assert.AreEqual<string>("Janko", scores[0].Name);
            Assert.AreEqual<int>(54, scores[0].Points);

            Assert.AreEqual<string>("Janko", scores[1].Name);
            Assert.AreEqual<int>(50, scores[1].Points);

            Assert.AreEqual<string>("Ferko", scores[2].Name);
            Assert.AreEqual<int>(20, scores[2].Points);

            Assert.AreEqual<string>("Janko", scores[3].Name);
            Assert.AreEqual<int>(10, scores[3].Points);

            Assert.AreEqual<string>("Jozko", scores[4].Name);
            Assert.AreEqual<int>(9, scores[4].Points);

        }

        [TestMethod()]
        public void ClearScoresTest()
        {
            service.AddScore(new Score("Janko", 10));
            service.AddScore(new Score("Ferko", 20));
            service.AddScore(new Score("Janko", 50));
            service.AddScore(new Score("Jozko", 9));
            service.AddScore(new Score("Janko", 2));
            service.AddScore(new Score("Janko", 54));
            service.AddScore(new Score("Jozko", 1));
            service.ClearScores();
            var scores = service.GetTopScores();
            Assert.AreEqual<int>(0, scores.Count);
        }
    }
}