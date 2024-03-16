using MazeTPRG.Item.Armor.body;
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
            this.EffectValue = 1;
        }
        public void Equip()
        {
            equiped = true;
            Player.Instance.Equip(this.parts, this);
            Player.Instance.ArmorDefense(EffectValue);
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
                Equip();
                return true;
            }
            else
            {
                UnEquip();
                return false;
            }
        }
    }
}
