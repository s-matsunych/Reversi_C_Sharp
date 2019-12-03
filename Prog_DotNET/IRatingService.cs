using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    public interface IRatingService
    {
        void AddRating(Rating rating);
        void ClearRating();
        int GetRating();
        
    }
}
