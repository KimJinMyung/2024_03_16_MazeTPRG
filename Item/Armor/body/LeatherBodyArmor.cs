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
        public void Equip()
        {
            equiped = true;
            Player.Instance.Equip(this.parts, this);
            Player.Instance.MaxHPUP(EffectValue);
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
