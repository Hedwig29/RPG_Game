using RPG_Game_Base.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters
{
    public interface IEnemy
    {
        int Hp { get; set; }

        int MinDmg { get; set; }

        int MaxDmg { get; set; }

        int Exp { get; set; }

        int Gold { get; set; }

        string Name { get; set; }

        public void Attack(IClass characterClass)
        {
            if (characterClass != null)
            {
                int dmg = StandardFunctions.RandDmg(this.MinDmg, this.MaxDmg) - characterClass.Armor;
                if (dmg <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You took no damage!");
                    Console.ResetColor();
                }
                else
                {
                    characterClass.Hp -= dmg;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"You received  {dmg} damage! Your HP points {characterClass.Hp} / {characterClass.MaxHP}");
                    Console.ResetColor();
                }
            }
        }

        public bool IsAlive()
        {
            return this.Hp > 0;
        }
    }
}

