using System;

namespace textBaseGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero myHero = new Hero("Ola", 100, 0, 9, 9, 10, .2);
            Room[,] gameMap = GenerateMap();
            Render.RenderGame(gameMap, myHero);
            Console.ReadLine();
        }

        static Room[,] GenerateMap(){
            Room[,] newMap = new Room[10,10];
            Random rnd = new Random();
            int numberOfMonsterRooms = 15;
            int random1;
            int random2;
            
            for (int i = 0; i < numberOfMonsterRooms; i++)
            {
                random1 = rnd.Next(0, 10);
                random2 = rnd.Next(1, 10);
                if (newMap[random1, random2] == null)
                {
                    newMap[random1, random2].Monsters = new Monster[rnd.Next(1,3)];
                }
            }

            for (int i = 0; i <= Room.TotalKeys; i++){
                random1 = rnd.Next(0,newMap.GetLength(0));
                random2 = rnd.Next(0,newMap.GetLength(1));
                newMap[random1, random2].KeyCounter++;
            }

            return newMap;
        }
    }
}
