using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    [Serializable]
    public class Rating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int rating { get; set; }

        public Rating(string Name, int rating)
        {
            this.Name = Name;
            this.rating = rating;
        }
    }
}
