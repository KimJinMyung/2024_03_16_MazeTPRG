using MazeTPRG.Monster.Slime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Weapons
{
    internal class ShortSword : Weapons
    {        
        private bool equiped;
        public ShortSword() 
        {
            this.name = "낡은 단검";
            //공격력
            this.EffectValue = 5;
            //파츠
            this.Parts = Inventory.Parts.weapons;
        }
        public override itemClass Clone()
        {
            return new ShortSword();
        }

        public bool Equip()
        {
            equiped = true;
            if (Player.Instance.Equip(this.Parts, this))
            {
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
