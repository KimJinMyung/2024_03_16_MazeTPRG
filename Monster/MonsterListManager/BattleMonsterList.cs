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

        public BattleMonsterList()
        {
            MonsterList = new MonsterList();
            BattleMonster = new List<Monster>();
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
            for (int i = 0;i < BattleMonster.Count; i++)
            {
                Console.WriteLine("=====================");
                Console.WriteLine($"{i + 1}번 몬스터 : {BattleMonster[i].GetMonsterName}");
                Console.WriteLine($"HP : {Math.Round(BattleMonster[i].GetHP, 2)}");
                Console.WriteLine("=====================");
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
