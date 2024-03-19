using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters.Enemies
{
    internal class Thief : IEnemy
    {
        public Thief()
        {
            this.Hp = 20;
            this.MinDmg = 2;
            this.MaxDmg = 12;
            this.Exp = 500;
            this.Gold = 5;
            this.Name = "Thief";
        }

        public int Hp { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }
    }
}
