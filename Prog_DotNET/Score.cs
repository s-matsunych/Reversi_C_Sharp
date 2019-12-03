using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    [Serializable]
    public class Score
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }
         
        public Score(string Name, int Points)
        {
            this.Name = Name;
            this.Points = Points;
        }
    }
}
