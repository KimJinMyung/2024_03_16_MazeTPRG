using MazeTPRG.Item.Armor.body;
using MazeTPRG.Item.Armor.foot;
using MazeTPRG.Item.Armor.head;
using MazeTPRG.Item.Potion;
using MazeTPRG.Item.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Item
{
    internal class ItemList
    {
        private List<itemClass> itemList;

        public ItemList()
        {
            itemList = new List<itemClass>();

            itemList.Add(default);
            itemList.Add(new HealingPotion());
            itemList.Add(new ManaPotion());

            itemList.Add(new LongSword());
            itemList.Add(new ShortSword());

            itemList.Add(new LeatherHat());
            itemList.Add(new LeatherBodyArmor());
            itemList.Add(new LeatherShoes());
        }

        public itemClass GetItem(int index) {  return itemList[index]; }

        public int GetLength {  get { return itemList.Count; } }
    }
}
