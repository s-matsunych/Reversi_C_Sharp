using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    class Main_Program
    {
        private static ConsoleUI console;
        static void Main(string[] args)
        {

            console = new ConsoleUI();
            console.play();
            //console.scoreService.GetTopScores();

            

         

            /* Field fild = new Field();
             fild.genrerFled();
             fild.printFled();
             fild.revers(3, 3);
             fild.printFled();
             */
             Console.ReadKey();
        }
    }
}
