using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game_Base.Monsters.Enemies
{
    internal class Ra : IEnemy
    {
        public Ra()
        {
            this.Hp = 2500;
            this.MinDmg = 100;
            this.MaxDmg = 150;
            this.Exp = 0;
            this.Gold = 50000;
            this.Name = "God Ra";
        }

        public int Hp { get; set; }

        public int MinDmg { get; set; }

        public int MaxDmg { get; set; }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public string Name
        {
            get; set;
        }
    }
}
