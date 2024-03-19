using RPG_Game_Base.Classes;
using RPG_Game_Base.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Tavern.tavernopt
{
    public class Bar
    {
        private bool specialDrink = true;

        public void BarOptions(IClass characterClass)
        {
            if (characterClass != null)
            {
                bool value = true;
                while (value)
                {
                    Console.WriteLine("What you want to do:");
                    Console.WriteLine("1.Ask the bartender what's going on in the area.");
                    Console.WriteLine("2.Have a drink.");
                    Console.WriteLine("3. Show me your goods.");
                    Console.WriteLine("4. Leave the bar.");
                    int choice = StandardFunctions.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            Dialogues.ConvWithBarman(characterClass);
                            break;

                        case 2:
                            this.DrinkSmth(characterClass);
                            break;

                        case 3:
                            Bar.ShowGoods();
                            break;

                        case 4:
                            value = StandardFunctions.ExitRoom();
                            break;

                        default:
                            StandardFunctions.NoOption();
                            break;
                    }
                }
            }
        }


        private static void DrinkWater(IClass characterClass)
        {
            if (characterClass.Gold < 5)
            {
                Dialogues.NoGold();
            }
            else
            {
                if (characterClass.Level < 5)
                {
                    Console.WriteLine("You drank water from the spring.");
                    Console.WriteLine("You felt your body regaining strength!");
                    characterClass.Exp += 5;
                    characterClass.Gold -= 5;
                    characterClass.AddLevel();
                    characterClass.UpdateStats();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your experience points have increased by 5.");
                    Console.WriteLine("Your stats increased by 1.");
                    Console.ResetColor();
                }
                else if (characterClass.Level >= 5)
                {
                    Console.WriteLine("You drank water from the spring.");
                    Console.WriteLine("You felt your body regaining strength!");
                    characterClass.Gold -= 5;
                    characterClass.UpdateStats();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("You are already at such a high level that the water no longer gives you any experience.");
                    Console.WriteLine("Your stats increased by 1.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your level is too low to drink water from the spring!");
                    Console.ResetColor();
                }
            }
        }


        private static void DrinkWhisky(IClass characterClass)
        {
            if (characterClass.Gold < 15)
            {
                Dialogues.NoGold();
            }
            else
            {
                if (characterClass.Level >= 5 && characterClass.Level < 10)
                {
                    characterClass.Exp += 5;
                    characterClass.Gold -= 15;
                    characterClass.AddLevel();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your experience points have increased by 5.");
                    Console.ResetColor();
                }
                else if (characterClass.Level >= 10)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Your level is too high!");
                    Console.WriteLine("You just drank whiskey!");
                    Console.ResetColor();
                    characterClass.Gold -= 15;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your level is too low to drink Whiskey!!!");
                    Console.ResetColor();
                }
            }
        }

        private static void ShowGoods()
        {
            ////To do + equipment
        }

        private void DrinkSmth(IClass characterClass)
        {
            bool value = true;
            while (value)
            {
                Console.WriteLine("What you want to do:");
                Console.WriteLine("1: Order a glass of water /5g");
                Console.WriteLine("2: Order a glass of good whiskey /15g");
                Console.WriteLine("3. Order something special /150g");
                Console.WriteLine("4. Quit.");
                int choice = StandardFunctions.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        Bar.DrinkWater(characterClass);
                        break;

                    case 2:
                        Bar.DrinkWhisky(characterClass);
                        break;

                    case 3:
                        this.DrinkSmthSpecial(characterClass);
                        break;

                    case 4:
                        value = StandardFunctions.ExitRoom();
                        break;

                    default:
                        StandardFunctions.NoOption();
                        break;
                }
            }
        }

        private void DrinkSmthSpecial(IClass characterClass)
        {
            if (this.specialDrink)
            {
                if (characterClass.Gold < 150)
                {
                    Dialogues.NoGold();
                }
                else
                {
                    if (characterClass.Level >= 15)
                    {
                        Console.WriteLine("Drink a specialty straight from the Teutonic Knights from Marlbork!");
                        Console.WriteLine("Mead called Grunwald! Something fabulous!");
                        Console.WriteLine("You drank the legendary mead that comes from feast tables before the Battle of Grunwald.");

                        characterClass.Gold -= 150;

                        Console.WriteLine("Your experience points have increased by 5,000.");

                        int statChoice = -1;
                        while (statChoice < 1 || statChoice > 3)
                        {
                            Console.WriteLine("Select which stats you want to increase:");
                            Console.WriteLine("1: Strength");
                            Console.WriteLine("2: Dexterity");
                            Console.WriteLine("3: Vitality");

                            statChoice = StandardFunctions.ToInt32(Console.ReadLine());

                            if (statChoice < 1 || statChoice > 3)
                            {
                                Console.WriteLine("Wrong value. Choose a number from 1 to 3.");
                            }
                        }

                        switch (statChoice)
                        {
                            case 1:
                                characterClass.Str += 5;
                                break;
                            case 2:
                                characterClass.Dex += 5;
                                break;
                            case 3:
                                characterClass.Vit += 5;
                                break;
                        }

                        characterClass.Exp += 5000;
                        characterClass.AddLevel();
                        characterClass.UpdateStats();
                        this.specialDrink = false;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your selected stat has been increased by 5.");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are too weak to taste this specialty!");
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It was the only play, unfortunately.");
                Console.WriteLine("I don't know if I will ever get similar goods.");
                Console.ResetColor();
            }
        }
    }
}
