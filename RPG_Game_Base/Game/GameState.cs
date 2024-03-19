
using RPG_Game_Base.Classes;
using RPG_Game_Base.Items.Potions;
using RPG_Game_Base.Items;
using RPG_Game_Base.Monsters.Enemies;
using RPG_Game_Base.Monsters;


namespace RPG_Game_Base.Game
{
    public class GameState
    {
        private readonly ClassState stateVariables = new();

        private List<IEnemy> enemy = new();

        private IClass characterClass;

        private bool game = true;

        public GameState()
        {
            Console.WriteLine("1: New game.");
            int choice = StandardFunctions.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Put your name: ");
                    var name = Console.ReadLine();
                    Console.Clear();
                    this.Name = name;
                    this.SelectClass();
                    break;

                default:
                    StandardFunctions.NoOption();
                    break;
            }
        }

        public string Name { get; set; }

        public void StartGame()
        {
            this.game = true;

            while (this.game)
            {
                if (this.characterClass.Level < 20)
                {
                    Console.WriteLine("What you want to do:");
                    Console.WriteLine("1: Hit the road.");
                    Console.WriteLine("2: Go to the tavern.");
                    Console.WriteLine("3: Go to the shop.");
                    Console.WriteLine("4: Show hero stats.");
                    Console.WriteLine("5: Equipment.");
                    Console.WriteLine("6: End the game.");

                    int choice = StandardFunctions.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (choice)
                    {
                        case 1:
                            if (GameStatus.CheckGameStatus(this.characterClass))
                                this.FightOpponents();
                            break;

                        case 2:
                            Tavern.Tavern.TavernOptions(this.characterClass);
                            break;

                        case 3:
                            Shop.PotionShop(this.characterClass);
                            break;

                        case 4:
                            this.ShowStats();
                            break;

                        case 5:
                            UsingPotions.PotionOptions(this.characterClass);
                            break;

                        case 6:
                            this.game = false;
                            break;

                        default:
                            StandardFunctions.NoOption();
                            break;
                    }
                }
                else if (this.characterClass.Level == 20)
                {
                    Console.WriteLine("What you want to do:");
                    Console.WriteLine("1: Set off with the caravan to the pyramids.");
                    Console.WriteLine("2: Go to the tavern.");
                    Console.WriteLine("3: Show hero stats.");
                    Console.WriteLine("4: Equipment.");
                    Console.WriteLine("5: End the game.");

                    int choice = StandardFunctions.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (choice)
                    {
                        case 1:
                            this.FinalBoss();
                            break;

                        case 2:
                            Tavern.Tavern.TavernOptions(this.characterClass);
                            break;

                        case 3:
                            this.ShowStats();
                            break;

                        case 4:
                            UsingPotions.PotionOptions(this.characterClass);
                            break;

                        case 5:
                            this.game = false;
                            break;

                        default:
                            StandardFunctions.NoOption();
                            break;
                    }
                }
                else if (this.characterClass.Level > 20)
                {
                    Console.WriteLine("You won! You can turn off the game.");
                    this.game = false;
                }

                if (!this.characterClass.IsAlive())
                {
                    Console.WriteLine("You have been defeated.");
                    Console.WriteLine("End of the game.");
                    this.game = false;
                }
            }
        }


        private void FightOpponents()
        {
            GenerateEnemies.SelectOpponents(this.characterClass, this.enemy);
            this.enemy = this.enemy.OrderBy(_ => Guid.NewGuid()).ToList();
            this.Fight();
            this.enemy.Clear();
        }

        private void FinalBoss()
        {
            Dialogues.PyramidHistory();
            this.enemy.Add(new Anubis());
            this.enemy.Add(new Anubis());
            this.Fight();
            this.enemy.Clear();
            Dialogues.AfterGuards();
            this.characterClass.Hp = this.characterClass.MaxHP;
            this.enemy.Add(new Ra());
            this.Fight();
            this.enemy.Clear();
            this.characterClass.Level++;
            Dialogues.Ending();
            this.game = false;
        }

        private void Fight()
        {
            foreach (var enemy in new List<IEnemy>(this.enemy))
            {
                Console.WriteLine($"\nYou met your opponent: {enemy.Name}. Get ready to fight!!!");
                StandardFunctions.Sleep();
                while (enemy.IsAlive())
                {
                    Console.WriteLine($"{enemy.Name}attacks!");
                    enemy.Attack(this.characterClass);
                    this.characterClass.Attack(enemy);

                    if (!this.characterClass.IsAlive())
                    {
                        Console.WriteLine("You have been defeated!");
                        Console.WriteLine("End of the game!");
                        Environment.Exit(-1);
                    }
                    else if (!enemy.IsAlive())
                    {
                        Console.Clear();
                        Console.WriteLine("You defeated your opponent!");
                        this.characterClass.Gold += enemy.Gold;
                        if (this.characterClass.Level < 20)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.WriteLine($"You have gained {enemy.Exp} experience points!");
                            Console.WriteLine($"You have gained {enemy.Gold} gold !");
                            Console.ResetColor();
                            this.characterClass.Exp += enemy.Exp;
                            this.characterClass.AddLevel();
                        }

                        this.enemy.Remove(enemy);
                    }
                }
            }
        }

        private void SelectClass()
        {
            while (this.game)
            {
                Console.WriteLine("Select a class:");
                Console.WriteLine("1: Warrior.");
                Console.WriteLine("2: Archer.");
                Console.WriteLine("3. Assassin.");
                int choice = StandardFunctions.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        this.characterClass = new Warrior(this.Name);
                        this.game = false;
                        break;

                    case 2:
                        this.characterClass = new Archer(this.Name);
                        this.game = false;
                        break;

                    case 3:
                        this.characterClass = new Assassin(this.Name);
                        this.game = false;
                        break;

                    default:
                        StandardFunctions.NoOption();
                        break;
                }
            }
        }

        private void ShowStats()
        {
            Console.WriteLine("-------------------");
            Console.WriteLine($"Name: {this.characterClass.Name}");
            Console.WriteLine($"Health points: {this.characterClass.Hp}/{this.characterClass.MaxHP}");
            Console.WriteLine($"Level: {this.characterClass.Level}");

            if (this.characterClass.Level < 20)
            {
                Console.WriteLine($"Experience: {this.characterClass.Exp}/{this.characterClass.MaxExp}");
            }
            else
            {
                Console.WriteLine($"You have the maximum level: {this.characterClass.Level}");
            }

            Console.WriteLine($"Attack: {this.characterClass.MinDmg} - {this.characterClass.MaxDmg}");
            Console.WriteLine($"Armor: {this.characterClass.Armor}");
            Console.WriteLine($"Gold: {this.characterClass.Gold}");
            Console.WriteLine("-------------------");
        }

    }
}
