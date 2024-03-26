using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Monster.MonsterListManager
{
    internal class BattleMonsterList
    {
        private MonsterList MonsterList;
        private List<Monster> BattleMonster;
        private Random rd;
        private int[] CursorPosition;
        private int cusorWidth;

        public void SetCusorPosition(int x, int y)
        {
            CursorPosition[0] = x;
            CursorPosition[1] = y;
        }

        public BattleMonsterList()
        {
            MonsterList = new MonsterList();
            BattleMonster = new List<Monster>();
            CursorPosition = new int[2];
            rd = new Random();

            int MonsterSpawn = rd.Next(MonsterList.Count);

            
            for (int i = 0; i <= rd.Next(3); i++)
            {
                int index = rd.Next(MonsterList.Count);
                Monster monster = MonsterList.GetMonster(index);
                BattleMonster.Add(monster.Clone());
            }
        }

        public Monster GetBattleMonster(int index)
        {
            return BattleMonster[index];
        }

        public int Count()
        {
            return BattleMonster.Count;            
        }

        public void Remove(int index)
        {
            BattleMonster.RemoveAt(index);
        }

        public void PrintBattleMonsterList()
        {
            PrintListAdd();

            int line = 0;
            cusorWidth = Console.GetCursorPosition().Left;
            foreach (var item in printList)
            {   
                Console.SetCursorPosition(cusorWidth + 2, CursorPosition[1]+line);
                Console.Write(item);       
                if(line == 4) cusorWidth = Console.GetCursorPosition().Left;
                line++;
                if (line >= 5) line = 0;
            }
            
          }
        private List<string> printList = new List<string>();
        public void PrintListAdd()
        {
            printList.Clear();
            for (int i = 0; i < BattleMonster.Count; i++)
            {
                printList.Add("=====================");
                printList.Add($"{i+1}번 몬스터 :  {BattleMonster[i].GetMonsterName}");
                printList.Add($"HP : {Math.Round(BattleMonster[i].GetHP, 2)}");
                printList.Add($"speed : {BattleMonster[i].GetSpeed}");
                printList.Add("=====================");                
            }
        }

        public bool AttackMonsters(Player player)
        {
            bool playerKill = false;
            foreach (var item in BattleMonster)
            {
                playerKill = item.Attack(player);
                Thread.Sleep(1500);
                Console.WriteLine();
                if (playerKill) { return playerKill; }
            }            
            return playerKill;
        }

        List<Monster> list = new List<Monster>();
        public void SpeedSort()
        {
            list = BattleMonster.OrderByDescending(x => x.GetSpeed).ToList();
        }

        public List<Monster> GetSortMonster
        {
            get 
            {
                return list;
            }            
        }        

    }
}
