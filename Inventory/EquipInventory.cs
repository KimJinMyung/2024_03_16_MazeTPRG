using MazeTPRG.Item;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Inventory
{
    enum Parts
    {
        weapons,
        head,
        body,
        foot
    }

    internal class EquipInventory
    {
        private Dictionary<Parts, itemClass> equipedInventory;

        public EquipInventory()
        {
            equipedInventory = new Dictionary<Parts, itemClass>();
        }
        
        //추가할 아이템을 입력받으면
        public void Add(Parts parts, itemClass item)
        {
            //해당 아이템의 parts가 비어있는지 확인
            if (equipedInventory.ContainsKey(parts))
            {
                Console.WriteLine("이미 착용한 무기가 있습니다.");
            }
            //비어있으면 장착
            else
            {
                equipedInventory.Add(parts, item);
            }
            
        }

        //해제할 부위를 입력받으면
        public void Remove(Parts parts)
        {
            //해당 부위에 아이템이 있는지 확인
            if (equipedInventory.ContainsKey(parts))
            {
                //해제한 아이템이 다시 인벤토리에 들어간다.
                Player.Instance.AddItem(equipedInventory[parts],1);
                //해당 부위에 아이템이 있다면 제거
                equipedInventory.Remove(parts);                             
            }
        }
        //동일한 아이템이 사용되면
        public bool Remove(string name)
        {
            foreach (var item in equipedInventory)
            {
                if(item.Value.GetName == name)
                {
                    //해제한 아이템의 효과를 제거한다.
                    equipedInventory[item.Key].Use();
                    ////해제한 아이템이 다시 인벤토리에 들어간다.
                    //Player.Instance.AddItem(equipedInventory[item.Key], 1);
                    ////해당 부위에 아이템이 있다면 제거
                    //equipedInventory.Remove(item.Key);
                    
                    //실행에 성공하였나?
                    return true;
                }
            }
            return false;
        }


        public void Print()
        {
            Console.WriteLine("========================");
            foreach (var item in Enum.GetValues(typeof(Parts)))
            {
                if (equipedInventory.ContainsKey((Parts)item))
                {
                    Console.WriteLine($"{item} : {equipedInventory[(Parts)item].GetName}");
                }
                else
                {
                    Console.WriteLine($"{item} : ");
                }
            }
            Console.WriteLine("========================\n");
        }
    }
}
