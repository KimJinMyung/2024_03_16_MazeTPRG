using MazeTPRG.Battle;
using MazeTPRG.Maze.Input;
using MazeTPRG.Monster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze.GameManager
{
    internal class MazeGameManager
    {
        private int width;
        private int height;
        private bool PlayerTurn = true;
        private map map;
        private Battle.Battle battle;
        private List<MazeMonster> monsters;
        private List<int[]> monsterPosition;

        public MazeGameManager(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new map(width, height);
            monsters = new List<MazeMonster>();
            monsterPosition = new List<int[]>();

            MazePlayerPosition playermaze = new MazePlayerPosition(map);
            for (int i = 0; i < new Random().Next(3,8); i++)
            {
                MazeMonster mazeMonster = new MazeMonster(map);
                monsters.Add(mazeMonster);
                monsterPosition.Add(mazeMonster.GetMonsterPosition());
            }

            map.Render();

            while (true)
            {          
                if (PlayerTurn)
                {
                    //플레이어 맵 업데이트
                    playermaze.UpdateMazeMap(map);

                    //플레이어 이동
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (!playermaze.MoveObject(new InputKey().GetDirection(key.Key))) continue;
                    //조우했는지 판별
                    playermaze.EncounterMonster();
                    //턴 바꾸기
                    PlayerTurn = false;
                }
                else
                {
                    //몬스터 이동
                    foreach (var item in monsters)
                    {
                        item.MoveObject();
                    }
                    //조우했는지 판별
                    playermaze.EncounterMonster();
                    //턴바꾸기
                    PlayerTurn = true;
                }
                //맵 출력
                map.Render();

                //몬스터와 플레이어가 조우했는지 확인
                if (playermaze.GetBattleStart)
                {
                    Console.WriteLine("몬스터와 조우했다.");
                    Thread.Sleep(1000);
                    //배틀
                    battle = new Battle.Battle();

                    map.Render();

                    if (!battle.GetPlayerSurvive)
                    {
                        Console.Clear();
                        Console.WriteLine("게임 오버");
                        break;
                    }
                    else
                    {
                        //플레이어가 살아남았을 경우, 만난 몬스터 remove

                    }
                }                              
            }
        }

        public 
    }
}
