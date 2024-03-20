using MazeTPRG.Item.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Armor.body
{
    internal class LeatherBodyArmor : body
    {
        private bool equiped;
        public LeatherBodyArmor() 
        {
            this.name = "가죽 갑옷";
            this.EffectValue = 30;
        }
        public override itemClass Clone()
        {
            return new LeatherBodyArmor();
        }
        public bool Equip()
        {
            equiped = true;
            if (Player.Instance.Equip(this.parts, this))
            {
                Player.Instance.MaxHPUP(EffectValue);
                return true;
            }
            return false;
        }

        public void UnEquip()
        {
            equiped = false;
            Player.Instance.UnEquip(this.parts);
            Player.Instance.MaxHPUP(-EffectValue);
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
