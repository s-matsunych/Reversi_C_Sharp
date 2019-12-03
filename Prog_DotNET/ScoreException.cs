using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    class ScoreException : Exception
    {

        public ScoreException(string message) : base(message)
        {
        }

        public ScoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
