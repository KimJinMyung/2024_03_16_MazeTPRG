using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item
{
    enum item_Type
    {
        potion,
        aromr,
        weapon
    }
    internal abstract class itemClass
    {
        protected string name = string.Empty;
        protected item_Type type;
        protected int EffectValue;

        public string GetName {  get { return name; } }

        public abstract bool Use();
    }
}
