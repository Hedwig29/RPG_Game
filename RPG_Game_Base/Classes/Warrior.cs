using RPG_Game_Base.Items;
using RPG_Game_Base.Monsters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Classes
{
    internal class Warrior : IClass
    {
        private int nextLevel = 2;

        public Warrior(string name)
        {
            this.Vit = 15;
            this.Hp = this.Vit * 15;
            this.MaxHP = this.Vit * 15;
            this.Str = 4;
            this.Dex = 2;
            this.Exp = 0;
            this.MaxExp = 1000;
            this.Level = 0;
            this.Name = name;
            this.Gold = 1;
            this.MinDmg = 2;
            this.MaxDmg = 7;
            this.Armor = 0;
            this.AttakChance = 60;
            this.CriticalAttackChance = 25;
            this.ClassType = 1;
            this.GameStatus = 0;
            this.Inventory = new List<IItem>();
        }


        public int Hp { get; set; }

        public int MaxHP { get; set; }

        public int Vit { get; set; }

        public int Str { get; set; }

        public int Dex { get; set; }

        public double Exp { get; set; }

        public double MaxExp { get; set; }

        public int Level { get; set; }

        public string Name { get; set; }

        public int Gold { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Armor { get; set; }

        public double AttakChance { get; set; }

        public double CriticalAttackChance { get; set; }

        public int ClassType { get; set; }

        public int GameStatus { get; set; }

        public List<IItem> Inventory { get; }

        public void Attack(IEnemy enemy)
        {
            Console.WriteLine("\nAttack:");
            Console.WriteLine($"1. Normal attack ({this.MinDmg} - {this.MaxDmg}dmg). Chance to hit {this.AttakChance + 20}.");
            Console.WriteLine($"2. Strong attack. Chance to hit {this.AttakChance}.Critical hit chance {this.CriticalAttackChance}.");
            Console.WriteLine($"3. Three way cut ({this.MinDmg + this.Dex} - {this.MaxDmg + this.Dex}dmg). Chance to hit {this.AttakChance}.");
            int choice = StandardFunctions.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    this.NormalAttack(enemy);
                    break;

                case 2:
                    this.StrongAttack(enemy);
                    break;

                case 3:
                    this.ThreeWayCut(enemy);
                    break;

                default:
                    this.NormalAttack(enemy);
                    StandardFunctions.DefaultOption();
                    break;
            }
        }

        public void AddLevel()
        {
            if (this.Level != 20)
            {
                if (this.Exp >= this.MaxExp)
                {
                    this.LevelUP();
                }
            }
            else
            {
                this.Exp = 0;
            }
        }

        public void UpdateStats()
        {
            this.Hp = this.Vit * 15;
            this.MaxHP = this.Vit * 15;
            this.MinDmg += this.Str / 3;
            this.MaxDmg += this.Str / 2;
            this.Armor += this.Dex / 2;
        }


        private static void DealDmg(IEnemy enemy, int realDmg)
        {
            if (realDmg == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nYou missed!. The opponent health: {enemy.Hp}");
                Console.ResetColor();
            }
            else if (enemy != null)
            {
                enemy.Hp -= realDmg;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You dealt {realDmg}. The opponent health: {enemy.Hp}");
                Console.ResetColor();
            }
        }

        private void ThreeWayCut(IEnemy enemy)
        {
            double chance = StandardFunctions.RandDmg(0, 100);
            int realDmg;
            if (chance < this.AttakChance)
            {
                chance = StandardFunctions.RandDmg(0, 100);
                if (chance < this.AttakChance)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou landed a three-way chop!");
                    Console.ResetColor();
                    realDmg = StandardFunctions.RandDmg(this.MinDmg + this.Dex, this.MaxDmg + this.Dex);
                    DealDmg(enemy, realDmg);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nYou hit 1 cut!");
                    Console.ResetColor();
                    realDmg = StandardFunctions.RandDmg(this.MinDmg - this.Dex - 1, this.MaxDmg - this.Dex - 1);
                    DealDmg(enemy, realDmg);
                }
            }
            else
            {
                realDmg = 0;
                DealDmg(enemy, realDmg);
            }
        }

        private void StrongAttack(IEnemy enemy)
        {
            double chance = StandardFunctions.RandDmg(0, 100);
            int realDmg;
            if (chance < this.AttakChance)
            {
                chance = StandardFunctions.RandDmg(0, 100);
                if (chance < this.CriticalAttackChance)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\nYou've landed a critical hit!");
                    Console.ResetColor();
                    realDmg = StandardFunctions.RandDmg(this.MinDmg, this.MaxDmg) * 2;
                    DealDmg(enemy, realDmg);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThe opponent got it!");
                    Console.ResetColor();
                    realDmg = StandardFunctions.RandDmg(this.MinDmg, this.MaxDmg);
                    DealDmg(enemy, realDmg);
                }
            }
            else
            {
                realDmg = 0;
                DealDmg(enemy, realDmg);
            }
        }

        private void NormalAttack(IEnemy enemy)
        {
            double chance = StandardFunctions.RandDmg(0, 100);
            int realDmg;
            if (chance < this.AttakChance + 20)
            {
                Console.WriteLine("\nThe opponent got it!");
                realDmg = StandardFunctions.RandDmg(this.MinDmg, this.MaxDmg);
                DealDmg(enemy, realDmg);
            }
            else
            {
                realDmg = 0;
                DealDmg(enemy, realDmg);
            }
        }

        private void LevelUP()
        {
            this.Vit += 2;
            this.Str += 3;
            this.Dex++;
            this.Exp -= this.MaxExp;
            this.Level++;
            this.nextLevel++;
            this.AttakChance += 1.5;
            this.CriticalAttackChance += 1.5;
            this.MaxExp = (250 * (this.nextLevel - 1) * this.nextLevel) - this.MaxExp;
            this.UpdateStats();
            if (this.Level != 20)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Congratulations, you've leveled up {Level}!!!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Congratulations, you've reached the maximum level {Level}");
                Console.ResetColor();
            }
        }
    }
}
