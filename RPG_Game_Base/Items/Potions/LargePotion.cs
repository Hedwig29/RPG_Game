using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Items.Potions
{
    public class LargePotion : IItem
    {
        public LargePotion()
        {
            this.Id = 3;
            this.Name = "Large healing potion";
            this.Price = 100;
            this.RestoreHP = 100;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int RestoreHP { get; set; }
    }
}
