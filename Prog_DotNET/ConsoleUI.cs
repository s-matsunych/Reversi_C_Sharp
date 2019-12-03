using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prog_DotNET
{
    [Serializable]
    public enum GameState
    {
        PLAYING, SOLVED 
    }
    class ConsoleUI
    {

        private Field field;
        private GameState gameState;
        string player1;
        string player2;

        //public ScoreServiceList scoreService = new ScoreServiceList();
        public ScoreServiceDatabase scoreService = new ScoreServiceDatabase();
        public CommentServiceDatabase commentService = new CommentServiceDatabase();
        public RatingServiceDatabase ratingService = new RatingServiceDatabase();


        public void play()
        {
            gameState = GameState.PLAYING;
            this.field = new Field();
            field.genrerFled();
            Addplayer();
            field.printFled();
            move();
            AddComent();
            AddRating();
            commentService.GetComments();
            Restart();
        }
        public void Addplayer()
        {

            Console.Write("Set a name player_1");
            player1 = Console.ReadLine().ToLower();
            Console.Write("Set a name player_2");
            player2 =  Console.ReadLine().ToLower();
            
        }

        public void move()
        {
            int s = 0;
            while (gameState == GameState.PLAYING)
            {
                PrintPlayer(s);

                try
                {
                    Console.Write("X - ");
                    int x = (Convert.ToInt32(Console.ReadLine()));
                    Console.Write("Y - ");
                    int y = Convert.ToInt32(Console.ReadLine());


                    if (field.chekUp(s, x, y) || field.chekDown(s, x, y) || field.chekLeft(s, x, y) || field.chekRight(s, x, y) || field.chekLU(s, x, y) || field.chekLD(s, x, y) || field.chekRU(s, x, y) || field.chekRD(s, x, y))
                    {
                        field.chekAndRevers(s, x, y);
                        field.printFled();
                    }
                    else
                    {
                        Console.WriteLine("Incorrect choice");
                        continue;
                    }

                }catch(System.IndexOutOfRangeException)
                {
                    Console.WriteLine("X or Y More " + (field._x - 1) + " or less " + 0);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("No INTEGER format");
                    continue;
                }
                

                Console.Write("Black - " + field.blacks());
                Console.WriteLine("    White - " + field.whites());
                s++;
                GameEnd(s);

            }
        }

        public bool checkGameState(int s)
        {

            for (int y = 0; y < field._y; y++)
            {
                for (int x = 0; x < field._x; x++)
                {
                    
                    if (field.chekUp(s, x, y) || field.chekDown(s, x, y) || field.chekLeft(s, x, y) || field.chekRight(s, x, y) || field.chekLU(s, x, y) || field.chekLD(s, x, y) || field.chekRU(s, x, y) || field.chekRD(s, x, y))
                    {
                        return true;
                    }

                }

            }
            return false;
        }
        private void PrintPlayer(int s)
        {
            if (s % 2 == 0) Console.WriteLine("BLACK - " + player1);
            if (s % 2 != 0) Console.WriteLine("RED - " + player2);
        }



        public void GameEnd(int s)
        {
            if (!checkGameState(s))
            {
                if (field.blacks() > field.whites())
                {
                    Console.WriteLine("Winner BLACK - " + player1);
                    scoreService.AddScore(new Score(player1, field.blacks()));
                    gameState = GameState.SOLVED;

                }
                if (field.blacks() < field.whites())
                {
                    scoreService.AddScore(new Score(player2, field.whites()));
                    Console.WriteLine("Winner WHITE - " + player2);
                    gameState = GameState.SOLVED;
                }
                if (field.blacks() == field.whites())
                {
                    scoreService.AddScore(new Score(player1, field.blacks()));
                    scoreService.AddScore(new Score(player2, field.whites()));
                    Console.WriteLine("DRAW");
                    gameState = GameState.SOLVED;
                }
            }
           
           
        }
        
        public void Restart()
        {
            Console.WriteLine("Want to repeat the game?(y/n)");
   
            ConsoleKey choise = Console.ReadKey().Key;

            if(choise == ConsoleKey.Y)
            {
                gameState = GameState.PLAYING;
                Console.WriteLine();
                play();
            }
            if (choise == ConsoleKey.N)
            {
                //Environment.Exit(0);
                //System.Environment.Exit(0);
            }



        }

        public void PrintTopScore()
        {
            List<Score> varik = scoreService.GetTopScores();

            foreach (Score score in varik)
            {
                Console.WriteLine(score.Name + "            Points - " + score.Points);
            }

        }

        public void AddComent()
        {
            string comment = null;
            Console.WriteLine(player1 + " - Want to add a comment?(y/n)");
            ConsoleKey choise = Console.ReadKey().Key;

            if (choise == ConsoleKey.Y)
            {
                Console.Write("Comment - ");
                comment = Console.ReadLine();
                commentService.AddComment(new Comment(player1, comment));
            }
            if (choise == ConsoleKey.N)
            {
            }

            Console.WriteLine(player2 + " - Want to add a comment?(y/n)");
            ConsoleKey choise2 = Console.ReadKey().Key;

            if (choise2 == ConsoleKey.Y)
            {
                Console.Write("Comment - ");
                comment = Console.ReadLine();
                commentService.AddComment(new Comment(player2, comment));
            }
            if (choise2 == ConsoleKey.N)
            {
            }


        }

        public void AddRating()
        {
            Console.WriteLine(player1 + " - Want to rate our game?(y/n)");
            ConsoleKey choise = Console.ReadKey().Key;
            try
            {
                
                if (choise == ConsoleKey.Y)
                {
                    Console.Write("Rating - ");
                    int rating = (Convert.ToInt32(Console.Read()));
                    ratingService.AddRating((new Rating(player1, rating)));

                }
                if (choise == ConsoleKey.N)
                {
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("No INTEGER format");

            }

            try
            {
                Console.WriteLine(player2 + " - Want to rate our game?(y/n)");
                ConsoleKey choise2 = Console.ReadKey().Key;

                if (choise2 == ConsoleKey.Y)
                {
                    Console.Write("Rating - ");
                    int rating2 = (Convert.ToInt32(Console.ReadLine()));
                    ratingService.AddRating(new Rating(player2, rating2));

                }
                if (choise2 == ConsoleKey.N)
                {
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("No INTEGER format");

            }

        }

    }

}
