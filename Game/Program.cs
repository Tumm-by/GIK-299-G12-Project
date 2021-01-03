using System;

namespace TextBaseGame
{
    internal class Program
    {
        private static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

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
                Console.Clear();

                Console.WriteLine("Write //START// or //S// to Play");
                Console.WriteLine("Write //LOAD// or //L// to Load a Saved Game");
                Console.WriteLine("Write //EXIT// or //E// to Exit Game");



                switch (Console.ReadLine().ToLower().Trim())
                {
                    case "s":
                    case "start":
                        Console.Clear();
                        Ascii.StartGame();
                        Console.WriteLine();
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
            Meny();
            return false;
        }

        //Starts the game
        private static bool Start()
        {
            string heroName;
            do
            {
                Console.WriteLine("Name your hero!");
                heroName = Console.ReadLine();
                if (ValidName(heroName))
                {
                    break;
                }
                Console.WriteLine("Name can't be empty and include symbols/numbers");

            } while (true);

            Hero myHero = new Hero(heroName);
            new RenderGame(myHero);
            return GameFinished();
        }

        private static bool ValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            foreach (char c in name.ToCharArray())
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}