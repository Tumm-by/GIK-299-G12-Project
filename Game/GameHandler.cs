using System;

namespace textBaseGame
{
    class GameHandler
    {
        Room[,] _gameMap;
        Hero _myHero;
        Random rand =  new Random();
        bool _collectedAllKeys = false;

        Hero Hero { get { return _myHero; } set { _myHero = value; } }
        Room[,] GameMap { get { return _gameMap; } set { _gameMap = value; } }
        bool CollectedAllKeys { get { return _collectedAllKeys; } set { _collectedAllKeys = value; }}
        bool PlayGame = true;

        public GameHandler(Hero hero, Room[,] gameMap)
        {
            _myHero = hero;
            _gameMap = gameMap;
        }

        public void RunGame()
        {
            do
            {
                if (NoMonstersInRoom(GameMap[Hero.PosX, Hero.PosY].Monsters))
                {
                    if (CollectedAllKeys && Hero.PosX == GameMap.GetUpperBound(0) && Hero.PosY == 0){
                        Console.WriteLine("You win, the game is done");
                        return;
                    }
                    RenderGame();
                    CollectKeys();
                    PlayerMove(); 
                }
                else
                {
                    RenderGame();
                    Encounter();
                }
            }while (PlayGame);
        }

        private void RenderGame()
        {   
            Console.Clear();
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
                }
            }

            //Hero position
            if(renderMap[Hero.PosX, Hero.PosY] == " . ")
                renderMap[Hero.PosX, Hero.PosY] = " X ";
            else 
                renderMap[Hero.PosX, Hero.PosY] = "X.Y"; //Hero and monster;
            
            //Hero info for player;
            if (CollectedAllKeys){
                renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1) - 3] += "\t!All keys found, head to 10,10!";
            }
            renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1) - 2] += $"\tHero:\t{Hero.Name}";
            renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1) - 1] += $"\tHP:\t{Hero.HP}";
            renderMap[renderMap.GetUpperBound(0), renderMap.GetUpperBound(1)] += $"\tKeys:\t{Hero.NumberOfKeys}";

            for (int i = 0; i < GameMap.GetLength(0); i++)
            {
                for (int j = 0; j < GameMap.GetLength(1); j++)
                {
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
            if (GameMap[Hero.PosX, Hero.PosY].KeyCounter > 0)
            {
                Console.WriteLine("You find {0} keys", GameMap[Hero.PosX, Hero.PosY].KeyCounter);
                Hero.NumberOfKeys += GameMap[Hero.PosX, Hero.PosY].KeyCounter;
                GameMap[Hero.PosX, Hero.PosY].KeyCounter = 0;
                Console.WriteLine("You Currently Have {0} keys", Hero.NumberOfKeys);
                if (Hero.NumberOfKeys >= Room.TotalKeys){
                    Console.WriteLine("You have all the keys you need, head to room {0},{0}",GameMap.GetLength(0));
                    CollectedAllKeys = true;
                }
            }
        }
        //Collects keys in a room
        private void Encounter()
        {
            TextScript.Encounter();
            string input;
            bool askPlayer = true;
            while (askPlayer)
            {
                input = Console.ReadLine().ToUpper().Trim();

                switch (input)
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
                        Console.WriteLine($"Poor {Hero.Name} can't decide");
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
            string input;
            bool askPlayer = true;
            while (askPlayer)
            {
                input = Console.ReadLine().ToUpper().Trim();
                switch (input)
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
                        Console.WriteLine($"Poor {Hero.Name} can't decide");
                        break;
                }
            }

        }
        //Handles fights with monsters
        private void Fight()
        {
            for (int i =  0; i < GameMap[Hero.PosX, Hero.PosY].Monsters.Length; i++){
                if (GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterHealth > 0){
                    if (i == 1)
                        Console.WriteLine("A second monster Approaches");
                    if (i == 2)
                        Console.WriteLine("A third monster Approaches");
                    if (!(rand.NextDouble() > Hero.FailChance)){
                        Hero.HP -= GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterAttack;
                        Console.WriteLine("CURSES! YOU ARE WOUNDED!");
                        if (Hero.HP <= 0)
                            GameOver();
                    }
                    else {
                        GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterHealth -= Hero.AttackDamage;
                        if (GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterHealth <= 0){
                            Console.WriteLine("You defeat the monster");
                            if (!(rand.NextDouble() > GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterDropChance)){
                                Hero.HP += GameMap[Hero.PosX, Hero.PosY].Monsters[i].MonsterDrop;
                                Console.WriteLine("The Monster Dropped a potion! Your health increases");
                            }
                        }
                    }
                }
            }
        }
        //Ends the game if hero health reaches 0
        private void GameOver()
        {
            Console.WriteLine($"{Hero.Name} died, pity. Game over.");
            PlayGame = false;
        }    
    }
}