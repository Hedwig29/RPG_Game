using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters.Enemies
{
    internal class Wolf : IEnemy
    {
        public Wolf()
        {
            this.Hp = 40;
            this.MinDmg = 9;
            this.MaxDmg = 15;
            this.Exp = 1000;
            this.Gold = 10;
            this.Name = "Wolf";
        }

        public int Hp { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }
    }
}
