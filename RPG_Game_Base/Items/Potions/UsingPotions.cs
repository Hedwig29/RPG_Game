using RPG_Game_Base.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Items.Potions
{
    public static class UsingPotions
    {
        public static void PotionOptions(IClass characterClass)
        {
            if (characterClass != null)
            {
                bool value = true;
                while (value)
                {
                    Console.WriteLine("What you want to do:");
                    Console.WriteLine("1: View the potions you have in your bag.");
                    Console.WriteLine("2: Drink one of the potions.");
                    Console.WriteLine("3:Quit.");
                    int choice = StandardFunctions.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            ShowPotions(characterClass);
                            break;

                        case 2:
                            value = DrinkPotion(characterClass);
                            break;

                        case 3:
                            value = StandardFunctions.ExitRoom();
                            break;

                        default:
                            StandardFunctions.NoOption();
                            break;
                    }
                }
            }
        }

        private static bool DrinkPotion(IClass characterClass)
        {
            bool value = true;
            while (value)
            {
                Console.WriteLine("What you want to do:");
                Console.WriteLine("1: Drink a small mixture.");
                Console.WriteLine("2: Drink a medium mixture.");
                Console.WriteLine("3. Drink a large mixture.");
                Console.WriteLine("4. Leave the tavern.");
                int choice = StandardFunctions.ToInt32(Console.ReadLine());
                Console.Clear();
                if (choice > 0 && choice <= 3)
                {
                    if (characterClass.Hp == characterClass.MaxHP)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"You have maximum life points {characterClass.Hp}!");
                        Console.ResetColor();
                    }
                    else
                    {
                        var foundPotion = characterClass.Inventory.Find(s => s.Id == choice);
                        if (foundPotion != null)
                        {
                            var previousHP = characterClass.Hp;
                            characterClass.Hp += foundPotion.RestoreHP;
                            if (characterClass.Hp > previousHP)
                            {
                                characterClass.Hp = characterClass.MaxHP;
                            }

                            characterClass.Inventory.Remove(foundPotion);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You have healed yourself.\nYour life points are {characterClass.Hp}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You don't have these potions!");
                            Console.ResetColor();
                        }
                    }
                }

                if (choice == 4)
                {
                    value = StandardFunctions.ExitRoom();
                }
                else
                {
                    StandardFunctions.NoOption();
                }
            }

            return value;
        }

        private static void ShowPotions(IClass characterClass)
        {
            var duplicates = characterClass.Inventory
                .GroupBy(x => new { x.Name })
                .Select(group => new { Name = group.Key, Count = group.Count() })
                .OrderByDescending(x => x.Count);
            if (duplicates == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You don't have any potions!");
                Console.ResetColor();
            }
            else
            {
                foreach (var x in duplicates)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Quantity: " + x.Count + " " + x.Name);
                    Console.ResetColor();
                }
            }
        }
    }
}
