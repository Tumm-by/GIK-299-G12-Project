using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TextBaseGame
{   
    class SaveLoad
    {
        const string saveDirPath = @"Save\";
        const string saveFileType = @".json";
        
        [Serializable]
        struct SaveGame
        {
            string[][] _map;
            public Hero _hero;

            public string[][] Map { get { return _map; } set { _map = value; } }
            public Hero Hero { get { return _hero; } set { _hero = value; } }
        }

        public static void Save(string saveGamePath, Hero hero, string[,] map)
        {
            string[][] jaggedMap = new string[map.GetLength(0)][];
            for (int i = 0; i < jaggedMap.GetLength(0); i++)
            {
                jaggedMap[i] = new string[map.GetLength(1)];
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    jaggedMap[i][j] = map[i, j];
                }
            }
            SaveGame save = new SaveGame();
            save.Map = jaggedMap;
            save.Hero = hero;
            File.WriteAllText(saveGamePath, JsonSerializer.Serialize<SaveGame>(save), new UTF8Encoding());
        }

        public static Hero Load(string saveGamePath, out string[,] map)
        {
            SaveGame loadGame = JsonSerializer.Deserialize<SaveGame>(File.ReadAllText(saveGamePath, new UTF8Encoding()));
            string[,] unJaggedMap = new string[loadGame.Map.GetLength(0), loadGame.Map[0].GetLength(0)];
            for (int i = 0; i < loadGame.Map.GetLength(0); i++)
            {
                for (int j = 0; j < loadGame.Map[i].GetLength(0); j++)
                {
                    unJaggedMap[i, j] = loadGame.Map[i][j];
                }
            }
            map = unJaggedMap;
            return loadGame._hero;
        }

        public static void SaveGameMenu(Hero hero, string[,] map)
        {
            string input;
            bool runInputMenu = true;

            string[] saveGameList = GetSaveGameList();
            while (runInputMenu)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the save menu, please select");
                Console.WriteLine("A name for your savegame, \"exit\" to go back or list to show already existing saves");
                
                input = Console.ReadLine().ToLower().Trim();
                switch (input)
                {
                    case "exit":
                        return;
                    case "list":
                        foreach (string s in saveGameList)
                            Console.WriteLine(s);
                        Console.Write("Press enter to continue");
                        Console.ReadLine();
                        break;
                    default:
                        if (ValidSaveGameName(input))
                        {
                            if (File.Exists($"{saveDirPath}{input}{saveFileType}"))
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
                            else
                            {
                                Save($"{saveDirPath}{input}{saveFileType}", hero, map);
                                runInputMenu = false;
                            }
                        }
                        else
                            Console.WriteLine("Invalid filename or option. \"exit\",\"List\" or a save game name of ONLY LETTERS");
                        break;
                }
            }
        }

        public static string[] GetSaveGameList()
        {
            string[] saveGameList = Directory.GetFiles(saveDirPath);
            for(int i = 0; i < saveGameList.Length; i++)
            {
                saveGameList[i] = saveGameList[i].Replace(saveDirPath, "");
                saveGameList[i] = saveGameList[i].Replace(saveFileType, "");
            }
            return saveGameList;
        }

        private static bool ValidSaveGameName(string name)
        {
            foreach (char c in name.ToCharArray())
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}