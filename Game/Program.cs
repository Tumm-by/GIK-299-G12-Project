using System;

namespace TextBaseGame
{
    internal class Program
    {
        private static void Main()
        {
            bool check = true;

            //Starts menu
            while (check)
            {
                check = Meny();
            }
        }

        private static bool Meny()
        {
            if (true)
            {
                Console.WriteLine("Write start or s to start game");
                Console.WriteLine("Write load or l to load game");
                Console.WriteLine("Write exit or e to exit game");

                switch (Console.ReadLine())
                {
                    case "s":
                    case "start":
                        Console.Clear();
                        Console.WriteLine("Welcome to the textbased game: GET OUT OF THE DUNGEON!");
                        Console.WriteLine("Under your adventure you happened to get stuck in a dungeon!");
                        Console.WriteLine("To get out of the dungeon you will have to find 10 keys.");
                        Console.WriteLine("You can find the keys by collecting them from different rooms.");
                        Console.WriteLine("After colleting 10 keys you will have to reach the end of the dungeon to get out.");
                        Console.WriteLine("However beware of the monsters!\n");
                        //Starts game
                        Start();
                        return false;

                    case "e":
                    case "exit":
                        return false;

                    case "l":
                    case "load":
                        new RenderGame();
                        return GameFinished();

                    default:
                        return true;
                }
            }
        }

        private static bool GameFinished()
        {
            Console.WriteLine("Game is over! want to play again?\n");
            Console.WriteLine();
            Meny();
            return false;
        }


        //Starts the game    
        private static void Start()
        {    
            Console.WriteLine("Name your hero!");          
            string heroName = Console.ReadLine();
            Hero myHero = new Hero(heroName);
            new RenderGame(myHero);
        }
    }
}