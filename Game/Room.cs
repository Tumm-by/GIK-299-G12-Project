namespace textBaseGame
{
    class Room {
        private static int _TotalKeys;
        private int _keyCounter;
        private Monster[] _monsters;
        
        public Monster[] Monsters { get { return _monsters;} set { _monsters = value;}} 
        public int KeyCounter { get { return _keyCounter;} set { _keyCounter = value;}} 
        public static int TotalKeys { get { return _TotalKeys;} set { _TotalKeys = value;}}

        public Room(int keysInRoom, int monstersInRoom){
            KeyCounter = keysInRoom;
            TotalKeys += keysInRoom;
            Monsters = new Monster[monstersInRoom];  
        }
    }
}