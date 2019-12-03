using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
   public class RatingServiceDatabase : IRatingService
    {
        public void AddRating(Rating rating)
        {
            using (var context = new ReversiContext())
            {
                context.Add(rating);
                
                context.SaveChanges();

            }
        }

        public void ClearRating()
        {
            using (var context = new ReversiContext())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Rating");
            }
        }

        

        public int GetRating()
        {
            using (var context = new ReversiContext())
            {
                // return context.Database.ExecuteSqlCommand("SELECT AVG(rating) FROM Rating ");
                int a = (int)(from s in context.Ratings  select s.rating).Average();
                return a;
            }
           
        }
    }
}
