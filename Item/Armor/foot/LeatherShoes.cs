using MazeTPRG.Item.Armor.body;
using MazeTPRG.Item.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Armor.foot
{
    internal class LeatherShoes : foot
    {
        private bool equiped;
        public LeatherShoes()
        {
            this.name = "가죽 신발";
            this.EffectValue = 2;
        }
        public override itemClass Clone()
        {
            return new LeatherShoes();
        }
        public bool Equip()
        {
            equiped = true;
            if (Player.Instance.Equip(this.parts, this))
            {
                Player.Instance.SpeedUp(EffectValue);
                return true;
            }
            return false;
        }

        public void UnEquip()
        {
            equiped = false;
            Player.Instance.UnEquip(this.parts);
            Player.Instance.SpeedUp(-EffectValue);
        }

        public override bool Use()
        {
            if (!equiped)
            {
                if (Equip()) return true;
                else return false;
            }
            else
            {
                UnEquip();
                return false;
            }
        }
    }
}
