using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Simulator_Exe
{

    class Program
    {
        static void Main(string[] args)
        {

            string heroName;
            int heroMaxHealth;
            int heroDamage;
            int heroAtkSpd;
            int heroAtkRdy = 0;
            int heroMissChance = 3;
            string enemyName;
            int enemyMaxHealth;
            int enemyDamage;
            int enemyAtkSpd;
            int enemyAtkRdy = 0;
            int enemyMissChance = 3;

            // Welcome
            Console.WriteLine("Welcome to the Interdimensiseum!");
            // Define Hero
            Console.WriteLine(" Please enter the name of your hero: ");
            heroName = Console.ReadLine();
            Console.WriteLine("How much health does " + heroName + " have?");
            heroMaxHealth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much damage does " + heroName + " do per attack?");
            heroDamage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("With 1 being very slow, and 10 being very fast, how fast does " + heroName + " attack?");
            heroAtkSpd = Convert.ToInt32(Console.ReadLine());
            // Define Enemy
            Console.WriteLine(" Please enter the name of your enemy: ");
            enemyName = Console.ReadLine();
            Console.WriteLine("How much health does " + enemyName + " have?");
            enemyMaxHealth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How much damage does " + enemyName + " do per attack?");
            enemyDamage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("With 1 being very slow, and 10 being very fast, how fast does " + enemyName + " attack?");
            enemyAtkSpd = Convert.ToInt32(Console.ReadLine());

            int heroCurrHealth = heroMaxHealth;
            int enemyCurrHealth = enemyMaxHealth;
            Random rnd = new Random();

            while (heroCurrHealth > 0 && enemyCurrHealth > 0)
            {
                heroAtkRdy += heroAtkSpd;
                if (heroAtkRdy >= 50)
                {
                    heroAtkRdy -= 50;
                    int heroOutcome = rnd.Next(1, 100);
                    if (heroOutcome < 100 - heroMissChance)
                    {
                        enemyCurrHealth -= heroDamage;
                        Console.WriteLine(heroName + " hits " + enemyName + " for " + heroDamage + ". " + enemyName + " has " + enemyCurrHealth + " remaining.");
                        if (enemyCurrHealth <= 0)
                        {
                            Console.WriteLine(heroName + " has defeated " + enemyName);
                            break;
                        }
                    }
                }
                enemyAtkRdy += enemyAtkSpd;
                if (enemyAtkRdy >= 50)
                {
                    enemyAtkRdy -= 50;
                    int enemyOutcome = rnd.Next(1, 100);
                    if (enemyOutcome < 100 - enemyMissChance)
                    {
                        heroCurrHealth -= enemyDamage;
                        Console.WriteLine(enemyName + " hits " + heroName + " for " + enemyDamage + ". " + heroName + " has " + heroCurrHealth + " remaining.");
                        if (heroCurrHealth <= 0)
                        {
                            Console.WriteLine(enemyName + " has defeated " + heroName);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("Press enter key when ready to exit."); // or R to restart
            Console.ReadLine();
        }
    }
}
