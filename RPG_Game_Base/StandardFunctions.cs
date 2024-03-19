using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base
{
    public static class StandardFunctions
    {
        private static readonly Random RandomDmg = new();

        public static void NoOption()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No options.");
            Console.ResetColor();
        }

        public static void DefaultOption() => Console.WriteLine("Default option 1.");

        public static bool ExitRoom()
        {
            Console.WriteLine("You're leaving ...");
            return false;
        }

        public static int RandDmg(int minDmg, int maxDmg)
        {
            lock (RandomDmg)
            {
                return RandomDmg.Next(minDmg, maxDmg + 1);
            }
        }

        public static int ToInt32(string value)
        {
            if (value == null)
            {
                return 0;
            }

            bool flag;
            do
            {
                try
                {
                    return int.Parse(value, (IFormatProvider)CultureInfo.CurrentCulture);
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong sign entered!");
                    Console.ResetColor();
                    Thread.Sleep(700);
                    flag = false;
                }
            } while (flag);

            return 0;
        }

      

        public static void Sleep()
        {
            Thread.Sleep(4000);
        }
    }
}
