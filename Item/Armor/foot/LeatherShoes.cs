using MazeTPRG.Item.Armor.body;
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
