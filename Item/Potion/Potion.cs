using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item.Potion
{
    internal abstract class Potion : itemClass
    {
        public Potion()
        {
            type = item_Type.potion;
        }
    }
}
