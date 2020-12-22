using System;
using System.Collections.Generic;
using System.Text;

namespace textBaseGame
{
    internal class RenderGame
    {
        public string[,] map =
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
                { " X ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },

            };

        public RenderGame(int monsters)
        {
            Random rnd = new Random();
            int random1;
            int random2;
            for (int i = 0; i < monsters; i++)
            {
                random1 = rnd.Next(1, 10);
                random2 = rnd.Next(0, 10);
                if (map[random1, random2] == " Y ")
                {
                    i--;
                }
                map[random1, random2] = " Y ";
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void move()
        {
            
        }
    }
}