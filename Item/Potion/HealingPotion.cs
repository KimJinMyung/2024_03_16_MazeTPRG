using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Potion
{
    internal class HealingPotion : Potion
    {
        public HealingPotion() 
        {
            this.name = "붉은 포션";
            this.EffectValue = 50;
        }

        public override bool Use()
        {
            Player.Instance.HealHP(this.EffectValue);
            return true;
        }
    }
}
