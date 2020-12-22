using System;
using System.Collections.Generic;

namespace textBaseGame
{
    class MonstInfo
    {
        private int MonsterHealth;
        public int MonstHealth
        {
            get { return MonsterHealth; }
            set { MonsterHealth = value; }
        }
        public int MonstAttack;

        public int MonstDrop;
    }
}