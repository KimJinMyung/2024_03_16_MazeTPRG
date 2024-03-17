using MazeTPRG.Inventory;
using MazeTPRG.Item;
using MazeTPRG.Monster;
using MazeTPRG.Monster.MonsterListManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG
{
    internal class Player
    {
        private string name;
        private double currentHP;
        private double MaxHP;
        private double currentMP;
        private double MaxMP;
        private double ATK;
        private double defense;
        private bool isDead;
        private int Level;
        private int currentEXP;
        private int maxEXP;

        private Random random;

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
                } return playerInstance;
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
            isDead = false;
            Level = 1;
            currentEXP = 0;
            UpdateMaxEXP(Level);

            random = new Random();

            //아이템 인벤토리 및 장비창 정의
            itemInventory = new Inventory.Inventory();
            equipInventory = new Inventory.EquipInventory();


            battleMonsterList = new BattleMonsterList(); 
        }

        //MaxEXP 설정
        public void UpdateMaxEXP(int Level)
        {
            switch (Level)
            {
                case 1:
                    maxEXP = 15; 
                    break;
                case 2:
                    maxEXP = 30;
                    break;
                case 3:
                    maxEXP = 80;
                    break;
                case 4:
                    maxEXP = 150;
                    break;
                default:
                    break;
            }
        }

        //레벨업
        public void LevelUp()
        {
            if (Level >= 5)
            {
                Console.WriteLine("최대 레벨에 도달하였습니다.");
                return;
            }
            if (currentEXP >= maxEXP)
            {
                Level++;

                MaxHP *= 1.5;

                currentEXP -= maxEXP;
                UpdateMaxEXP(Level);
            }
        }

        #region 캐릭터상태변화
        public void HealHP(double EffectValue)
        {
            this.currentHP += EffectValue;
            if (this.currentHP >= MaxHP) { currentHP = MaxHP; }
        }

        public void HealMP(double EffectValue)
        {
            this.currentMP += EffectValue;
            if (this.currentMP >= MaxMP) { currentMP = MaxMP; }
        }

        public void WeaponsATK(double EffectValue)
        {
            this.ATK += EffectValue;
            if (this.ATK <= 1) { this.ATK = 1; }
        }
        public void ArmorDefense(double EffectValue)
        {
            this.defense += EffectValue;
            if (this.defense <= 0) { this.defense = 0; }
        }
        public void MaxHPUP(int EffectValue)
        {
            double currentMaxHP = this.MaxHP;
            this.MaxHP += EffectValue;
            if (currentHP >= currentMaxHP) { currentHP = MaxHP; }
            else HealHP((MaxHP - currentMaxHP) / 2);
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

        #region Battle
        //배틀할 몬스터의 리스트
        private BattleMonsterList battleMonsterList;

        //배틀할 몬스터 리스트를 입력받는다.
        public void BattleMonster(BattleMonsterList battleMonsterList)
        {
            this.battleMonsterList = battleMonsterList;
        }

        //공격과 도망은 BattleEnd를 반환한다.
        //공격으로 적 몬스터를 처치하면 BattleEnd가 ture로 반환,
        //도망은 성공하면 true로 반환한다.
        //피격은 플레이어가 사망하면 true를 반환한다.

        //피격
        public bool Hurt(double damage)
        {
            this.currentHP -= (damage - (damage * defense/100));
            if (this.currentHP <= 0) isDead = true;
            else isDead = false;
            //죽으면 true, 살았으면 flase를 반환
            return isDead;
        }        

        //공격
        public bool Attack(int index)
        {            
            bool BattleEnd = false;
            int AttackDamage1 = random.Next((int)ATK - 2, (int)ATK + 2);
            double AttackDamage2 = random.NextDouble() + AttackDamage1;

            Console.WriteLine($"플레이어 {this.name}의 공격");

            bool isKillMonster = battleMonsterList.GetBattleMonster(index-1).Hurt(AttackDamage2);
            if (isKillMonster)
            {
                battleMonsterList.Remove(index);
                this.currentEXP += battleMonsterList.GetBattleMonster(index).GetGiveEXP;
                LevelUp();
                BattleEnd = true;
            }else BattleEnd = false;

            return BattleEnd;
        }

        //도망
        public bool Run()
        {
            bool BattleEnd = false;
            int RunPersent = random.Next(100);
            if (RunPersent <= 30) BattleEnd = true;
            else BattleEnd = false;

            return BattleEnd;
        }


        #endregion

        #region 출력
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

        //플레이어 일반 인벤토리 출력
        public void PrintPlayerInventory() 
        {
            Console.WriteLine("========================");
            Console.WriteLine($"      {name}의 인벤토리");
            itemInventory.Print();
        }

        //플레이어 장비 인벤토리 출력
        public void PrintPlayerEquipInventory()
        {
            Console.WriteLine("========================");
            Console.WriteLine($"      {name}의 장비");
            equipInventory.Print();
        }
        #endregion
    }
}
