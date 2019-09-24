using System;

namespace InterdimensionalColiseum
{

    class Program
    {
    static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Interdimensional Coliseum!");            
            Console.WriteLine("Enter the name of your hero.");
            string name = Console.ReadLine();
            Console.WriteLine("How much health does " + name + " have?");
            int maxHealth = Convert.ToInt32(Console.ReadLine());
            int currHealth = maxHealth;
            Console.WriteLine("How much damage does " + name + " do per attack?");
            int damage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("With 1 being very slow, and 10 being very fast, how fast does " + name + " attack?");
            int atkSpd = Convert.ToInt32(Console.ReadLine());
            
            int atkRdy = 0;
            int missChance = 3;
            int critRate = 10;
            int dodgeChance = 10;
            int dPS = (damage * atkSpd);

            Fighter h1 = new Fighter(name, maxHealth, currHealth, damage, atkSpd, dPS, atkRdy, missChance, critRate, dodgeChance);

            Console.WriteLine("Enter the name of your enemy.");
            string e1name = Console.ReadLine();
            Console.WriteLine("How much health does " + e1name + " have?");
            int e1maxHealth = Convert.ToInt32(Console.ReadLine());
            int e1currHealth = e1maxHealth;
            Console.WriteLine("How much damage does " + e1name + " do per attack?");
            int e1damage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("With 1 being very slow, and 10 being very fast, how fast does " + e1name + " attack?");
            int e1atkSpd = Convert.ToInt32(Console.ReadLine());
            int e1DPS = (e1damage + e1atkSpd);

            Fighter e1 = new Fighter(e1name, e1maxHealth, e1currHealth, e1damage, e1atkSpd, e1DPS, atkRdy, missChance, critRate, dodgeChance);

            Random rnd = new Random();

            while (h1.CurrHealth > 0 && e1.CurrHealth > 0)
            {
                h1.AtkRdy += h1.AtkSpd;
                if (h1.AtkRdy >= 50)
                {
                    h1.AtkRdy -= 50;
                    int Outcome = rnd.Next(1, 100);
                    Console.WriteLine("(" + h1.Name + " rolled " + Outcome + ")");
                    if (Outcome < h1.MissChance)
                    {
                        Console.WriteLine(h1.Name + " misses " + e1.Name);
                    }
                    else if (Outcome < h1.MissChance + e1.DodgeChance)
                    {
                        Console.WriteLine(e1.Name + " dodged " + h1.Name + "'s attack!");
                    }
                    else if (Outcome < h1.MissChance + e1.DodgeChance + h1.CritRate)
                    {
                        e1.CurrHealth -= (h1.Damage * 2);
                        Console.WriteLine("A critical strike! " + h1.Name + " hits " + e1.Name + " for " + (h1.Damage * 2) + ". " + e1.Name + " has " + e1.CurrHealth + " remaining.");
                    }
                    else
                    {
                        e1.CurrHealth -= h1.Damage;
                        Console.WriteLine(h1.Name + " hits " + e1.Name + " for " + h1.Damage + ". " + e1.Name + " has " + e1.CurrHealth + " remaining.");
                    }
                    if (e1.CurrHealth <= 0)
                    {
                        double h1HealthRemaining = h1.CurrHealth / h1.MaxHealth * 100;
                        Console.WriteLine(h1.Name + " has defeated " + e1.Name + " with " + h1HealthRemaining + "% health remaining.");
                        break;
                    }
                }
                e1.AtkRdy += e1.AtkSpd;
                if (e1.AtkRdy >= 50)
                {
                    e1.AtkRdy -= 50;
                    int Outcome = rnd.Next(1, 100);
                    Console.WriteLine("(" + e1.Name + " rolled " + Outcome + ")");
                    if (Outcome < e1.MissChance)
                    {
                        Console.WriteLine(e1.Name + " misses " + h1.Name);
                    }
                    else if (Outcome < e1.MissChance + h1.DodgeChance)
                    {
                        Console.WriteLine(h1.Name + " dodged " + e1.Name + "'s attack!");
                    }
                    else if (Outcome < e1.MissChance + h1.DodgeChance + e1.CritRate)
                    {
                        h1.CurrHealth -= (e1.Damage * 2);
                        Console.WriteLine("A critical strike! " + e1.Name + " hits " + h1.Name + " for " + (e1.Damage * 2) + ". " + h1.Name + " has " + h1.CurrHealth + " remaining.");
                    }
                    else
                    {
                        h1.CurrHealth -= e1.Damage;
                        Console.WriteLine(e1.Name + " hits " + h1.Name + " for " + e1.Damage + ". " + h1.Name + " has " + h1.CurrHealth + " remaining.");
                    }
                    if (h1.CurrHealth <= 0)
                    {
                        double e1HealthRemaining = e1.CurrHealth / e1.MaxHealth * 100;
                        Console.WriteLine(e1.Name + " has defeated " + h1.Name + " with " + e1HealthRemaining + "% health remaining.");
                        break;
                    }
                }
            }
            Console.WriteLine("Press enter key when ready to exit."); // or R to restart
            Console.ReadLine();
        }
    }
}
