using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters.Enemies
{
    internal class WildBoar : IEnemy
    {
        public WildBoar()
        {
            this.Hp = 60;
            this.MinDmg = 11;
            this.MaxDmg = 18;
            this.Exp = 1300;
            this.Gold = 15;
            this.Name = " WildBoar";
        }

        public int Hp { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }
    }
}
