using MazeTPRG.Monster.Gobline;
using MazeTPRG.Monster.Ork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Monster.MonsterListManager
{
    internal class MonsterList
    {
        private List<Monster> monsterList;

        public MonsterList()
        {
            monsterList = new List<Monster>();

            monsterList.Add(new Gobline.Gobline());
            monsterList.Add(new Ork.Ork());
            monsterList.Add(new Slime.Slime());
        }

        public Monster GetMonster(int index)
        {
            return monsterList[index];
        }

        public int Count {  get { return monsterList.Count; } }
    }
}
