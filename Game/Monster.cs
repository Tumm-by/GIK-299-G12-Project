using System;
using System.Collections.Generic;

namespace textBaseGame
{
    class Monster
    {
        private int _monsterHealth;
        public int MonsterHealth
        {
            get { return _monsterHealth; }
            set { _monsterHealth = value; }
        }
        private int _monsterAttack;

        public int MonsterAttack
        {
            get { return _monsterAttack; }
            set { _monsterAttack = value; }
        }

        private int _monsterDrop;

        public int MonsterDrop
        {
            get { return _monsterDrop; }
            set { _monsterDrop = value; }
        }
    }
}