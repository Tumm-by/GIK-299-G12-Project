using System;
using System.Collections.Generic;
using System.Text;

namespace textBaseGame
{
    class Render
    { 
        static public void RenderGame(Room[,] map, Hero hero)
        {
            string[,] renderMap =
            {
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },
            };

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j].Monsters != null || !MonstersAreDead(map[i, j].Monsters))
                    {
                        renderMap[i,j]= " Y ";
                    }
                }
            }
            renderMap[hero.PosX,hero.PosY] = " X ";

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(renderMap[i,j]);
                }
                Console.WriteLine();
            }
        }

        static bool MonstersAreDead(Monster[] monsters)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i].MonsterHealth > 0)
                    return false;
            }
            return true;
        }

        public void move()
        {

        }
    }
}