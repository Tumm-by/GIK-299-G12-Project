namespace TextBaseGame
{
    //Class handling information about a hero
    public class Hero
    {
        private string _name;
        private int _hp = 100;
        private int _numberOfKeys = 0;
        private int _posX;
        private int _posY;
        private int _attackDamage = 10;
        private double _failChance = 0.2;
        private bool _collectedAllKeys = false;

        public string Name { get => _name; set => _name = value; }

        public int HP
        {
            get => _hp;
            set
            {
                if (value > 100) //Max hero health;
                    _hp = 100;
                else
                    _hp = value;
            }
        }

        public int NumberOfKeys { get => _numberOfKeys; set => _numberOfKeys = value; }
        public bool CollectedAllKeys { get { return _collectedAllKeys; } set { _collectedAllKeys = value; } }
        public int PosX { get => _posX; set => _posX = value; }
        public int PosY { get => _posY; set => _posY = value; }
        public int AttackDamage { get => _attackDamage; set => _attackDamage = value; }
        public double FailChance { get => _failChance; set => _failChance = value; }

        public Hero(string name)
        {
            Name = name;
        }
    }
}