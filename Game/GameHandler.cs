using System;

namespace TextBaseGame
{
    class GameHandler
    {
        Room[,] _gameMap;
        Hero _myHero;
        Random rand = new Random();
        bool _collectedAllKeys = false;

        Hero Hero { get { return _myHero; } set { _myHero = value; } }
        Room[,] GameMap { get { return _gameMap; } set { _gameMap = value; } }
        bool CollectedAllKeys { get { return _collectedAllKeys; } set { _collectedAllKeys = value; } }
        bool PlayGame = true;

        public GameHandler(Hero hero, Room[,] gameMap)
        {
            _myHero = hero;
            _gameMap = gameMap;
        }
        //Main loop running the game;
        public void RunGame()
        {
            do
            {
                RenderGame();
                if (NoMonstersInRoom(GameMap[Hero.PosX, Hero.PosY].Monsters))//Game clear condition
                {
                    if (CollectedAllKeys && Hero.PosX == GameMap.GetUpperBound(0) && Hero.PosY == 0)
                    {
                        Console.WriteLine("You win, the game is done");
                        return;
                    }
                    CollectKeys();
                    PlayerMove();
                }
                else
                {
                    Encounter();
                }
            } while (PlayGame);
        }
        //Renders/Displays the game map on screen.
        private void RenderGame()
        {
            Console.Clear();
            //Map of all the rooms, will be edited before printing.
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

            //Monster Position
            for (int i = 0; i < GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < GameMap.GetLength(1); j++)
                {
                    if (GameMap[i, j].Monsters != null && !NoMonstersInRoom(GameMap[i, j].Monsters))
                    {
                        renderMap[i, j] = " Y ";
                    }

                    if (GameMap[i, j].KeyCounter > 0)
                    {
                        renderMap[i, j] = renderMap [i,j].TrimEnd() + "K";
                    }
                }
            }

            //Hero position
            if (renderMap[Hero.PosX, Hero.PosY] == " . " || (renderMap[Hero.PosX, Hero.PosY] == " .K" ))
                renderMap[Hero.PosX, Hero.PosY] = " X ";
            else
                renderMap[Hero.PosX, Hero.PosY] = "X.Y"; //Hero and monster;

            //Hero info for player
            renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1) - 4] += $"\tLegend:\t X=Hero, Y=Monster, K=Key";
            if (CollectedAllKeys)
            {
                renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1) - 3] += "\t!All keys found, head to the top right room!";
            }
            renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1) - 2] += $"\tHero:\t{Hero.Name}";
            renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1) - 1] += $"\tHP:\t{Hero.HP}";
            renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1)] += $"\tKeys:\t{Hero.NumberOfKeys}";

            //Prints the map
            for (int i = 0; i < GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < GameMap.GetLength(1); j++)
                {
                    //Switched j and i. To make X be horizonal and Y vertical as is conventional.
                    Console.Write(renderMap[j, i]);
                }
                Console.WriteLine();
            }
        }
        //Moves the hero
        void Move(int xChange, int yChange)
        {
            if ((Hero.PosX + xChange < GameMap.GetLength(0) && Hero.PosX + xChange >= 0) && (Hero.PosY + yChange < GameMap.GetLength(1) && Hero.PosY + yChange >= 0))
            {
                Hero.PosX += xChange;
                Hero.PosY += yChange;
            }
        }
        //Checks if there are living monsters in a room
        bool NoMonstersInRoom(Monster[] monsters)
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                if (monsters[i].MonsterHealth > 0)
                    return false;
            }
            return true;
        }
        //Collects the keys in a room;
        private void CollectKeys()
        {
            if (GameMap[Hero.PosX, Hero.PosY].KeyCounter > 0)//If there are keys in the room
            {
                Console.WriteLine("You find {0} keys", GameMap[Hero.PosX, Hero.PosY].KeyCounter);
                Hero.NumberOfKeys += GameMap[Hero.PosX, Hero.PosY].KeyCounter; //Adding keys to hero
                GameMap[Hero.PosX, Hero.PosY].KeyCounter = 0; //Removing keys from room
                Console.WriteLine("You Currently Have {0} keys", Hero.NumberOfKeys);
                if (Hero.NumberOfKeys >= Room.TotalKeys)//If we have all keys
                {
                    Console.WriteLine("You have all the keys you need, head to the top right room");
                    CollectedAllKeys = true;
                }
            }
        }
        //Lets the player decide how to act when encountering a monster
        private void Encounter()
        {
            Console.WriteLine("Roar!!");
            Console.WriteLine("You have encountered a monster!");
            Console.WriteLine("Will you attack it? \"ATTACK\"!, \"Flee\"!");
            
            bool askPlayer = true;
            while (askPlayer)
            {
                switch (Console.ReadLine().ToUpper().Trim())
                {
                    case "A":
                    case "ATTACK":
                        Fight();
                        askPlayer = false;
                        break;
                    case "F":
                    case "FLEE":
                        PlayerMove();
                        askPlayer = false;
                        break;
                    default:
                        Console.WriteLine($"Poor {Hero.Name} can't decide, whether to \"Attack\" or to \"Flee\"");
                        break;
                }
            }
            Console.Write("Enter to once again push forward");
            Console.ReadLine();
        }
        //Menu letting the player move
        private void PlayerMove()
        {
            Console.WriteLine("Where to?(\"Go up\", \"Go down\", \"Go left\", \"Go right\" or \"Exit\" to quit)");
            bool askPlayer = true;
            while (askPlayer)
            {
                switch (Console.ReadLine().ToUpper().Trim())
                {
                    case "UP":
                    case "GO UP":
                        Move(0, -1);
                        askPlayer = false;
                        break;
                    case "DOWN":
                    case "GO DOWN":
                        Move(0, 1);
                        askPlayer = false;
                        break;
                    case "LEFT":
                    case "GO LEFT":
                        Move(-1, 0);
                        askPlayer = false;
                        break;
                    case "RIGHT":
                    case "GO RIGHT":
                        Move(1, 0);
                        askPlayer = false;
                        break;
                    case "EXIT":
                        PlayGame = false;
                        return;
                    default:
                        Console.WriteLine($"Poor {Hero.Name} can't decidewhere to go");
                        break;
                }
            }

        }
        //Handles fights with monsters
        private void Fight()
        {
            //Goes through the monster array in a room.
            for (int i = 0; i < GameMap[Hero.PosX, Hero.PosY].Monsters.Length; i++)
            {
                if (GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterHealth > 0)//Monster with hp exists
                {
                    if (i == 1)
                        Console.WriteLine("A second monster Approaches");
                    if (i == 2)
                        Console.WriteLine("A third monster Approaches");
                    if (!(rand.NextDouble() > Hero.FailChance))//If the attack fails
                    {
                        Hero.HP -= GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterAttack;
                        Console.WriteLine("CURSES! YOU ARE WOUNDED!");
                        if (Hero.HP <= 0)
                            GameOver();
                    }
                    else //Attack Succeeds
                    {
                        GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterHealth -= Hero.AttackDamage;
                        if (GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterHealth <= 0)
                        {
                            Console.WriteLine("You defeat the monster");
                            if (!(rand.NextDouble() > GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterDropChance))//Chance of potiondrop
                            {
                                Hero.HP += GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterDrop;
                                Console.WriteLine("The Monster Dropped a potion! Your health increases");
                            }
                        }
                    }
                }
            }
        }
        //Displays game over message and ends the game
        private void GameOver()
        {
            Console.WriteLine($"{Hero.Name} died, pity. Game over.");
            PlayGame = false;
        }
    }
}