namespace TextBaseGame
{
    //Class handling information about a monster
    internal class Monster
    {
        private int _monsterHealth = 10;
        private int _monsterAttack = 10;
        private int _monsterDrop = 10;
        private double _monsterDropChance = .1;

        public int MonsterHealth { get { return _monsterHealth; } set { _monsterHealth = value; } }
        public int MonsterAttack { get { return _monsterAttack; } set { _monsterAttack = value; } }
        public int MonsterDrop { get { return _monsterDrop; } set { _monsterDrop = value; } }
        public double MonsterDropChance { get { return _monsterDropChance; } set { _monsterDropChance = value; } }

        public Monster(int monsterHp, int monsterAttack, int monsterDrop, double monsterDropChance)
        {
            MonsterHealth = monsterHp;
            MonsterAttack = monsterAttack;
            MonsterDrop = monsterDrop;
            MonsterDropChance = monsterDropChance;
        }
    }
}