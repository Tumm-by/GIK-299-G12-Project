namespace textBaseGame
{
    public class Hero
    {
		private string _name;
		private int _hp;
		private int _numberOfKeys;
        private int _posX;
		private int _posY;
		private int _attackDamage;
		private double _failChance;

		public string Name {get => _name; set => _name = value;}
		public int HP {get => _hp; set => _hp = value;}
		public int NumberOfKeys {get => _numberOfKeys; set => _numberOfKeys = value;}
		public int PosX { get => _posX; set => _posX = value;}
		public int PosY { get => _posY; set => _posY = value;}
		public int AttackDamage { get => _attackDamage; set => _attackDamage = value;}
		public double FailChance { get => _failChance; set => _failChance = value;}
		
		public Hero(string name, int hp, int numberOfKeys, int posX, int posY, int attackDamage, double failChance)
        {
            this._name = name;
			this._numberOfKeys = numberOfKeys;
            this._posX = posX;
			this._posY = posY;
        }
	}
}
