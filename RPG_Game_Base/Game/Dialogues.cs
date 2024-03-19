using RPG_Game_Base.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Game
{
    public static class Dialogues
    {
        public static void NoGold()
        {
            var exp = new List<string>
            {
                "You don't have that much gold, you bastard!",
                "You don't have that much gold, loser!",
                "You loser, you don't even have gold!",
                "Poor thing, you don't even have gold!",
                "Boy, your pockets are completely empty!",
                "Let's see... you're looking for something you don't have? And that's bad luck, because you don't have that much gold!",
                "Your pockets are so empty you can hear the echoes in them!",
                "Gold doesn't grow on trees, so you have to get it somewhere else. But unfortunately, not now...",
                "Don't worry, you're in good company - a group of people who have no gold.",
                "Gold is the enemy, isn't it? That's why it always escapes from your wallet."
            };
            //string sentence = exp.GetRandomElement();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You don't have that much gold, you bastard!");
            Console.ResetColor();
        }


       


        public static void Intro()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to ancient Egypt, a time when the Pharaonic dynasty ruled...");
            StandardFunctions.Sleep();
            Console.WriteLine("The mysterious and magical pyramid of Khufu hides amazing treasures and the Holy Grail...");
            StandardFunctions.Sleep();
            Console.WriteLine("You are a brave adventurer who has gained access to a map showing the exact location of the Grail...");
            StandardFunctions.Sleep();
            Console.WriteLine("Finding the treasure will be quite a challenge, but you are determined and ready to take on this task...");
            StandardFunctions.Sleep();
            Console.WriteLine("Your expedition begins in a remote city, thousands of kilometers away from your destination...");
            StandardFunctions.Sleep();
            Console.WriteLine("You have no idea how to get there, but you believe in your skills and luck...");
            StandardFunctions.Sleep();
            Console.WriteLine("You will discover the secrets of the pyramid, fight dangerous duels with formidable opponents and make many decisions that will influence your further fate...");
            StandardFunctions.Sleep();
            Console.WriteLine("Will you be able to find the Holy Grail? See for yourself...");
            StandardFunctions.Sleep();
            Console.ResetColor();
        }


        public static void Ending()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nGod Ra falls before you...");
            StandardFunctions.Sleep();
            Console.WriteLine("You see that behind him there is a certain chest...");
            StandardFunctions.Sleep();
            Console.WriteLine("It is a chest of gold and inside it should be the Holy Grail...");
            StandardFunctions.Sleep();
            Console.WriteLine("You approach the chest and open it with difficulty...");
            StandardFunctions.Sleep();
            Console.WriteLine("The glow from within blinds you for a moment...");
            StandardFunctions.Sleep();
            Console.WriteLine("As your eyes adjust to the light, you will see that the chest contains strange materials and objects, made of something that looks like gold, but is not...");
            StandardFunctions.Sleep();
            Console.WriteLine("It is possible that they come from another world, another reality that you have managed to pass through...");
            StandardFunctions.Sleep();
            Console.WriteLine("You are looking for the holy grail, but you cannot find it. Instead, among the objects, you notice something that catches your attention - a beautiful dagger with golden decorations that sparkles...");
            StandardFunctions.Sleep();
            Console.WriteLine("You take it and a few other things, including a map that can guide you to your destination...");
            StandardFunctions.Sleep();
            Console.WriteLine("You will definitely understand it when the right opportunity arises. Knowing that there are still many adventures ahead of you, you decide to hit the road...");
            StandardFunctions.Sleep();
            Console.WriteLine("Maybe you will be able to find the holy grail and fulfill your dreams?...");
            StandardFunctions.Sleep();
            Console.WriteLine("--- END OF THE GAME ---");
            StandardFunctions.Sleep();
            Console.ResetColor();
        }


        public static void PyramidHistory()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You found yourself in front of Khufu's mighty pyramid, which had tempted people for centuries with its riches and secrets.");
            StandardFunctions.Sleep();
            Console.WriteLine("You enter its interior, deep into dark corridors that hide extraordinary secrets.");
            StandardFunctions.Sleep();
            Console.WriteLine("At first, the light from your torch is strong, but the further you go, the weaker it shines, revealing only the outlines of unknown objects.");
            StandardFunctions.Sleep();
            Console.WriteLine("You feel stone stairs under your feet, and on the sides you see countless corridors, each of which may hide danger.");
            StandardFunctions.Sleep();
            Console.WriteLine("You will always succeed because you have a goal that attracts you more than gold - the holy grail.");
            StandardFunctions.Sleep();
            Console.WriteLine("Eventually you reach a huge room where the walls are decorated with paintings depicting legends about the pyramid and its rulers.");
            StandardFunctions.Sleep();
            Console.WriteLine("You stand in front of two dog-shaped statues whose wisdom astounds everyone who encounters them.");
            StandardFunctions.Sleep();
            Console.WriteLine("And behind them, in the shadows, the greatest of puzzles awaits you, the solution of which is the secret of immortality.");
            StandardFunctions.Sleep();
            Console.ResetColor();
        }


        public static void AfterGuards()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nAnubis fall under your sword, their bodies crumbling to dust.");
            StandardFunctions.Sleep();
            Console.WriteLine("However, suddenly you will feel the divine power that has been released from them, restoring your full strength!");
            StandardFunctions.Sleep();
            Console.WriteLine("\nSuddenly, the mysterious figure sitting on the falcon-headed throne gets up.");
            StandardFunctions.Sleep();
            Console.WriteLine("It is the god Ra himself, the divine ruler of the Egyptian gods, with whom you must fight the final battle!");
            StandardFunctions.Sleep();
            Console.WriteLine("\nYour hands clutch a dagger made of unknown gold that is said to be able to defeat any opponent.");
            StandardFunctions.Sleep();
            Console.WriteLine("You don't know if it's true, but you can feel the heat rising in your veins.");
            StandardFunctions.Sleep();
            Console.WriteLine("\nThe God Ra looks at you with stern eyes, ready to fight.");
            StandardFunctions.Sleep();
            Console.WriteLine("Prepare for the last fight that will decide your fate and the fate of the Holy Grail!");
            StandardFunctions.Sleep();
            Console.ResetColor();
        }


        public static void ConvWithBarman(IClass characterClass)
        {
            if (characterClass != null)
            {
                int level = characterClass.Level;

                switch (level)
                {
                    case int n when n < 5:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (characterClass.GameStatus == 0)
                        {
                            Console.WriteLine("Boy! We had to hide from bandits for the last few days.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("They keep attacking us. I hope that the cavalry will finally come and sort them out.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("Apart from that, the same as always. We are waiting for a ship with goods to arrive.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("The best goods whiskey and rum... Ahh I need this!");
                            StandardFunctions.Sleep();
                            Console.WriteLine("For now, only pure spring water is available to give you strength!");
                            StandardFunctions.Sleep();
                            characterClass.GameStatus = 1;
                        }
                        else
                        {
                            Console.WriteLine("There is no new news at this time.");
                        }
                        Console.ResetColor();
                        break;

                    case int n when n >= 5 && n < 10:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (characterClass.GameStatus == 1)
                        {
                            Console.WriteLine("Recently, the bandit attacks have calmed down.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("I heard from people that there were wolves lurking in the nearby forests!");
                            StandardFunctions.Sleep();
                            Console.WriteLine("Strange, I haven't seen them for a long time.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("Oh, that ship I told you about has arrived.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("You can finally taste the best Scotch whiskey!");
                            StandardFunctions.Sleep();
                            characterClass.GameStatus = 2;
                        }
                        else
                        {
                            Console.WriteLine("There is no new news at this time.");
                        }
                        Console.ResetColor();
                        break;

                    case int n when n >= 10 && n < 20:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (characterClass.GameStatus == 2)
                        {
                            Console.WriteLine("It's you again. Currently, a lot of new people have arrived in the city.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("Since wolves and bandits stopped attacking in the nearby forest, the crossing is much safer.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("I learned from travelers who were feasting a few days ago that a caravan would arrive soon.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("They are going to go to the desert to look for some pyramids. If you want to go with them, talk to me after some time.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("I'll tell you where they are, and something else.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("I got a special drink from them. Straight from some Malbork. I'm afraid to try it.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("If you want, I can pour you a glass, but remember, these things aren't cheap!");
                            StandardFunctions.Sleep();
                            characterClass.GameStatus = 3;
                        }
                        else
                        {
                            Console.WriteLine("There is no new news at this time.");
                        }
                        Console.ResetColor();

                        break;

                    case int n when n == 20:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        if (characterClass.GameStatus == 3)
                        {
                            Console.WriteLine("And that's you! I have not seen you for a long time.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("A lot has changed. The area has become very safe. Lots of new faces coming through town!");
                            StandardFunctions.Sleep();
                            Console.WriteLine("The caravan arrived yesterday. It turns out that they are going to the Pyramid of Khufu!");
                            StandardFunctions.Sleep();
                            Console.WriteLine("Something like. This is probably your only chance to get there. Few people know the way to these distant areas.");
                            StandardFunctions.Sleep();
                            Console.WriteLine("They are located next to the entrance gate to the city. They're leaving soon, if you want to go, hurry!");
                            StandardFunctions.Sleep();
                            Console.WriteLine("It was nice talking to you. I hope our paths will cross again someday!");
                            StandardFunctions.Sleep();
                            characterClass.GameStatus = 4;
                        }
                        else
                        {
                            Console.WriteLine("There is no new news at this time.");
                        }
                        Console.ResetColor();
                        break;
                }
            }
        }
    }
}
