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

        public void Equip()
        {
            equiped = true;
            Player.Instance.Equip(this.Parts, this);
            Player.Instance.WeaponsATK(EffectValue);
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
