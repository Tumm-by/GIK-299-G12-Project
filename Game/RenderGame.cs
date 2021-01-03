using System;

namespace TextBaseGame
{
    public class RenderGame
    {
        private string[,] _map =
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

        private bool _playGame = true;

        public string[,] Map { get { return _map; } set { _map = value; } }
        public bool PlayGame { get { return _playGame; } set { _playGame = value; } }

        public RenderGame()
        {
            Hero hero = new Hero();
            bool loadSuccess = SaveLoad.LoadGameMenu(hero, ref _map);
            string name = hero.Name;
            Console.WriteLine(name);
            Console.ReadKey();

            if (loadSuccess)
            {
                RenderLoop(hero);
            }
        }

        public RenderGame(Hero hero)
        {
            Random rnd = new Random();
            int random1;
            int random2;

            hero.PosX = 9;
            hero.PosY = 0;

            //Draw enemies and keys on the Map
            for (int i = 0; i < 20; i++)
            {
                random1 = rnd.Next(0, 10);
                random2 = rnd.Next(0, 10);
                //Enemies
                if (i < 10)
                {
                    //If there already is enemy on location, do again so we have 10 monsters
                    if (Map[random1, random2] == " Y ")
                    {
                        i--;
                    }
                    //Add monster on location
                    Map[random1, random2] = " Y ";
                }
                //Keys
                if (i >= 10)
                {
                    //If key already on this loaction, do again so we have 10 keys.
                    if (Map[random1, random2] == " K ")
                    {
                        i--;
                    }
                    //If Monster on location, add new symbol to represent key and monster.
                    else if (Map[random1, random2] == " Y ")
                    {
                        Map[random1, random2] = " YK";
                    }
                    //if nothing on location, add key.
                    else
                    {
                        Map[random1, random2] = " K ";
                    }
                }
            }

            //While game active, loop render
            RenderLoop(hero);
        }

        public void RenderLoop(Hero hero)
        {
            int moveWay = 0;

            if (moveWay == 0)
            {
                bool check = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Do You Want to Use Arrow Keys or Text to Move Hero?");
                    Console.WriteLine();
                    Console.WriteLine("Write //ARROW// or //A// to Use Arrow Keys to Move Hero");
                    Console.WriteLine("Write //TEXT// or //T// to Use Text to Move Hero");

                    switch (Console.ReadLine().ToLower().Trim())
                    {
                        case "a":
                        case "arrow":
                            moveWay = 1;
                            check = false;
                            break;

                        case "t":
                        case "text":
                            moveWay = 2;
                            check = false;
                            break;

                        default:
                            continue;
                    }
                } while (check);
            }

            while (PlayGame)
            {
                Console.Clear();
                //Draw hero on Map
                Map[hero.PosX, hero.PosY] = " X ";
                if (moveWay == 2)
                {
                    Ascii.HowToMoveText();
                }
                else if (moveWay == 1)
                {
                    Ascii.HowToMoveArrow();
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.Write("                ");
                    for (int j = 0; j < 10; j++)
                    {
                        Console.Write(Map[i, j]);
                    }

                    Console.WriteLine("      ");
                }
                //Wait for move
                Move(hero, moveWay);
            }
        }

        public void CheckMove(Hero hero, int differential, string direction)
        {
            //Which direction we are checkin and moving.
            if (direction == "X")
            {
                //Check if there is enemy on location we are goig to, if true, ask player if he wants to flee or fight
                if (Map[hero.PosX + differential, hero.PosY] == " Y ")
                {
                    if (AskPlayer(hero, 0))
                    {
                        Map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX += differential;
                    }
                }
                //Check if there is enemy on location we are goig to, if true, ask player if he wants to flee or fight, also checks if there is key in room
                else if (Map[hero.PosX + differential, hero.PosY] == " YK")
                {
                    if (AskPlayer(hero, 1))
                    {
                        Map[hero.PosX, hero.PosY] = " . ";
                        hero.PosX += differential;
                    }
                }
                //Check if there is key in room
                else if (Map[hero.PosX + differential, hero.PosY] == " K ")
                {
                    Map[hero.PosX, hero.PosY] = " . ";
                    hero.PosX += differential;
                    GetKey(hero);
                }
                //If there isnt anything on location, just move and replace old loaction with default symbol
                else
                {
                    Map[hero.PosX, hero.PosY] = " . ";
                    hero.PosX += differential;
                }
            }
            //Check above comments, only difference is direction.
            if (direction == "Y")
            {
                if (Map[hero.PosX, hero.PosY + differential] == " Y ")
                {
                    if (AskPlayer(hero, 0))
                    {
                        Map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY += differential;
                    }
                }
                else if (Map[hero.PosX, hero.PosY + differential] == " YK")
                {
                    if (AskPlayer(hero, 1))
                    {
                        Map[hero.PosX, hero.PosY] = " . ";
                        hero.PosY += differential;
                    }
                }
                else if (Map[hero.PosX, hero.PosY + differential] == " K ")
                {
                    Map[hero.PosX, hero.PosY] = " . ";
                    hero.PosY += differential;
                    GetKey(hero);
                }
                else
                {
                    Map[hero.PosX, hero.PosY] = " . ";
                    hero.PosY += differential;
                }
            }
        }

        public void Move(Hero hero, int moveway)
        {
            if (moveway == 1)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
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

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.Write("._"); //Prevents readkey from interfering with output, without this readkey eats from ascii text.
                    Console.Clear();
                    Ascii.MenuInstruct();
                    string testInput = Console.ReadLine().Trim().ToUpper();
                    if (true)
                    {
                        switch (testInput)
                        {
                            case "SAVE":
                                SaveLoad.SaveGameMenu(hero, Map);
                                break;

                            case "LOAD":
                                SaveLoad.LoadGameMenu(hero, ref _map);
                                break;

                            case "EXIT":
                                PlayGame = false;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            else if (moveway == 2)
            {
                string readInput = Console.ReadLine();

                if (readInput == "go up" || readInput == "up" || readInput == "u")
                {
                    if (hero.PosX > 0)
                    {
                        CheckMove(hero, (-1), "X");
                    }
                }
                //If DownArrow, go down, but check what is there and so the location is not out of bounds
                if (readInput == "go down" || readInput == "down" || readInput == "d")
                {
                    if (hero.PosX < 9)
                    {
                        CheckMove(hero, 1, "X");
                    }
                }
                //If LeftArrow, go Left, but check what is there and so the location is not out of bounds
                if (readInput == "go left" || readInput == "left" || readInput == "l")
                {
                    if (hero.PosY > 0)
                    {
                        CheckMove(hero, (-1), "Y");
                    }
                }
                //If RightArrow, go Right, but check what is there and so the location is not out of bounds
                if (readInput == "go right" || readInput == "right" || readInput == "r")
                {
                    if (hero.PosY < 9)
                    {
                        CheckMove(hero, (1), "Y");
                    }
                }
                if (readInput == "menu")
                {
                    Ascii.MenuInstruct();
                    string testInput = Console.ReadLine().Trim().ToUpper();
                    switch (testInput)
                    {
                        case "SAVE":
                            SaveLoad.SaveGameMenu(hero, Map);
                            break;

                        case "LOAD":
                            SaveLoad.LoadGameMenu(hero, ref _map);
                            break;

                        case "EXIT":
                            PlayGame = false;
                            break;

                        default:
                            break;
                    }
                }
            }
            //Check after every move if we have all the keys, and if we are in top right corner, if both are true, user wins and loop ends.
            if (hero.CollectedAllKeys && hero.PosX == 0 && hero.PosY == 9)
            {
                Console.Clear();
                Ascii.EndGameWin();
                Console.WriteLine();
                Console.WriteLine("You win, the game is over");
                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
                PlayGame = false;
            }
        }

        private bool AskPlayer(Hero hero, int keys)
        {
            Console.Clear();
            Ascii.MonsterSpawn();
            Ascii.MonsterEncounter();
            Ascii.Decision();

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
                    Console.WriteLine("You decided to flee!");
                    return false;

                default:
                    Console.WriteLine($"{hero.Name}! Can't decide what to do! {hero.Name} retreated!");
                    Console.ReadLine();
                    return false;
            }
        }

        private void Fight(Hero hero, int keys)
        {
            //Console.Clear();
            Random rand = new Random();
            //Make monster
            Monster monster = new Monster(10, 10, 5, .5);
            //Randomize how many monsters in room
            int enemies = rand.Next(1, 4);

            Console.WriteLine("The monster Approaches");
            if (enemies == 2)
                Console.WriteLine("Oh no! there is one MORE!");
            if (enemies == 3)
                Console.WriteLine("CURSES! there are 2 MORE monsters!");
            //If monsters are alive
            while (enemies != 0)
            {
                //if attack fails, gets attacked.
                if (!(rand.NextDouble() > hero.FailChance))
                {
                    hero.HP -= monster.MonsterAttack;
                    Console.WriteLine("You attack but fail....");
                    Console.WriteLine("CURSES! THE MONSTER HURT YOU!");
                    Console.WriteLine($"Hp decreased to: {hero.HP}");
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
                    Console.WriteLine("You strike! \nA solid hit!");
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
                        Console.WriteLine($"Monster NO: {enemies} is slain!");
                        TextMethod();
                        //delete 1 enemy, since one died
                        enemies--;
                        //randomized chance of health potion drop when enemy died
                        if (!(rand.NextDouble() > monster.MonsterDropChance))
                        {
                            hero.HP += monster.MonsterDrop;
                            Console.WriteLine("The monster dropped a potion!, you recovered some health.");
                            Console.WriteLine($"Your HP is now {hero.HP}.");
                            Console.ReadLine();
                        }
                        //if all enemies are dead
                        if (enemies == 0)
                        {
                            Console.WriteLine("You defeated all monsters in this room, fabolous!");
                            Console.ReadKey();
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

        //If user dies, aka 0 or below HP, this method is called.
        private void GameOver(Hero hero)
        {
            //Console.WriteLine($"{hero.Name} died, pity. Game over.");
            Ascii.EndGameLose();
            PlayGame = false;
        }

        //If key, this function is called, to keep score on how many keys user has, and if it has 10, enable parameter for win senario.
        private void GetKey(Hero hero)
        {
            Ascii.CollectKey();
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

        private void TextMethod()
        {
            Console.ReadLine();
            Console.WriteLine();
        }
    }
}