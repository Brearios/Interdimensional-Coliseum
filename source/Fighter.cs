namespace InterdimensionalColiseum
{
    internal class Fighter
    {
        //variables
        public string Name { get; set; }
        public double MaxHealth { get; set; }
        public double CurrHealth { get; set; }
        public int Damage { get; set; }
        public int AtkSpd { get; set; }
        public int DPS { get; set; }
        public int AtkRdy { get; set; }
        public int MissChance { get; set; }
        public int CritRate { get; set; }
        public int DodgeChance { get; set; }

        public Fighter(string name, double maxHealth, double currHealth, int damage, int atkSpd, int dPS, int atkRdy, int missChance, int critRate, int dodgeChance)
        {
            this.Name = name;
            this.MaxHealth = maxHealth;
            this.CurrHealth = currHealth;
            this.Damage = damage;
            this.AtkSpd = atkSpd;
            this.DPS = dPS;
            this.AtkRdy = atkRdy;
            this.MissChance = missChance;
            this.CritRate = critRate;
            this.DodgeChance = dodgeChance;
        }
    }
}
