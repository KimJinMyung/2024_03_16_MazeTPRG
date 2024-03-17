using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Monster
{
    internal interface IMonsterAction
    {
        public bool Hurt(double damage);
        public bool Attack(Player player);

        public Monster Clone();

    }
}
