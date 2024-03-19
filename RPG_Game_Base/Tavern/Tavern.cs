using RPG_Game_Base.Classes;
using RPG_Game_Base.Tavern.tavernopt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Tavern
{
    public static class Tavern
    {
        public static void TavernOptions(IClass characterClass)
        {
            var bar = new Bar();
            while (true)
            {
                Console.WriteLine("Welcome to the tavern! What you want to do?");
                Console.WriteLine("1. Go to the bar and talk to the bartender.");
                Console.WriteLine("2.Leave the tavern.");

                var choice = StandardFunctions.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        bar.BarOptions(characterClass);
                        break;
                    case 2:
                        Console.WriteLine("Do zobaczenia!");
                        return;

                    default:
                        StandardFunctions.NoOption();
                        break;
                }
            }
        }
    }
}
