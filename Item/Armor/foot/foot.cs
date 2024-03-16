using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Armor.foot
{
    internal abstract class foot : Armor
    {
        public foot()
        {
            this.parts = Inventory.Parts.foot;
        }
    }
}
