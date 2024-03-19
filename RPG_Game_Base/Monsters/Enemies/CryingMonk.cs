using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters.Enemies
{
    internal class CryingMonk : IEnemy
    {
        public CryingMonk()
        {
            this.Hp = 777;
            this.MinDmg = 77;
            this.MaxDmg = 99;
            this.Exp = 10000;
            this.Gold = 50;
            this.Name = "Crying Monk";
        }

        public int Hp { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }
    }
}
