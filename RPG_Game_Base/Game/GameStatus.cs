using RPG_Game_Base.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Game
{
    public static class GameStatus
    {
        public static bool CheckGameStatus(IClass characterClass)
        {
            if (characterClass.Level < 5 && characterClass.GameStatus == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before setting off on your journey, talk to the bartender at the tavern!");
                Console.ResetColor();
                return false;
            }
            else if (characterClass.Level >= 5 && characterClass.Level < 10 && characterClass.GameStatus == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before setting off on your journey, talk to the bartender at the tavern!");
                Console.ResetColor();
                return false;
            }
            else if (characterClass.Level >= 10 && characterClass.Level < 20 && characterClass.GameStatus == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before setting off on your journey, talk to the bartender at the tavern!");
                Console.ResetColor();
                return false;
            }
            else if (characterClass.Level == 20 && characterClass.GameStatus == 3)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Before setting off on your journey, talk to the bartender at the tavern!");
                Console.ResetColor();
                return false;
            }

            return true;
        }
    }
}
