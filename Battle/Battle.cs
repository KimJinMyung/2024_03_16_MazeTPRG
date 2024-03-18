using MazeTPRG.Item;
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
        private Player player = Player.Instance;
        private BattleMonsterList BattleMonsterList;
        private SelectAction selectAction;
        private ItemList ItemList;
        //플레이어 턴까지 남은 수
        private int TurnCount;
        //공격하는 몬스터의 index
        private int AttackMonsterIndex;

        //배틀 종료 조건
        //배틀 몬스터 리스트의 모든 몬스터 제거
        //플레이어의 사망
        //플레이어 도망 성공
        public Battle()
        {
            //배틀 몬스터 생성
            BattleMonsterList = new BattleMonsterList();

            //입력받은 몬스터들과 배틀 시작
            player.BattleMonster(BattleMonsterList);
            int BattleMonsterCount = BattleMonsterList.Count();

            //랜덤 선공권 결정
            //RandomFirstTurnDecide();

            //스피드 선공권 결정
            SpeedFirstTurnDecide();

            //공격하는 몬스터의 인덱스 초기화
            AttackMonsterIndex = 0;

            //여기에서부터 반복
            while (true)
            {
                Console.Clear();

                //배틀할 몬스터의 리스트 출력
                BattleMonsterList.PrintBattleMonsterList();

                //플레이어의 배틀 정보창 출력
                player.PrintBattlePlayerInfo();
                //플레이어의 턴까지 남은 턴의 수 출력
                if (TurnCount != 0) 
                {
                    Console.WriteLine("=====================");
                    Console.WriteLine($"행동까지 {TurnCount} 턴 남음");
                    Console.WriteLine("=====================");
                }
                Console.WriteLine();                

                #region 배틀동작
                ////플레이어의 턴
                //if (playerTurn)
                //{                    
                //    //플레이어의 선택지 생성
                //    selectAction = new SelectAction();
                //    bool PlayerTurnEnd = selectAction.Select();
                //    if (!PlayerTurnEnd) { continue; }
                //    else { playerTurn = false; }

                //    //도망을 선택한 경우
                //    if (selectAction.GetBattleEnd != null)
                //    {
                //        //플레이어 도망 성공 시 배틀 종료
                //        if (selectAction.GetBattleEnd) break;
                //    }
                //    //도망이 아닌 다른 선택지를 고른 경우
                //    else
                //    {
                //        //플레이어의 동작 이후 몬스터들의 정보 출력
                //        BattleMonsterList.PrintBattleMonsterList();
                //    }                                  
                //    Thread.Sleep(2000);
                //}
                ////몬스터들의 턴
                //else
                //{
                //    bool playerDead = BattleMonsterList.AttackMonsters(player);

                //    //플레이어가 사망하였을 경우, 배틀 종료
                //    if(playerDead) break;
                //    else { playerTurn = true; }

                //    //공격을 받은 플레이어의 체력 출력
                //    player.PrintBattlePlayerInfo();
                //    Thread.Sleep(2000);
                //}
                #endregion

                //몬스터의 인덱스가 배틀 몬스터 리스트의 수보다 같거나크면
                //다시 0에서부터 시작.
                AttackMonsterIndex = AttackMonsterIndex % BattleMonsterList.Count();              

                //플레이어 턴
                if(TurnCount <= 0)
                {
                    //플레이어의 선택지 생성
                    selectAction = new SelectAction();
                    bool PlayerTurnEnd = selectAction.Select();
                    if (!PlayerTurnEnd) { continue; }
                    
                    //도망을 선택한 경우
                    if (selectAction.GetBattleEnd != null)
                    {
                        //플레이어 도망 성공 시 배틀 종료
                        if (selectAction.GetBattleEnd) break;
                    }
                    //도망이 아닌 다른 선택지를 고른 경우
                    else
                    {
                        //플레이어의 동작 이후 몬스터들의 정보 출력
                        BattleMonsterList.PrintBattleMonsterList();
                    }
                    Thread.Sleep(2000);

                    //끝나면 TurnCount를 가장 마지막으로 미룬다.
                    TurnCount = BattleMonsterList.Count();
                    //(배틀 몬스터 리스트의 수를 대입받는다.)
                }
                //몬스터 턴
                else
                {
                    //스피드가 가장 빠른 순서대로 공격                    
                    bool playerDead = BattleMonsterList.GetSortMonster[AttackMonsterIndex].Attack(player);
                    if (playerDead) break;

                    //공격을 받은 플레이어의 체력 출력
                    player.PrintBattlePlayerInfo();

                    Thread.Sleep(2000);
                    //동작이 끝나면 공격하는 몬스터의 index를 1 증가.
                    AttackMonsterIndex++;
                    //끝나면 플레이어의 TurnCount를 1 감소시킨다.
                    TurnCount--;
                }

                //배틀 몬스터가 모두 처치되었을 경우, 배틀 종료
                if (BattleMonsterList.Count() <= 0)
                { 
                    ItemList = new ItemList();
                                        
                    for (int i = 0; i <= new Random().Next(BattleMonsterCount); i++)
                    {
                        int getItemIndex = new Random().Next(ItemList.GetLength);
                        if (ItemList.GetItem(getItemIndex) != default) player.AddItem(ItemList.GetItem(getItemIndex), 1);
                        else Console.WriteLine("아무것도 가지지 못했다.");
                    }
                    break; 
                }                                 
            }                
        }

        //랜덤 우선권
        //public void RandomFirstTurnDecide()
        //{
        //    int selectTurn = new Random().Next(2);
        //    if (selectTurn > 0) { playerTurn = true; }
        //    else {  playerTurn = false; }
        //}

        //스피드 우선권        
        public void SpeedFirstTurnDecide()
        {
            BattleMonsterList.SpeedSort();
            foreach (var item in BattleMonsterList.GetSortMonster)
            {
                if (player.GetSpeed < item.GetSpeed) TurnCount++;
            }
        }

    }
}
