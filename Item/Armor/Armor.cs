using MazeTPRG.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Armor
{
    internal abstract class Armor : itemClass
    {
        protected Parts parts;

        protected Armor()
        {
            this.type = item_Type.aromr;
        }
    }
}
