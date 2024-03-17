using MazeTPRG.Monster.MonsterListManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Battle
{
    internal class Battle
    {
        Player player = Player.Instance;
        BattleMonsterList BattleMonsterList;
        
        public Battle()
        {
            BattleMonsterList = new BattleMonsterList();

            //입력받은 몬스터들과 배틀
            player.BattleMonster(BattleMonsterList);

            //배틀할 몬스터의 리스트 출력
            BattleMonsterList.PrintBattleMonsterList();

            //플레이어의 정보창 출력

            //플레이어의 선택지 생성

            //공격
            //아이템 사용
            //도망

            //공격할 몬스터의 번호 지정
            int input = int.Parse(Console.ReadLine());
            player.Attack(input);
            Console.WriteLine();

            //배틀할 몬스터의 리스트 출력
            BattleMonsterList.PrintBattleMonsterList();
        }


    }
}
