﻿using System;

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

        public RenderGame(Hero hero)
        {
            Random rnd = new Random();
            int random1;
            int random2;

            hero.PosX = 9;
            hero.PosY = 0;

            //Draw enemies and keys on the map
            for (int i = 0; i < 20; i++)
            {
                random1 = rnd.Next(0, 10);
                random2 = rnd.Next(0, 10);
                //Enemies
                if (i < 10)
                {
                    //If there already is enemy on location, do again so we have 10 monsters
                    if (map[random1, random2] == " Y ")
                    {
                        i--;
                    }
                    //Add monster on location
                    map[random1, random2] = " Y ";
                }
                //Keys
                if (i >= 10)
                {
                    //If key already on this loaction, do again so we have 10 keys.
                    if (map[random1, random2] == " K ")
                    {
                        i--;
                    }
                    //If Monster on location, add new symbol to represent key and monster.
                    else if (map[random1, random2] == " Y ")
                    {
                        map[random1, random2] = " YK";
                    }
                    //if nothing on location, add key.
                    else
                    {
                        map[random1, random2] = " K ";
                    }
                }
            }

            //While game active, render
            while (PlayGame)
            {
                Console.Clear();
                //Draw hero on map
                map[hero.PosX, hero.PosY] = " X ";

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(map[i, j]);
                    }

                    Console.WriteLine();
                }
                //Wait for move 
                Move(hero);
            }
        }

        public void CheckMove(Hero hero, int differential, string direction)
        {
            //Which direction we are checkin and moving.
            if (direction == "X")
            {
                //Check if there is enemy on location we are goig to, if true, ask player if he wants to flee or fight
                if (map[hero.PosX + differential, hero.PosY] == " Y ")
                {
                    if (AskPlayer(hero, 0))
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX += differential;
                    }
                }
                //Check if there is enemy on location we are goig to, if true, ask player if he wants to flee or fight, also checks if there is key in room
                else if (map[hero.PosX + differential, hero.PosY] == " YK")
                {
                    if (AskPlayer(hero, 1))
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX += differential;
                    }
                }
                //Check if there is key in room
                else if (map[hero.PosX + differential, hero.PosY] == " K ")
                {
                    map[hero.PosX, hero.PosY] = " . ";
                    hero.PosX += differential;
                    GetKey(hero);
                }
                //If there isnt anything on location, just move and replace old loaction with default symbol
                else
                {
                    map[hero.PosX, hero.PosY] = " . ";
                    hero.PosX += differential;
                }
            }
            //Check above comments, only difference is direction.
            if (direction == "Y")
            {
                if (map[hero.PosX, hero.PosY + differential] == " Y ")
                {
                    if (AskPlayer(hero, 0))
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY += differential;
                    }
                }
                else if (map[hero.PosX, hero.PosY + differential] == " YK")
                {
                    if (AskPlayer(hero, 1))
                    {
                        map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY += differential;
                    }
                }
                else if (map[hero.PosX, hero.PosY + differential] == " K ")
                {
                    map[hero.PosX, hero.PosY] = " . ";
                    hero.PosY += differential;
                    GetKey(hero);
                }
                else
                {
                    map[hero.PosX, hero.PosY] = " . ";
                    hero.PosY += differential;
                }
            }
        }

        public void Move(Hero hero)
        {
            //Get what key is pressed
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            //If UpArrow, go up, but check what is there and so the location is not out of bounds
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (hero.PosX > 0)
                {
                    CheckMove(hero, (-1), "X");
                }
            }
            //If DownArrow, go down, but check what is there and so the location is not out of bounds
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                if (hero.PosX < 9)
                {
                    CheckMove(hero, 1, "X");
                }
            }
            //If LeftArrow, go Left, but check what is there and so the location is not out of bounds
            if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                if (hero.PosY > 0)
                {
                    CheckMove(hero, (-1), "Y");
                }
            }
            //If RightArrow, go Right, but check what is there and so the location is not out of bounds
            if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                if (hero.PosY < 9)
                {
                    CheckMove(hero, (1), "Y");
                }
            }
            //Check after every move if we have all the keys, and if we are in top right corner, if both are true, user wins and loop ends.
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

        //If user dies, aka 0 or below HP, this method is called.
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

        //If key, this function is called, to keep score on how many keys user has, and if it has 10, enable parameter for win senario.
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
            //Make monster
            Monster monster = new Monster(10, 10, 5, .5);
            //Randomize how many monsters in room
            int enemies = rand.Next(1, 3);

            Console.WriteLine("A monster Approaches");
            if (enemies == 2)
                Console.WriteLine("A second monster Approaches");
            if (enemies == 3)
                Console.WriteLine("A third monster Approaches");
            //If monsters are alive
            while (enemies != 0)
            {
                //if attack fails, gets attacked.
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
                    //if attack doesnt fail, kills monster
                    Console.WriteLine("You strike!");
                    TextMethod();
                    monster.MonsterHealth -= hero.AttackDamage;
                    //if monster health is zero, but there is still enemies left, reset hp to full to represent next enemy.
                    if (monster.MonsterHealth <= 0)
                    {
                        if (enemies > 0)
                        {
                            monster.MonsterHealth = 10;
                        }
                        //1 monster is dead of randomized amount.
                        Console.WriteLine($"You defeat monster {enemies}");
                        TextMethod();
                        //delete 1 enemy, since one died
                        enemies--;
                        //randomized chance of health potion drop when enemy died
                        if (!(rand.NextDouble() > monster.MonsterDropChance))
                        {
                            hero.HP += monster.MonsterDrop;
                            Console.WriteLine("The Monster Dropped a potion! Your health increases");
                            Console.WriteLine($"Your HP is now {hero.HP}");
                            Console.ReadLine();

                        }
                        //if all enemies are dead
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
            Console.ReadLine();
        }
    }
}