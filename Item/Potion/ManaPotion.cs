using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Potion
{
    internal class ManaPotion : Potion
    {
        public ManaPotion()
        {
            this.name = "푸른 포션";
            this.EffectValue = 50;
        }

        public override bool Use()
        {
            Player.Instance.HealMP(this.EffectValue);
            return true;
        }
    }
}
