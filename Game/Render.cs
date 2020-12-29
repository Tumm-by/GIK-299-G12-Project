using System;
using System.Collections.Generic;
using System.Text;
using TextBaseGame;

namespace TextBaseGame
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
                { " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . ", " . " },

            };


        private bool PlayGame = true;

        public RenderGame(int monsters, Hero hero)
        {

            Random rnd = new Random();
            int random1;
            int random2;

            hero.PosX = 9;
            hero.PosY = 0;
            
            for (int i = 0; i < 20; i++)
            {
                random1 = rnd.Next(0, 10);
                random2 = rnd.Next(0, 10);
                if (i < 10)
                {
                    if (map[random1, random2] == " Y ")
                    {
                        i--;
                    }
                    map[random1, random2] = " Y ";
                }
                if (i >= 10)
                {
                    if (map[random1, random2] == " K ")
                    {
                        i--;
                    }
                    else if (map[random1, random2] == " Y ")
                    {
                        map[random1, random2] = " YK";
                    }
                    else
                    {
                        map[random1, random2] = " K ";
                    }
                    

                }
                
                
            }

            



            while (PlayGame)
            {

                Console.Clear();
                map[hero.PosX, hero.PosY] = " X ";

                for (int i = 0; i < 10; i++)
                {
                    
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(map[i, j]);
                    }

                    Console.WriteLine();
                }

               

                Move(hero);
            }
        }

        public void Move(Hero hero)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (hero.PosX > 0)
                {
                    if (map[hero.PosX - 1, hero.PosY] == " Y ")
                    {
                        if (AskPlayer(hero, 0))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosX--;
                        }
                    }
                    else if (map[hero.PosX - 1, hero.PosY] == " YK")
                    {
                        if (AskPlayer(hero, 1))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosX--;
                        }
                    }
                    else if (map[hero.PosX - 1, hero.PosY] == " K ")
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX--;
                        GetKey(hero);
                    }
                    else
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX--;

                    }
                }
                
            }

            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (hero.PosX < 9 )
                {
                    if (map[hero.PosX + 1, hero.PosY] == " Y ")
                    {
                        if (AskPlayer(hero, 0))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosX++;
                        }
                    }
                    else if (map[hero.PosX + 1, hero.PosY] == " YK")
                    {
                        if (AskPlayer(hero, 1))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosX++;
                        }
                        
                    }
                    else if (map[hero.PosX + 1, hero.PosY] == " K ")
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX++;
                        GetKey(hero);
                    }
                    else
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX++;
                    }
                    
                }       
            }

            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (hero.PosY > 0)
                {
                    if (map[hero.PosX, hero.PosY - 1] == " Y ")
                    {
                        if (AskPlayer(hero, 0))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosY--;
                        }
                    }
                    else if (map[hero.PosX, hero.PosY - 1] == " YK")
                    {
                        if (AskPlayer(hero, 1))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosY--;
                        }
                    }
                    else if (map[hero.PosX, hero.PosY - 1] == " K ")
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY--;
                        GetKey(hero);
                    }
                    else
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY--;
                    }
                }
            }

            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (hero.PosY < 9 )
                {
                    if (map[hero.PosX, hero.PosY + 1] == " Y ")
                    {
                        if (AskPlayer(hero, 0))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosY++;
                        }
                    }
                    else if (map[hero.PosX, hero.PosY + 1] == " YK")
                    {
                        if (AskPlayer(hero, 1))
                        {
                            map[hero.PosX, hero.PosY] = " . ";
                            hero.PosY++;
                        }
                    }
                    else if (map[hero.PosX, hero.PosY + 1] == " K ")
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY++;
                        GetKey(hero);
                    }
                    else
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY++;
                    }
                    
                }        
            }

            if (hero.CollectedAllKeys && hero.PosX == 0 && hero.PosY == 9)
            {
                Console.WriteLine("You win, the game is done");
                PlayGame = false;
            }
        }

        private bool AskPlayer(Hero hero, int keys)
        {
            Console.WriteLine("Roar!!");
            Console.WriteLine("You have encountered a monster!");
            Console.WriteLine("Will you attack it? \"ATTACK\"!, \"Flee\"!");

            string input;
            input = Console.ReadLine().ToUpper().Trim();
            
            switch (input)
            {
                case "A":
                case "ATTACK":
                    Fight(hero, keys);
                    return true;
                case "F":
                case "FLEE":
                    return false;
                default:
                    Console.WriteLine($"Poor {hero.Name} can't decide");
                    Console.ReadLine();
                    return false;

            }
        }

        private void GameOver(Hero hero)
        {
            Console.WriteLine($"{hero.Name} died, pity. Game over.");
            PlayGame = false;
        }

        private void TextMethod()
        {
            Console.ReadLine();
            Console.WriteLine();
        }

        private void GetKey(Hero hero)
        {
            Console.WriteLine("There was a key in this room!");
            hero.NumberOfKeys++;
            Console.WriteLine($"Key added to inventory, you now have {hero.NumberOfKeys}!");
            if (hero.NumberOfKeys == 10)
            {
                Console.WriteLine("You have gotten all the keys, head to the top right corner!");
                hero.CollectedAllKeys = true;
            }
            Console.ReadLine();
        }

        private void Fight(Hero hero, int keys)
        {
            Console.Clear();
            Random rand = new Random();

            Monster monster = new Monster(10, 10, 5, .5);

            int enemies = rand.Next(1, 3);

            Console.WriteLine("A monster Approaches");
            if (enemies == 2)
                Console.WriteLine("A second monster Approaches");
            if (enemies == 3)
                Console.WriteLine("A third monster Approaches");
            while (monster.MonsterHealth > 0 && enemies != 0)
            {

                if (!(rand.NextDouble() > hero.FailChance))
                {
                    hero.HP -= monster.MonsterAttack;
                    Console.WriteLine("CURSES! YOU ARE WOUNDED!");
                    Console.WriteLine($"Your HP is now {hero.HP}");
                    TextMethod();
                    if (hero.HP <= 0)
                    {
                        GameOver(hero);
                        return;
                    }


                }
                else
                {
                    Console.WriteLine("You strike!");
                    TextMethod();
                    monster.MonsterHealth -= hero.AttackDamage;
                    if (monster.MonsterHealth <= 0)
                    {
                        if (enemies > 0)
                        {
                            monster.MonsterHealth = 10;
                        }

                        Console.WriteLine($"You defeat monster {enemies}");
                        TextMethod();
                        enemies--;
                        if (!(rand.NextDouble() > monster.MonsterDropChance))
                        {
                            hero.HP += monster.MonsterDrop;
                            Console.WriteLine("The Monster Dropped a potion! Your health increases");
                            Console.WriteLine($"Your HP is now {hero.HP}");
                            Console.ReadLine();
                            if (enemies == 0)
                            {
                                Console.WriteLine("You defeated all monsters in this room, good job!");
                                if (keys == 1)
                                {
                                    GetKey(hero);
                                }
                                return;
                            }
                        }
                        else
                        {
                            if (enemies == 0)
                            {
                                Console.WriteLine("You defeated all monsters in this room, good job!");
                                if (keys == 1)
                                {
                                    GetKey(hero);
                                }
                                return;
                            }
                        }
                    }

                }
            }
            Console.ReadLine();
        }

    }
}