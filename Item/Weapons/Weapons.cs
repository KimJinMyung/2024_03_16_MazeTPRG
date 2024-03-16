using MazeTPRG.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Weapons
{
    internal abstract class Weapons : itemClass
    {
        protected Parts Parts;
        public Weapons() 
        {
            this.type = item_Type.weapon;
        }
    }
}
