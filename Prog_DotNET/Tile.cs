using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    [Serializable]
    public enum TileState
    {
        EMPTY, WHITE, BLACK
    }
    [Serializable]
    public class Tile
    {
       
        public TileState State { get; set; }

        public Tile()
        {
            State = TileState.EMPTY;
        }

        public String PrintState()
        {
            if (State == TileState.EMPTY) return "*";
            if (State == TileState.BLACK) return "1";
            if (State == TileState.WHITE) return "2";
            return null;
        }
    }
}
