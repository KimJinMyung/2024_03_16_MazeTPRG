using MazeTPRG.Inventory;
using MazeTPRG.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG
{
    internal class Player
    {        
        private string name;
        private int currentHP;
        private int MaxHP;
        private int currentMP;
        private int MaxMP;
        private int ATK;
        private int defense;

        //아이템 인벤토리 
        private Inventory.Inventory itemInventory;

        //장비 인벤토리
        private Inventory.EquipInventory equipInventory;
        
        public Inventory.EquipInventory GetEquipInventory
        {
            get { return equipInventory; }
        }

        //자시 자신의 인스턴스를 저장
        private static Player playerInstance;        

        //어디에서든 해당 플레이어를 호출할 수 있도록 static으로 선언
        public static Player Instance
        {
            get
            {
                if (playerInstance == null)
                {
                    playerInstance = new Player();
                }return playerInstance;
            }
        }

        public Player()
        {
            name = "you";
            MaxHP = 150;
            currentHP = MaxHP;
            MaxMP = 100;
            currentMP = MaxMP;
            ATK = 5;
            defense = 2;

            //아이템 인벤토리 및 장비창 정의
            itemInventory = new Inventory.Inventory();
            equipInventory = new Inventory.EquipInventory();
        }

        #region 캐릭터상태변화
        public void HealHP(int EffectValue)
        {
            this.currentHP += EffectValue;
            if (this.currentHP >= MaxHP) { currentHP = MaxHP; }
        }

        public void HealMP(int EffectValue)
        {
            this.currentMP += EffectValue;
            if(this.currentMP >= MaxMP) {  currentMP = MaxMP; }
        }

        public void WeaponsATK(int EffectValue)
        {
            this.ATK += EffectValue;
            if (this.ATK <= 1 ) { this.ATK = 1; }
        }
        public void ArmorDefense(int EffectValue)
        {
            this.defense += EffectValue;
            if ( this.defense <= 0 ) {  this.defense = 0; }
        }
        public void MaxHPUP(int EffectValue)
        {
            int currentMaxHP = this.MaxHP;
            this.MaxHP += EffectValue;
            if ( currentHP >= currentMaxHP ) {  currentHP = MaxHP; }
            else HealHP((MaxHP - currentMaxHP)/2);
        }

        #endregion

        #region item

        public void AddItem(itemClass item, int count)
        {
            itemInventory.PickUpItem(item, count);
        }

        public void UseItem(string name)
        {
            bool UsedOrEquiped = itemInventory.UseItem(name);
            //입력한 아이템(의 이름)이 인벤토리에 없어도 장착한 장비 인벤토리에는 있을 수 있다.
            if (!UsedOrEquiped)
            {
                equipInventory.Remove(name);
            }
        }

        //장비 장착, 부위별로 장착할 수 있다.
        public void Equip(Parts parts, itemClass item)
        {
            equipInventory.Add(parts, item);            
        }

        //원하는 부위의 장비를 해제
        public void UnEquip(Parts parts)
        {
            equipInventory.Remove(parts);
        }

        #endregion

        //플레이어의 상태 출력
        public void PrintPlayerInfo()
        {
            Console.WriteLine("=====================");
            Console.WriteLine($"    {name}의 상태창 ");
            Console.WriteLine("=====================");
            Console.WriteLine($"HP : {currentHP}");
            Console.WriteLine($"MP : {currentMP}");
            Console.WriteLine($"공격력 : {ATK}");
            Console.WriteLine($"방어력 : {defense}");
            Console.WriteLine("=====================");
        }
    }
}
