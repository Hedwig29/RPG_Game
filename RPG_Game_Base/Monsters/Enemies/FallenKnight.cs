using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters.Enemies
{
    internal class FallenKnight : IEnemy
    {
        public FallenKnight()
        {
            this.Hp = 120;
            this.MinDmg = 40;
            this.MaxDmg = 57;
            this.Exp = 3500;
            this.Gold = 35;
            this.Name = "Fallen Knight";
        }

        public int Hp { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public string Name { get; set; }
    }
}
