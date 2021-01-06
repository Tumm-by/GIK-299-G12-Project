using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TextBaseGame
{
    //Handles the saving and loading to and from file for the TextBasedGame
    internal class SaveLoad
    {
        private const string saveDirPath = @"Save\"; //Save folder
        private const string saveFileType = @".json";//Save file type

        //Ensures we always have a save folder.
        static SaveLoad()
        {
            //Checks if the Save folder exists and creates it if it doesn't
            if (!Directory.Exists(saveDirPath))
            {
                Directory.CreateDirectory(saveDirPath);
            }
        }

        //Used for saving the gamestate to a file.
        [Serializable]
        private struct SaveGame
        {
            private string[][] _map;
            public Hero _hero;

            public string[][] Map { get { return _map; } set { _map = value; } }
            public Hero Hero { get { return _hero; } set { _hero = value; } }
        }

        //Saves the game
        private static void Save(string saveGamePath, Hero hero, string[,] map)
        {
            //2d arrays are not supported by the json serializer. Converting 2d array into a jagged array which is supported.
            string[][] jaggedMap = new string[map.GetLength(0)][];
            for (int i = 0; i < jaggedMap.GetLength(0); i++)
            {
                jaggedMap[i] = new string[map.GetLength(1)];
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    jaggedMap[i][j] = map[i, j];
                }
            }
            //Creating our savegame object
            SaveGame save = new SaveGame();
            save.Map = jaggedMap;
            save.Hero = hero;

            //Saving to file
            File.WriteAllText(saveGamePath, JsonSerializer.Serialize<SaveGame>(save), new UTF8Encoding());
        }

        //Loads a game from a file
        private static void Load(string saveGamePath, Hero hero, out string[,] map)
        {
            //Loading the savegame file
            SaveGame loadGame = JsonSerializer.Deserialize<SaveGame>(File.ReadAllText(saveGamePath, new UTF8Encoding()));

            //Turning the jaggedArray into a 2d Array.
            string[,] unJaggedMap = new string[loadGame.Map.GetLength(0), loadGame.Map[0].GetLength(0)];
            for (int i = 0; i < loadGame.Map.GetLength(0); i++)
            {
                for (int j = 0; j < loadGame.Map[i].GetLength(0); j++)
                {
                    unJaggedMap[i, j] = loadGame.Map[i][j];
                }
            }
            map = unJaggedMap;

            //Loading values into the hero.
            hero.Name = loadGame.Hero.Name;
            hero.HP = loadGame.Hero.HP;
            hero.NumberOfKeys = loadGame.Hero.NumberOfKeys;
            hero.PosX = loadGame.Hero.PosX;
            hero.PosY = loadGame.Hero.PosY;
            hero.AttackDamage = loadGame.Hero.AttackDamage;
            hero.FailChance = loadGame.Hero.FailChance;
            hero.CollectedAllKeys = loadGame.Hero.CollectedAllKeys;
        }

        //Menu handling user interaction for saving
        public static void SaveGameMenu(Hero hero, string[,] map)
        {
            string input;
            bool runInputMenu = true;

            while (runInputMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the save menu, please select");
                Console.WriteLine("A name for your savegame, //EXIT// to go back or //LIST// to show already existing saves");

                input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "exit":
                        Console.WriteLine("Saving cancelled, press enter to continue");
                        return;

                    case "list": //Lists the savegames that already exist

                        if (SavesExists())
                        {
                            foreach (string s in GetSaveGameList())
                                Console.WriteLine(s);
                        }

                        Console.Write("Press enter to continue");
                        Console.ReadLine();
                        break;

                    default: //Start saving process
                        if (ValidSaveGameName(input))
                        {
                            if (File.Exists($"{saveDirPath}{input}{saveFileType}"))//if the file already exists, do you want to overwrite it?
                            {
                                string input2;
                                bool yesNoMenu = true;
                                while (yesNoMenu)
                                {
                                    Console.WriteLine($"File {input} already exists, do you want to overwrite it? Y/N");
                                    input2 = Console.ReadLine().Trim().ToUpper();
                                    switch (input2)
                                    {
                                        case ("Y"):
                                        case ("YES"):
                                            Save($"{saveDirPath}{input}{saveFileType}", hero, map);
                                            yesNoMenu = false;
                                            runInputMenu = false;
                                            break;

                                        case ("N"):
                                        case ("NO"):
                                            yesNoMenu = false;
                                            break;

                                        default:
                                            Console.WriteLine("Invalid option please select \"yes\" or \"no\"");
                                            break;
                                    }
                                }
                            }
                            else //Name is valid and not shared with another file
                            {
                                Save($"{saveDirPath}{input}{saveFileType}", hero, map);
                                runInputMenu = false;
                            }
                        }
                        else
                        { //Invalid name or menu option.
                            Console.WriteLine("Invalid filename or option. //EXIT//, //LIST// or a save game name of ONLY LETTERS");
                            Console.Write("Press enter to continue");
                            Console.ReadLine();
                        }
                        break;
                }
            }
            Console.WriteLine("Save successfull, press enter to continue");
            Console.ReadLine();
        }

        //Returns true if save files exist.
        private static bool SavesExists()
        {
            string[] list = GetSaveGameList();
            if (list.Length == 0)
            {
                Console.WriteLine("List is empty, there are no saved games \n");
                return false;
            }
            else
            {
                return true;
            }
        }

        //Menu handling user interaction for loading
        public static bool LoadGameMenu(Hero hero, ref string[,] map)
        {
            string input;
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Welcome to the load menu, please select");
                Console.WriteLine("A game to load, //EXIT// to go back or //LIST// to show a list of available saves");

                input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "exit":
                        Console.WriteLine("Loading cancelled, press enter to continue");
                        return false;

                    case "list": //Lists the savegames that can be loaded;

                        if (SavesExists())
                        {
                            foreach (string s in GetSaveGameList())
                                Console.WriteLine(s);
                        }
                        break;

                    default:
                        if (File.Exists($"{saveDirPath}{input}{saveFileType}"))//if the file exists
                        {
                            Load($"{saveDirPath}{input}{saveFileType}", hero, out map);
                            Console.Write("Loading successfull, press enter to continue");
                            Console.ReadLine();
                            return true;
                        }
                        else //File doesn't exist.
                        {
                            Console.WriteLine($"File with the name {input} is an Invalid filename or option. \"exit\",\"list\" or a save game name of ONLY LETTERS");
                        }
                        break;
                }
            }
        }

        //Returns a string array of the savegames that already exist
        public static string[] GetSaveGameList()
        {
            string[] saveGameList = Directory.GetFiles(saveDirPath);

            //Removing path to the folder and fileendings
            for (int i = 0; i < saveGameList.Length; i++)
            {
                saveGameList[i] = saveGameList[i].Replace(saveDirPath, "");
                saveGameList[i] = saveGameList[i].Replace(saveFileType, "");
            }
            return saveGameList;
        }

        //Checks if the "name" string is a valid name. i.e. one that contains only letters
        private static bool ValidSaveGameName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            foreach (char c in name.ToCharArray())
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}