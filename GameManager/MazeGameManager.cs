using MazeTPRG.Battle;
using MazeTPRG.Inventory;
using MazeTPRG.Item;
using MazeTPRG.Maze;
using MazeTPRG.Maze.Input;
using MazeTPRG.Maze.MazeObject;
using MazeTPRG.Maze.MazeObject.MazeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.GameManager
{
    internal class MazeGameManager
    {
        private int width;
        private bool PlayerTurn = true;
        private Map map;
        private Battle.Battle battle;
        private List<MazeMonster> monsters;
        private int[] EncountMonsterPosittion;
        private InputKey inputKey;
        private InventoryWindow inventoryWindow;
        private List<MazeItemBox> itemBoxes;
        //아이템 박스 전리품 리스트
        private ItemList ItemList;

        //게임 라운드
        private int GameRound =0;

        public MazeGameManager(int width, int height)
        {
            this.width = width;
            monsters = new List<MazeMonster>();
            EncountMonsterPosittion = new int[2];
            inputKey = new InputKey();
            inventoryWindow = new InventoryWindow();
            itemBoxes = new List<MazeItemBox>();
            ItemList = new ItemList();

            while (true)
            {
                GameRound++;
                //3라운드까지 
                if (GameRound > 3) 
                { 
                    Console.Clear();
                    Console.WriteLine("Congratulation");
                    Console.WriteLine("게임을 클리어하셨습니다.");
                    break; 
                }

                map = new Map(width, height);

                //플레이어 랜덤 스폰
                MazePlayerPosition playermaze = new MazePlayerPosition(map);

                //플레이어의 상,하,좌,우에 스폰되지 못하도록 설정
                //탈출구 랜덤 스폰
                MazeExit mazeExit = new MazeExit(map);

                //아이템 박스 초기화
                itemBoxes.Clear();
                //아이템 박스 랜덤 스폰
                for (int i = 0; i< new Random().Next(3, 5); i++)
                {                    
                    MazeItemBox itemBox = new MazeItemBox(map);
                    itemBoxes.Add(itemBox);
                }                                                

                //몬스터 초기화
                monsters.Clear();
                //몬스터 랜덤 스폰
                for (int i = 0; i < 1/*new Random().Next(3, 8)*/; i++)
                {
                    MazeMonster mazeMonster = new MazeMonster();
                    mazeMonster.MazeMonsterSpawn(map);
                    monsters.Add(mazeMonster);
                }               

                while (true)
                {
                    //맵 출력
                    map.Render();

                    //게임 라운드 표시 출력
                    PrintGameRound();

                    //누구의 차례인지 출력
                    PrintWhoPlayTurn(PlayerTurn);                    

                    //콘솔 커서 위치 초기화
                    Console.SetCursorPosition(0, height);

                    //출구 지점 초기화 및 표시
                    map.SetTileType(mazeExit.GetPosX, mazeExit.GetPosY, Tile_Type.Exit);

                    //플레이어 맵 업데이트
                    playermaze.UpdateMazeMap(map);

                    //몬스터와 플레이어가 조우했는지 확인
                    if (playermaze.GetBattleStart)
                    {
                        //텍스트 출력
                        Console.WriteLine("몬스터와 조우했다.");
                        Thread.Sleep(1000);

                        //배틀
                        battle = new Battle.Battle();

                        if (!battle.GetPlayerSurvive)
                        {
                            Console.Clear();
                            Console.WriteLine("게임 오버");
                            break;
                        }
                        else
                        {
                            //플레이어가 살아남았을 경우, 만난 몬스터 remove
                            if (EncountMonsterPosittion != null)
                            {
                                foreach (var item in monsters)
                                {
                                    if (item.GetMonsterPosition.SequenceEqual(EncountMonsterPosittion))
                                    {
                                        map.SetTileType(item.GetMonsterPosition[0], item.GetMonsterPosition[1], Tile_Type.Road);
                                        monsters.Remove(item);
                                        EncountMonsterPosittion = default(int[]);
                                        playermaze.SetBattleStart = false;
                                        break;
                                    }
                                }
                            }
                        }
                        map.Render();
                    }

                    //ReadLine에 남아있는 것을 전부 비워라
                    while (Console.KeyAvailable) { Console.ReadKey(true); }

                    //플레이어의 차례
                    if (PlayerTurn)                    
                    {                      
                        //플레이어 입력
                        ConsoleKeyInfo key = Console.ReadKey();                                                                        
                        //한글로 입력하면 2번 입력해야함

                        //인벤토리 window 출력                        
                        if (key.Key == ConsoleKey.E || key.KeyChar == 'ㄷ')
                        {
                            //아이템을 사용했으면 턴 종료
                            if (inventoryWindow.PirntInventoryWindow())
                            {
                                //턴 바꾸기
                                PlayerTurn = false;
                                continue;
                            }
                        }

                        //플레이어 이동
                        if (!playermaze.MoveObject(inputKey.GetDirection(key.Key))) continue;
                        foreach (var item in monsters)
                        {
                            //조우했는지 판별
                            EncountMonsterPosittion = playermaze.EncounterMonster(item.GetMonsterPosition);
                            //조우했으면 반복을 종료
                            if (playermaze.GetBattleStart) break;
                        }

                        //플레이어가 아이템 박스를 발견했는지 확인
                        //시작부터 아이템 박스가 인근에 있을때 해당 코드가 먼저 실행되지 않는 것이 고민이라면
                        //시작부터 따로 떨어져 소환되도록 설정하면 그만
                        foreach (var item in itemBoxes)
                        {
                            //발견했다면
                            if (item.EncountItemBox())
                            {
                                //맵 출력 업데이트
                                map.Render();

                                //얻을 아이템의 인덱스 랜덤 산출
                                int getItemIndex = new Random().Next(ItemList.GetLength);

                                //아이템 출력 텍스트 위치 설정
                                Console.SetCursorPosition(width * 2 + 3, height - 1);

                                //아이템 리스트가 비어있지 않으면(꽝에 걸리지 않으면)
                                if (ItemList.GetItem(getItemIndex) != default)
                                {
                                    //플레이어에게 해당 아이템을 제공
                                    Player.Instance.AddItem(ItemList.GetItem(getItemIndex), 1);
                                }
                                else
                                {
                                    Console.WriteLine("꽝...");
                                }
                                Thread.Sleep(1800);
                                //아이템 박스 소멸
                                map.SetTileType(item.GetPosX, item.GetPosY, Tile_Type.Road);
                                itemBoxes.Remove(item);

                                //아이템 출력 텍스트 제거
                                Console.SetCursorPosition(width * 2 + 3, height - 1);
                                Console.WriteLine("                                          ");
                                break;
                            }
                        }

                        //턴 바꾸기
                        PlayerTurn = false;
                    }
                    //몬스터의 차례
                    else
                    {                        
                        //몬스터의 행동에 딜레이 추가
                        Thread.Sleep(1500);

                        //몬스터 이동
                        for (int i = 0; i < monsters.Count; i++)
                        {
                            monsters[i].MoveObject();
                            ////움직인 몬스터의 좌표를 monsterPosition에 반영
                            //monsterPosition[i] = monsters[i].GetMonsterPosition();
                        }

                        foreach (var item in monsters)
                        {
                            //조우했는지 판별
                            EncountMonsterPosittion = playermaze.EncounterMonster(item.GetMonsterPosition);
                            //조우했으면 반복을 종료
                            if (playermaze.GetBattleStart) break;
                        }
                        //턴바꾸기
                        PlayerTurn = true;
                    }

                    //플레이어 캐릭터가 탈출구에 도착하면 해당 라운드 종료
                    if (mazeExit.Exit())
                    {
                        Console.SetCursorPosition(width * 2 + 3, 8);
                        Console.WriteLine("==================");
                        Console.SetCursorPosition(width * 2 + 3, 9);
                        Console.WriteLine($"!!{GameRound} 라운드 클리어!!");
                        Console.SetCursorPosition(width * 2 + 3, 10);
                        Console.WriteLine("==================");

                        Thread.Sleep(1800);
                        break;
                    }
                }
            }
            
        }

        //현재 게임 라운드 출력
        public void PrintGameRound()
        {
            Console.SetCursorPosition(width * 2 + 3, 2);
            Console.WriteLine("==================");
            Console.SetCursorPosition(width * 2 + 8, 3);
            Console.WriteLine($"{GameRound} 라운드");
            Console.SetCursorPosition(width * 2 + 3, 4);
            Console.WriteLine("==================");
        }
        
        //누구의 턴인지 출력
        public void PrintWhoPlayTurn(bool playerTurn)
        {
            string Textstr = string.Empty;
            if (playerTurn)
            {
                Textstr = $"{Player.Instance.GetName}의 턴!!";
            }else Textstr = "몬스터의 턴!!";

            Console.SetCursorPosition(width * 2 + 3, 5);
            Console.WriteLine("==================");
            Console.SetCursorPosition(width * 2 + 6, 6);
            Console.WriteLine(Textstr);
            Console.SetCursorPosition(width * 2 + 3, 7);
            Console.WriteLine("==================");
        }
    }
}
