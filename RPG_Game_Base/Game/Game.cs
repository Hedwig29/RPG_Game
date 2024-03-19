using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Game
{
    public class Game
    {
        private bool End { get; set; }

        public void StartGame()
        {
            Dialogues.Intro();
            this.MainGame();
        }

        private void MainGame()
        {
            var game = new GameState();
            while (!this.End)
            {
                Console.WriteLine("1. Start the game / Keep playing.");
                Console.WriteLine("2. Quit game.");
                int choice = StandardFunctions.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        game.StartGame();
                        break;

                    case 2:
                        this.End = true;
                        break;
                }
            }
        }
    }
}
