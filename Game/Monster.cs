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
        public int MonsterAttack;

        public int MonsterDrop;
    }
}