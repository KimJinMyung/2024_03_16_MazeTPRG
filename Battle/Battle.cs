using MazeTPRG.Item;
using MazeTPRG.Monster.MonsterListManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Battle
{
    internal class Battle
    {
        private Player player = Player.Instance;
        private BattleMonsterList BattleMonsterList;
        private SelectAction selectAction;
        private ItemList ItemList;
        private bool PlayerSurvive;

        public bool GetPlayerSurvive { get { return PlayerSurvive; } }
        //플레이어 턴까지 남은 수
        private int playerTurnCount=0;
        //공격하는 몬스터의 index
        private int AttackMonsterIndex;
        //진행되는 턴의 수
        private int playingTurnCount=0;

        //배틀 종료 조건
        //배틀 몬스터 리스트의 모든 몬스터 제거
        //플레이어의 사망
        //플레이어 도망 성공
        public Battle()
        {
            PlayerSurvive = false;             
            //배틀 몬스터 생성
            BattleMonsterList = new BattleMonsterList();            

            //입력받은 몬스터들과 배틀 시작
            player.BattleMonster(BattleMonsterList);

            //플레이어 선택지 생성
            selectAction = new SelectAction();

            //스피드 선공권 결정
            SpeedFirstTurnDecide();            

            //스피드 비교 출력
            PrintCompareSpeed();

            //공격하는 몬스터의 인덱스 초기화
            AttackMonsterIndex = 0;

            int turnCound = 1;

            //여기에서부터 반복
            
            while (true)
            {
                //몬스터와 플레이어의 순서 순회
                playingTurnCount++;
                if (playingTurnCount > BattleMonsterList.Count() + 1)
                {
                    turnCound++;

                    //순회가 종료되면 다시 우선권을 정한다.
                    SpeedFirstTurnDecide();

                    //플레이어의 스킬 지속 시간 및 쿨타임 감소                
                    selectAction.SkillCoolTimeMinus(turnCound);

                    playingTurnCount = 0;
                }

                Console.Clear();

                //현재 턴 출력
                Console.WriteLine("=====================");
                Console.WriteLine($"    {turnCound}번째 턴!!");
                Console.WriteLine("=====================");
               
                //플레이어의 턴까지 남은 턴의 수 출력
                if (playerTurnCount != 0) 
                {
                    Console.WriteLine("=====================");
                    Console.WriteLine($"행동까지 {playerTurnCount} 턴 남음");
                    Console.WriteLine("=====================");
                }
                Console.WriteLine();

                //몬스터의 인덱스가 배틀 몬스터 리스트의 수보다 같거나크면
                //다시 0에서부터 시작.
                AttackMonsterIndex = AttackMonsterIndex % BattleMonsterList.Count();

                //배틀할 몬스터의 리스트 출력
                BattleMonsterList.PrintBattleMonsterList();

                //플레이어의 배틀 정보창 출력
                player.PrintBattlePlayerInfo();                

                //플레이어 턴
                if (playerTurnCount <= 0)
                {                   
                    //플레이어의 행동 선택                   
                    bool PlayerTurnEnd = selectAction.Select();
                    if (!PlayerTurnEnd) 
                    {
                        playingTurnCount--;
                        continue;
                    }
                    
                    //도망을 선택한 경우
                    if (selectAction.GetBattleEnd == true)
                    {
                        //플레이어 도망 성공 시 배틀 종료
                        PlayerSurvive = true;
                        if (selectAction.GetBattleEnd) break;
                    }
                    Thread.Sleep(2000);

                    //끝나면 TurnCount를 가장 마지막으로 미룬다.
                    playerTurnCount = BattleMonsterList.Count();
                    //(배틀 몬스터 리스트의 수를 대입받는다.)                 
                }
                //몬스터 턴
                else
                {
                    //스피드가 가장 빠른 순서대로 공격                    
                    bool playerDead = BattleMonsterList.GetSortMonster[AttackMonsterIndex].Attack(player);
                    if (playerDead)
                    {
                        PlayerSurvive = false;
                        break;
                    }
                    Thread.Sleep(1500);

                    //공격을 받은 플레이어의 체력 출력
                    player.PrintBattlePlayerInfo();

                    Thread.Sleep(2000);

                    //동작이 끝나면 공격하는 몬스터의 index를 1 증가.
                    AttackMonsterIndex++;

                    //끝나면 플레이어의 TurnCount를 1 감소시킨다.
                    playerTurnCount--;
                }

                //배틀 몬스터가 모두 처치되었을 경우, 배틀 종료
                if (BattleMonsterList.Count() <= 0)
                { 
                    //전리품 리스트 선언
                    ItemList = new ItemList();

                    //전리품 획득 확률
                    int MaxLoopCount;

                    //여러개 얻을 확률
                    int random = new Random().Next(100);
                    if (random < 70) MaxLoopCount = 0;
                    if (random < 85) MaxLoopCount = 1;
                    else if (random < 90) MaxLoopCount = 2;
                    else MaxLoopCount = 3;                    

                    for (int i = 0; i <= MaxLoopCount; i++)
                    {
                        int getItemIndex = new Random().Next(ItemList.GetLength);
                        if (ItemList.GetItem(getItemIndex) != default) 
                            player.AddItem(ItemList.GetItem(getItemIndex), 1);                        
                    }

                    Thread.Sleep(2000);

                    PlayerSurvive = true;
                    break; 
                }                
            }                
        }

        //스피드 우선권        
        public void SpeedFirstTurnDecide()
        {
            BattleMonsterList.SpeedSort();
            foreach (var item in BattleMonsterList.GetSortMonster)
            {
                playerTurnCount = 0;
                if (player.GetSpeed < item.GetSpeed) playerTurnCount++;
            }
        }

        public void PrintCompareSpeed()
        {
            //for (int i = 0; i < BattleMonsterList.Count(); i++)
            //{
            //    Console.WriteLine("==================================");
            //    Console.WriteLine($"{i + 1}번 몬스터 {BattleMonsterList.GetBattleMonster(i).GetMonsterName}의 속도 : {BattleMonsterList.GetBattleMonster(i).GetSpeed}");
            //    Console.WriteLine("==================================");
            //}
            //Console.WriteLine("\n==================================");
            //Console.WriteLine($"{player.GetName}의 속도 : {player.GetSpeed}");
            //Console.WriteLine("==================================");

            //Thread.Sleep(1000);

            //배틀할 몬스터 출력
            BattleMonsterList.PrintBattleMonsterList();
            player.PrintBattlePlayerInfo();

            Console.WriteLine();
            Console.WriteLine("공격 순서.\n");
            
            int monsterIndex = 0;
            for (int i = 0;i < BattleMonsterList.Count()+1; i++)
            {
                if (i == playerTurnCount) 
                {
                    Console.WriteLine("\n=================");
                    Console.WriteLine($"{i + 1}번째 {player.GetName}");
                    Console.WriteLine("=================");
                    continue;
                }
                Console.WriteLine("\n=================");
                Console.WriteLine($"{i+1}번째 {BattleMonsterList.GetSortMonster[monsterIndex].GetMonsterName}");
                Console.WriteLine("=================");
                monsterIndex++;
            }
            
            Thread.Sleep(2000);
        }

    }
}
