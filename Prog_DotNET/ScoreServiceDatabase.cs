using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Prog_DotNET
{
    public class ScoreServiceDatabase : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new ReversiContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();

            }
           
        }

        public void ClearScores()
        {
            using (var context = new ReversiContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Scores");
            }
        }

        public List<Score> GetTopScores()
        {
            using (var context = new ReversiContext())
            {
                return (from s in context.Scores
                        orderby s.Points
                            descending
                        select s).Take(5).ToList();


            }

        }
    }
}
