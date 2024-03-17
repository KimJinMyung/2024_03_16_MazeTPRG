using MazeTPRG.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Inventory
{
    internal class Inventory
    {
        //아이템 인벤토리 딕셔너리 생성
        private Dictionary<itemClass, int> itemInventoryDic;

        public Inventory() 
        { 
            //아이템 인벤토리 딕셔너리 정의
            itemInventoryDic = new Dictionary<itemClass, int>();
        }

        //아이템 줍기
        public void PickUpItem(itemClass item, int count)
        {
            //주운 아이템의 이름과 동일한 아이템이 인벤토리에 있으면
            foreach (var item1 in itemInventoryDic)
            {
                if(item1.Key.GetName == item.GetName)
                {
                    //아이템의 갯수 증가 이후, 메서드 종료.
                    itemInventoryDic[item1.Key] += count;
                    return;
                }
            }
            //없으면 새로 추가
            itemInventoryDic.Add(item, count);
        }

        //아이템 사용
        public bool UseItem(string itemName)
        {
            //입력한 텍스트와 같은 name을 가진 아이템이 인벤토리에 존재하면
            foreach (var item in itemInventoryDic)
            {
                if (item.Key.GetName == itemName)
                {                    
                    //해당 아이템의 효과를 발동한다.
                    //아이템을 사용했거나 장비하였으면 true
                    bool UseOrEquip = item.Key.Use();
                    if (UseOrEquip)
                    {
                        //사용한 아이템의 갯수를 줄인다.
                        itemInventoryDic[item.Key]--;
                        //사용한 아이템의 갯수가 0이하이면 Remove한다.
                        if (itemInventoryDic[item.Key] <= 0) { itemInventoryDic.Remove(item.Key); }
                        return true;
                    }                            
                }
            }
            return false;
        }

        //인벤토리 출력
        public void Print()
        {
            Console.WriteLine("========================");
            foreach (var item in itemInventoryDic)
            {
                Console.WriteLine($"{item.Key.GetName} : X {item.Value}");
            }
            Console.WriteLine("========================\n");
        }
    }
}
