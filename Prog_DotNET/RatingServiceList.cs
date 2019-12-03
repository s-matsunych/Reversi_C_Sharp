using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
     public class RatingServiceList : IRatingService
    {

        List<Rating> ratings = new List<Rating>();

        public RatingServiceList()
        {

        }

        public void AddRating(Rating rating)
        {
            if (rating == null)
                Console.WriteLine("Rating must be not null!");
            if (rating.Name == null)
                Console.WriteLine("Rating contains null Name!");
            
            
                if (rating.rating > 5 || rating.rating < 0) Console.WriteLine("The Rating should be less than 1 ... 5 ");
                else ratings.Add(rating);
         
            


        }

        public void ClearRating()
        {
            ratings.Clear();
        }

        public int GetRating()
        {
            int rating = 0;
            foreach (Rating k in ratings)
            {
                rating += k.rating;
            }
            int statistikRating = rating / ratings.Count();
            return statistikRating;
        }

        public List<Rating> GetRatings()
        {
            return ratings;
        }
    }
}
