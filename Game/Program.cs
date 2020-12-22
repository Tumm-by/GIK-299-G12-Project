using System;

namespace textBaseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero myHero = new Hero("Ola", 100, 0, 0, 9, 10, .2);
            Room[,] gameMap = GenerateMap();
            Render.RenderGame(gameMap, myHero);
            for (int i = 0; i < 12; i++)
            {
                Move(myHero, gameMap, 1, 0);
                Render.RenderGame(gameMap, myHero);
                Console.ReadLine();
            }
        }

        static Room[,] GenerateMap()
        {
            Room[,] newMap = new Room[10, 10];
            Random rnd = new Random();

            //Creating Rooms and monsters
            for (int i = 0; i < newMap.GetLength(0); i++)
            {
                for (int j = 0; j < newMap.GetLength(1); j++)
                {
                    if (rnd.Next(5) == 4)
                    {
                        newMap[i, j] = new Room(0, rnd.Next(1, 3));
                        for (int k = 0; k < newMap[i, j].Monsters.Length; k++)
                        {
                            newMap[i, j].Monsters[k] = new Monster(10, 10, 10, .2);
                        }
                    }
                    else
                    {
                        newMap[i, j] = new Room(0, 0);
                    }
                }
            }

            //Adding keys to room
            for (int i = 0; i <= Room.TotalKeys; i++)
            {
                newMap[rnd.Next(0, newMap.GetLength(0)), rnd.Next(0, newMap.GetLength(1))].KeyCounter++;
            }
            return newMap;
        }

        //Moves the hero
        static void Move(Hero hero, Room[,] map, int xChange, int yChange)
        {
            if ((hero.PosX + xChange < map.GetLength(0) && hero.PosX + xChange >= 0) && (hero.PosY + yChange < map.GetLength(1) && hero.PosY + yChange >= 0))
            {
                hero.PosX += xChange;
                hero.PosY += yChange;
            }
        }
    }
}
