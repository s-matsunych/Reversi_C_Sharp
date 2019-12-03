using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    [Serializable]
    public class Field
    {
        private const int x = 8;
        private const int y = 8;

        public int _x { get { return x; } }
        public int _y { get { return y; } }
        public Tile[,] tiles;
       // public Tile[,] tilese {   get { return tiles; } }

        public Field()
        {
            this.tiles = new Tile[x, y];
            genrerFled();
        }

        public void genrerFled()
        {

            for (int i = 0; y > i; i++)
            {
                for (int j = 0; x > j; j++)
                {
                    tiles[i,j] = new Tile();
                }
            }
            int x1 = tiles.GetLength(0) / 2 - 1;
            int y1 = tiles.GetLength(1) / 2 - 1;
            tiles[x1,y1].State = (TileState.WHITE);
            tiles[x1 + 1, y1 + 1].State = (TileState.WHITE);
            tiles[x1 + 1,y1].State = (TileState.BLACK);
            tiles[x1,y1 + 1].State = (TileState.BLACK);
            

        }

        public void printFled()
        {
            if (tiles != null)
            {
                for (int i = 0; y > i; i++)
                {
                    for (int j = 0; x > j; j++)
                    {
                        Console.Write(tiles[j,i].PrintState());
                        Console.Write(" ");
                    }
                    Console.Write("\n");
                }
               
                Console.Write("-------------------\n" +
                    "///////////////////\n" +
                    "-------------------\n");
            }
            else return;
        }

        public void PutTile(int s, int x, int y)
        {
            if ((tiles[x,y].State == TileState.EMPTY) && (s % 2 == 0)) tiles[x,y].State = TileState.BLACK;

            if ((tiles[x,y].State == TileState.EMPTY) && (s % 2 != 0)) tiles[x,y].State = TileState.WHITE;
        }

        public void revers(int x, int y)
        {
            if (tiles[x, y].State == TileState.WHITE)
            {
                
                tiles[x, y].State = TileState.BLACK;
            }
            else if (tiles[x, y].State == TileState.BLACK)
            {
                
                tiles[x, y].State = TileState.WHITE;
            }
        }

        public void chekAndRevers(int s, int x, int y)
        {

            if (tiles[x,y].State == TileState.EMPTY)
            {
                if (chekUp(s, x, y) || chekDown(s, x, y) || chekLeft(s, x, y) || chekRight(s, x, y) || chekLU(s, x, y) || chekLD(s, x, y) || chekRU(s, x, y) || chekRD(s, x, y))
                {

                    U_ARchek(s, x, y);
                    D_ARchek(s, x, y);
                    L_ARchek(s, x, y);
                    R_ARchek(s, x, y);
                    LU_ARchek(s, x, y);
                    LD_ARchek(s, x, y);
                    RU_ARchek(s, x, y);
                    RD_ARchek(s, x, y);
                    PutTile(s, x, y);
                }
            }
        }


        public void U_ARchek(int s, int x, int y)
        {
            if (chekUp(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;
                while (tiles[x1,(y1 - 1)].State != tiles[x,y].State)
                {
                    y1--;
                    revers(x1, y1);
                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }

        public void D_ARchek(int s, int x, int y)
        {
            if (chekDown(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;

                while (tiles[x1,y1 + 1].State != tiles[x,y].State)
                {
                    y1++;
                    revers(x1, y1);

                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }

        public void L_ARchek(int s, int x, int y)
        {
            if (chekLeft(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;

                while (tiles[(x1 - 1),(y1)].State != tiles[x,y].State)
                {
                    
                    x1--;
                    revers(x1, y1);
                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }

        public void R_ARchek(int s, int x, int y)
        {
            if (chekRight(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;

                while (tiles[(x1 + 1),(y1)].State != tiles[x,y].State)
                {
                    
                    x1++;
                   
                    revers(x1, y1);
                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }

        public void LU_ARchek(int s, int x, int y)
        {
            if (chekLU(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;

                while (tiles[(x1 - 1),(y1 - 1)].State != tiles[x,y].State)
                {
                    x1--;
                    y1--;
                    revers(x1, y1);
                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }

        public void LD_ARchek(int s, int x, int y)
        {
            if (chekLD(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;

                while (tiles[(x1 - 1),(y1 + 1)].State != tiles[x,y].State)
                {
                    x1--;
                    y1++;
                    revers(x1, y1);
                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }

        public void RU_ARchek(int s, int x, int y)
        {
            if (chekRU(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;

                while (tiles[(x1 + 1),(y1 - 1)].State != tiles[x,y].State)
                {
                    x1++;
                    y1--;
                    revers(x1, y1);
                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }

        public void RD_ARchek(int s, int x, int y)
        {
            if (chekRD(s, x, y))
            {
                PutTile(s, x, y);
                int x1 = x;
                int y1 = y;

                while (tiles[(x1 + 1),(y1 + 1)].State != tiles[x,y].State)
                {
                    x1++;
                    y1++;
                    revers(x1, y1);
                }
            }
            tiles[x,y].State = TileState.EMPTY;
        }
        //------------------------------------------------------------------------------------------------------------->
        public bool chekUp(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;

            if (tiles[x,y].State == TileState.EMPTY && y > 0 && tiles[x1,(y1 - 1)].State == TileState.WHITE && s % 2 == 0)
            {
                while (y1 > 0)
                {
                    y1--;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1,y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x,y].State == TileState.EMPTY && y > 0 && tiles[x1,(y1 - 1)].State == TileState.BLACK && s % 2 != 0)
                {
                    while (y1 > 0)
                    {
                        y1--;
                        if (tiles[x1,y1].State == TileState.BLACK) continue;
                        else if (tiles[x1,y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }

                    return false;
                }
            }
            return false;
        }

        public bool chekDown(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;

            if (tiles[x,y].State == TileState.EMPTY && y < tiles.GetLength(1) - 1 && tiles[x1,(y1 + 1)].State == TileState.WHITE && s % 2 == 0)
            {
                while (y1 < tiles.GetLength(1) - 1)
                {
                    y1++;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x,y].State == TileState.EMPTY && y < tiles.GetLength(1) - 1 && tiles[x1, (y1 + 1)].State == TileState.BLACK && s % 2 != 0)
                {
                    while (y1 < tiles.GetLength(1) - 1)
                    {
                        y1++;
                        if (tiles[x1,y1].State == TileState.BLACK) continue;
                        else if (tiles[x1, y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }

                    return false;
                }
            }
            return false;
        }

        public bool chekRight(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;

            if (tiles[x,y].State == TileState.EMPTY && x < tiles.GetLength(0) - 1 && tiles[(x1 + 1),(y1)].State == TileState.WHITE &&(s % 2 == 0))
            {
                while (x1 < tiles.GetLength(0) - 1)
                {
                    x1++;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x, y].State == TileState.EMPTY && x < tiles.GetLength(0) - 1 && tiles[(x1 + 1),(y1)].State == TileState.BLACK && (s % 2 != 0))
                {
                    while (x1 < tiles.GetLength(0) - 1)
                    {
                        x1++;
                        if (tiles[x1,y1].State == TileState.BLACK) continue;
                        else if (tiles[x1,y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }
                }
            }
            return false;
        }

        public bool chekLeft(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;

            if (tiles[x,y].State == TileState.EMPTY && x > 0 && tiles[(x1 - 1),(y1)].State == TileState.WHITE &&( s % 2 == 0))
            {
                while (x1 > 0)
                {
                    x1--;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x, y].State == TileState.EMPTY && x > 0 && tiles[(x1 - 1), (y1)].State == TileState.BLACK && (s % 2 != 0))
                {
                    while (x1 > 0)
                    {
                        x1--;
                        if (tiles[x1, y1].State == TileState.BLACK) continue;
                        else if (tiles[x1, y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }

                    //return false;
                }
            }
            return false;
        }

        public bool chekLU(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;

            if (tiles[x,y].State == TileState.EMPTY && (x > 0 && y > 0) && tiles[(x1 - 1),(y1 - 1)].State == TileState.WHITE && s % 2 == 0)
            {
                while (x1 > 0 && y1 > 0)
                {
                    x1--;
                    y1--;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x, y].State == TileState.EMPTY && (x > 0 && y > 0) && tiles[(x1 - 1), (y1 - 1)].State == TileState.BLACK && s % 2 != 0)
                {
                    while (x1 > 0 && y1 > 0)
                    {
                        x1--;
                        y1--;
                        if (tiles[x1, y1].State == TileState.BLACK) continue;
                        else if (tiles[x1, y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }

                    return false;
                }
            }
            return false;// gfsd
        }

        public bool chekLD(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;
            if (tiles[x,y].State == TileState.EMPTY && (x > 0 && y < tiles.GetLength(1) - 1) && tiles[(x1 - 1),(y1 + 1)].State == TileState.WHITE && s % 2 == 0)
            {
                while (x1 > 0 && y1 < tiles.GetLength(1) - 1)
                {
                    x1--;
                    y1++;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x, y].State == TileState.EMPTY && (x > 0 && y < tiles.GetLength(1) - 1) && tiles[(x1 - 1), (y1 + 1)].State == TileState.BLACK && s % 2 != 0)
                {
                    while (x1 > 0 && y1 < tiles.GetLength(1) - 1)
                    {
                        x1--;
                        y1++;
                        if (tiles[x1, y1].State == TileState.BLACK) continue;
                        else if (tiles[x1, y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }

                    return false;
                }
            }
            return false;
        }


        public bool chekRU(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;

            if (tiles[x,y].State == TileState.EMPTY && (x < tiles.GetLength(0)- 1 && y > 0) && tiles[(x1 + 1),(y1 - 1)].State == TileState.WHITE && s % 2 == 0)
            {
                while (x1 < tiles.GetLength(0) - 1 && y1 > 0)
                {
                    x1++;
                    y1--;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x, y].State == TileState.EMPTY && (x < tiles.GetLength(0) - 1 && y > 0) && tiles[(x1 + 1), (y1 - 1)].State == TileState.BLACK && s % 2 != 0)
                {
                    while (x1 < tiles.GetLength(0) - 1 && y1 > 0)
                    {
                        x1++;
                        y1--;
                        if (tiles[x1, y1].State == TileState.BLACK) continue;
                        else if (tiles[x1, y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }

                    return false;
                }
            }
            return false;
        }



        public bool chekRD(int s, int x, int y)
        {
            int x1 = x;
            int y1 = y;

            if (tiles[x,y].State == TileState.EMPTY && (x < tiles.GetLength(0) - 1 && y < tiles.GetLength(1) - 2) && tiles[(x1 + 1),(y1 + 1)].State == TileState.WHITE && s % 2 == 0)
            {
                while (x1 < tiles.GetLength(0) - 1 && y1 < tiles.GetLength(1) - 1)
                {
                    x1++;
                    y1++;
                    if (tiles[x1,y1].State == TileState.WHITE) continue;
                    else if (tiles[x1,y1].State == TileState.BLACK)
                    {
                        return true;
                    }
                    else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                }
            }
            else
            {
                x1 = x;
                y1 = y;
                if (tiles[x, y].State == TileState.EMPTY && (x < tiles.GetLength(0) - 1 && y < tiles.GetLength(1) - 2) && tiles[(x1 + 1), (y1 + 1)].State == TileState.BLACK && s % 2 != 0)
                {
                    while (x1 < tiles.GetLength(0) - 1 && y1 < tiles.GetLength(1) - 1)
                    {
                        x1++;
                        y1++;
                        if (tiles[x1, y1].State == TileState.BLACK) continue;
                        else if (tiles[x1, y1].State == TileState.WHITE)
                        {
                            return true;
                        }
                        else if (tiles[x1, y1].State == TileState.EMPTY) return false;
                    }

                    return false;
                }
            }
            return false;// gfsd
        }




        public int whites()
        {
            int whites = 0;
            for (int y = 0; y < _y; y++)
            {
                for (int x = 0; x < _x; x++)
                {
                    if (tiles[x,y].State == TileState.WHITE) whites++;
                    else continue;
                }

            }
            return whites;
        }

        public int blacks()
        {
            int blacks = 0;
            for (int y = 0; y < _y; y++)
            {
                for (int x = 0; x < _y; x++)
                {
                    if (tiles[x,y].State == TileState.BLACK) blacks++;
                    else continue;
                }

            }
            return blacks;
        }


    }
}
























































































































































