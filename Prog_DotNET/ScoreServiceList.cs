using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Prog_DotNET
{
    public class ScoreServiceList : IScoreService
    {
        

        public List<Score> scores = new List<Score>();

       

        public void AddScore(Score score)
        {
            if (score == null)
                Console.WriteLine("Score must be not null!");
            if (score.Name == null)
                Console.WriteLine("Score contains null Name!");
            scores.Add(score);
            
        }

        public List<Score> GetTopScores()
        {
           
            return (from s in scores orderby s.Points descending select s).Take(5).ToList();
            //return scores.OrderByDescending(s => s.Points).Take(3).ToList();
        }


        public List<Score> GetScores()
        {

            return scores;
           
        }

        public void ClearScores()
        {
            scores.Clear();
            
        }


       

    }
}
