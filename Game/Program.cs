using System;

namespace TextBaseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool check = true;

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

            Start();

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

        static void Start()
        {
            Console.WriteLine("Name your hero!");
            string heroName = Console.ReadLine();

            Hero myHero = new Hero(heroName);
            new RenderGame(10, myHero);
        }
    }
}
