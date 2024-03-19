using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters.Enemies
{
    internal class Anubis : IEnemy
    {
        public Anubis()
        {
            this.Hp = 1000;
            this.MinDmg = 70;
            this.MaxDmg = 120;
            this.Exp = 0;
            this.Gold = 5000;
            this.Name = "Anubis";
        }

        public int Hp { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }
    }
}

