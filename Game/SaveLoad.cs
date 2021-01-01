using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace TextBaseGame
{
    class SaveLoad {
        [Serializable]
        struct SaveGame {
            string[][] _map;
            Hero _hero;

            public string[][] Map {get{return _map;} set{_map = value;}}
            public Hero Hero {get{return _hero;} set{_hero = value;}}
        }

        public static void Save(string saveGamePath, Hero hero, string[,] map){
            string[][] jaggedMap = new string[map.GetLength(0)][];
            for (int i = 0; i < jaggedMap.GetLength(0); i++){
                jaggedMap[i] = new string[map.GetLength(1)];
                for (int j = 0; j < map.GetLength(1); j++){
                    jaggedMap[i][j] = map[i,j];
                }
            }
            SaveGame save = new SaveGame();
            save.Map = jaggedMap;
            save.Hero = hero;
            File.WriteAllText("saveHero.json", JsonSerializer.Serialize<SaveGame>(save), new UTF8Encoding()); 
        }

        public static void Load(string saveGamePath, out Hero hero, out string[,] map){
            SaveGame loadGame = JsonSerializer.Deserialize<SaveGame>(File.ReadAllText(saveGamePath, new UTF8Encoding()));
            hero = loadGame.Hero;
            string[,] unJaggedMap = new string [loadGame.Map.GetLength(0),loadGame.Map[0].GetLength(0)];
            for (int i = 0; i < loadGame.Map.GetLength(0); i++){
                for (int j = 0; j < loadGame.Map.GetLength(1); j++){
                    unJaggedMap[i,j] = loadGame.Map[i][j];
                }
            }
            map = unJaggedMap;
        }
    }
}