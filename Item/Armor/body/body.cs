using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Armor.body
{
    internal abstract class body : Armor
    {
        public body()
        {
            this.parts = Inventory.Parts.body;
        }
    }
}
