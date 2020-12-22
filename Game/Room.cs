namespace textBaseGame
{
    ///<summary>A room containing keys and monsters. Used in a dungeon</summary>
    class Room {
        ///<summary>The total number of keys across all rooms</summary>
        private static int _TotalKeys;
         ///<summary>Number of keys in the room</summary>
        private int _keyCounter;
        ///<summary>Array for monsters in the room</summary>
        private Monster[] _monsters;
         ///<summary>Array for monsters in the room</summary>
        public Monster[] Monsters { get { return _monsters;} set { _monsters = value;}} 
         ///<summary>Number of keys in the room</summary>
        public int KeyCounter { get { return _keyCounter;} set { _keyCounter = value;}} 
        ///<summary>The total number of keys across all rooms</summary>
        public static int TotalKeys { get { return _TotalKeys;} set { _TotalKeys = value;}}
        ///<summary>Constructs a room with "keysInRoom" number of keys, and "monstersInRoom" numer of monsters in it</summary>
        ///<param name="keysInRoom">Number of keys in the room</param>
        ///<param name="monstersInRoom">Number of monsters in the room</param>
        public Room(int keysInRoom, int monstersInRoom){
            KeyCounter = keysInRoom;
            TotalKeys += keysInRoom;
            Monsters = new Monster[monstersInRoom];


            
        }
    }
}