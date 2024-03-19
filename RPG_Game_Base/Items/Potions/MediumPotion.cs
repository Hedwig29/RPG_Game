using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Items.Potions
{
    public class MediumPotion : IItem
    {
        public MediumPotion()
        {
            this.Id = 2;
            this.Name = "Medium healing potion";
            this.Price = 50;
            this.RestoreHP = 50;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int RestoreHP { get; set; }
    }
}

