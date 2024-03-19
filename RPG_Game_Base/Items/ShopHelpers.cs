using RPG_Game_Base;
using RPG_Game_Base.Classes;
using RPG_Game_Base.Items;
using RPG_Game_Base.Items.Potions;

internal static class ShopHelpers
{
    public static void PotionShop(IClass characterClass)
    {
        if (characterClass == null)
        {
            return;
        }

        bool value = true;
        while (value)
        {
            Console.WriteLine("What you want to do:");
            Console.WriteLine("1: Buy a small healing potion. 20g");
            Console.WriteLine("2: Buy a medium healing potion. 50g");
            Console.WriteLine("3. Buy a large healing potion. 100g");
            Console.WriteLine("4. Leave the store.");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                StandardFunctions.NoOption();
                continue;
            }

            Console.Clear();

            switch (choice)
            {
                case 1:
                    BuyPotion(characterClass, new SmallPotion(), 20);
                    break;

                case 2:
                    BuyPotion(characterClass, new MediumPotion(), 50);
                    break;

                case 3:
                    BuyPotion(characterClass, new LargePotion(), 100);
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

    private static void BuyPotion(IClass characterClass, IItem potion, int price)
    {
        if (characterClass.Gold >= price)
        {
            characterClass.Inventory.Add(potion);
            characterClass.Gold -= price;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You bought it {potion.Name}!\n");
            Console.ResetColor();
        }
        else
        {

        }
    }
}