using Prog_DotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiWeb.Models
{
    
    public class ReversiModel
    {
        public Field Field { get; set; }
        
        public int s { get; set; }
     
        public IList<Score> Scores { get; set; }

    }
}



