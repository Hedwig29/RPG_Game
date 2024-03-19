using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Items
{
    public interface IItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int RestoreHP { get; set; }
    }

}
