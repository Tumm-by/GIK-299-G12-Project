using System;

namespace textBaseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            TextScript.Greetings();
            Console.WriteLine("Name your hero!");
            string heroName = Console.ReadLine();
            Hero myHero = new Hero(heroName, 100, 0, 0, 9, 10, .2);
            Room[,] gameMap = GenerateMap();
            GameHandler game = new GameHandler(myHero, gameMap);
            game.RunGame();
        }

        static Room[,] GenerateMap()
        {
            Room[,] newMap = new Room[10, 10];
            Random rnd = new Random();

            //Initializing newMap
            for (int i = 0; i < newMap.GetLength(0); i++)
            {
                for (int j = 0; j < newMap.GetLength(1); j++)
                {
                    newMap[i,j] = new Room();
                }
            }

            
            //Adding Monsters To rooms
            Monster[] newMonsters;
            for (int i = 0; i < 10; i++)
            {
                int random1, random2;
                newMonsters = new Monster[rnd.Next(1,3)];
                for (int j = 0; j < newMonsters.Length; j++)
                    newMonsters[j] = new Monster(10, 10, 10, 0.1);//Monster Stats;
                
                //In case we get the same room twice;
                do {
                    random1 = rnd.Next(0, newMap.GetLength(0));
                    random2 = rnd.Next(0, newMap.GetLength(1));
                    if (newMap[random1, random2].Monsters.Length <= 0){
                        newMap[random1, random2].Monsters = newMonsters;
                        break;
                    }
                } while(true);
            }

            //Adding keys to room
            for (int i = 0; i < 10; i++)
            {
                newMap[rnd.Next(0, newMap.GetLength(0)), rnd.Next(0, newMap.GetLength(1))].KeyCounter++;
                Room.TotalKeys++;
            }
            return newMap;
        }
    }
}
