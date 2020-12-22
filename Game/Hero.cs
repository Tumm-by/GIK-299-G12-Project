using System;
using System.Collections.Generic;

namespace textBaseGame
{
    internal class Hero
    {
	
		static private int hp = 100;
        private string name;
		private int numberOfKeys = 0;
        private double failChance = 0.2;
        private int posX;
		private int posY;
		private int attackDamage = 10;
		
		public Hero(string name, int hp, int numberOfKeys, int posX, int posY)
        {
            this.name = name;
            this.hp = hp;
			this.numberOfKeys = numberOfKeys;
            this.posX = posX;
			this.posY = posY;

        }
		
		public int HP { 
			get => hp; 
			set => hp = value; 
		}
		public int NumberOfKeys { 
			get => numberOfKeys; 
			set => numberOfKeys = value; 
		}
		public int PosX { 
			get => posX; 
			set => posX = value; 
		}
		public int PosY { 
			get => posY; 
			set => posY = value; 
		}
		public string Name { 
			get => name; 
			set => name = value; 
		}
	}
}
