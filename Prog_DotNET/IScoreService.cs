using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
   public interface IScoreService
    {
        void AddScore(Score score);
        List<Score> GetTopScores();

        void ClearScores();

    }
}
