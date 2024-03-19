using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Items.Potions
{
    public class SmallPotion : IItem
    {
        public SmallPotion()
        {
            this.Id = 1;
            this.Name = "A small healing potion";
            this.Price = 20;
            this.RestoreHP = 20;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int RestoreHP { get; set; }
    }
}
