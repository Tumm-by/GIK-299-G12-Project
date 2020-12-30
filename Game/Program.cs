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
            Console.Clear();
            Console.WriteLine("Welcome to the textbased game: GET OUT OF THE DUNGEON!");
            Console.WriteLine("Under your adventure you happened to get stuck in a dungeon!");
            Console.WriteLine("To get out of the dungeon you will have to find 10 keys.");
            Console.WriteLine("You can find the keys by collecting them from different rooms.");
            Console.WriteLine("After colleting 10 keys you will have to reach the end of the dungeon to get out.");
            Console.WriteLine("However beware of the monsters!\n");
            //Starts game 
            Start();
            //Game has ended, check if user wants to play again.
            Console.WriteLine("Wellplayed! want to play again?\n");

            switch (Console.ReadLine())
            {
                case "y":
                case "yes":
                    Start();
                    return true;

                case "n":
                case "no":
                    return false;

                default:
                    return true;
            }
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