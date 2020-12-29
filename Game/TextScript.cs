using System;

namespace textBaseGame
{
    internal class TextScript
    {
        public static void Greetings()
        {
            Console.WriteLine("Welcome to the textbased game: GET OUT OF THE DUNGEON!");
            Console.WriteLine("Under your adventure you happened to get stuck in a dungeon!");
            Console.WriteLine("To get out of the dungeon you will have to find 10 keys.");
            Console.WriteLine("You can find the keys by collecting them from different rooms.");
            Console.WriteLine("After colleting 10 keys you will have to reach the end of the dungeon to get out.");
            Console.WriteLine("However beware of the monsters!\n");
        }

        public static void HowToMove()
        {
            Console.WriteLine("To move up 'go up'");
            Console.WriteLine("To move down 'go down'");
            Console.WriteLine("To move right 'go right'");
            Console.WriteLine("To move left 'go left'\n");
        }

        public static void Encounter()
        {
            Console.WriteLine("Roar!!");
            Console.WriteLine("You have encountered a monster!");
        }

        public static void RecieveKey()
        {
            Console.WriteLine("You have recieved a key!");
            Console.WriteLine("Keys in possesion: {0}.");
        }
    }
}