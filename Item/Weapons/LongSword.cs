using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Weapons
{
    internal class LongSword : Weapons
    {
        private bool equiped;
        public LongSword()
        {
            this.name = "낡은 롱소드";
            //공격력
            this.EffectValue = 8;
            //파츠
            this.Parts = Inventory.Parts.weapons;
        }

        public override itemClass Clone()
        {
            return new LongSword();
        }

        public bool Equip()
        {            
            if(Player.Instance.Equip(this.Parts, this))
            {
                equiped = true;
                Player.Instance.WeaponsATK(EffectValue);
                return true;
            }
            return false;
        }

        public void UnEquip()
        {
            equiped = false;
            Player.Instance.UnEquip(this.Parts);
            Player.Instance.WeaponsATK(-EffectValue);
        }

        public override bool Use()
        {
            if (!equiped)
            {
                if(Equip()) return true;
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
