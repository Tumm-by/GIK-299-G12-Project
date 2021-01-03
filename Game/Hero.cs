using System;

namespace TextBaseGame
{
    //Class handling information about a hero
    [Serializable]
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

        public int NumberOfKeys { get { return _numberOfKeys; } set { _numberOfKeys = value; } }
        public int PosX { get { return _posX; } set { _posX = value; } }
        public int PosY { get { return _posY; } set { _posY = value; } }
        public int AttackDamage { get { return _attackDamage; } set { _attackDamage = value; } }
        public double FailChance { get { return _failChance; } set { _failChance = value; } }
        public bool CollectedAllKeys { get { return _collectedAllKeys; } set { _collectedAllKeys = value; } }

        public Hero()
        {
        }

        public Hero(string name)
        {
            Name = name;
        }
    }
}