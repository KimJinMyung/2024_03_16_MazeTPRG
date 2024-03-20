using MazeTPRG.Item.Armor.body;
using MazeTPRG.Item.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Armor.head
{
    internal class LeatherHat : foot
    {
        private bool equiped;
        public LeatherHat()
        {
            this.name = "가죽 모자";
            this.EffectValue = 3;
        }
        public override itemClass Clone()
        {
            return new LeatherHat();
        }

        public bool Equip()
        {
            equiped = true;
            if (Player.Instance.Equip(this.parts, this))
            {
                Player.Instance.ArmorDefense(EffectValue);
                return true;
            }
            return false;
        }

        public void UnEquip()
        {
            equiped = false;
            Player.Instance.UnEquip(this.parts);
            Player.Instance.ArmorDefense(-EffectValue);
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
