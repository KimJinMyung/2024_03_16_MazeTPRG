using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Inventory
{
    internal class InventoryWindow
    {
        private string keys;
        private int[] StartCursorPos;

        public InventoryWindow()
        {   
            StartCursorPos = new int[2];
        }

        public bool PirntInventoryWindow()
        {            
            while (true)
            {
                Console.Clear();
                //플레이어 상세 정보창 출력
                Player.Instance.PrintPlayerInfo();
                Console.WriteLine();
                //플레이어 장비 정보창 출력
                Player.Instance.PrintPlayerEquipInventory();
                Console.WriteLine();
                //플레이어 인벤토리 출력
                Player.Instance.PrintPlayerInventory();
                Console.WriteLine();

                Console.Write("사용 및 착용 해제할 아이템의 이름을 입력 : ");

                StartCursorPos[0] = Console.GetCursorPosition().Left;
                StartCursorPos[1] = Console.GetCursorPosition().Top;

                keys = string.Empty;

                //입력
                while (true)
                {                    
                    ConsoleKeyInfo key = Console.ReadKey(false);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        //ESC를 누르면 false를 출력
                        return false; 
                    }
                    if (key.Key == ConsoleKey.Backspace) 
                    {
                        Console.SetCursorPosition(StartCursorPos[0], StartCursorPos[1]); 
                        if(keys.Length == 0) continue;
                        Console.Write("                 ");

                        Console.SetCursorPosition(StartCursorPos[0], StartCursorPos[1]);
                        //마지막 문자 제거
                        keys = keys.Substring(0, keys.Length - 1);                        
                        //지금까지 저장된 문자열 출력
                        foreach (var item in keys)
                        {
                            Console.Write($"{item}");
                        }
                        continue;
                    }
                    if (key.Key == ConsoleKey.Enter) break;
                    if (key.Key == ConsoleKey.Spacebar) keys += " ";
                    else keys += key.KeyChar;
                }
                
                //사용할 아이템 이름
                string inputItemName = new string(keys.ToArray());                

                //해당 아이템을 사용했으면 인벤토리 창 닫기
                if (Player.Instance.UseItem(inputItemName))
                {
                    Console.Clear();
                    //플레이어 상세 정보창 출력
                    Player.Instance.PrintPlayerInfo();
                    Console.WriteLine();
                    //플레이어 장비 정보창 출력
                    Player.Instance.PrintPlayerEquipInventory();
                    Console.WriteLine();

                    Thread.Sleep(2000);
                    return true;    
                }

                
            }            
        }
    }
}
