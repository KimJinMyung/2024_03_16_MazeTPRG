using MazeTPRG.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Battle
{
    enum PlayerAction
    {
        Attack=1,
        UseItem=2,
        Run=3
    }

    internal class SelectAction
    {
        Player Player;
        public Dictionary<PlayerAction, Action> Actions;
        private bool runSucccess;
        private InventoryWindow inventoryWindow;

        public bool GetBattleEnd
        { 
            get { return runSucccess; } 
        }
        public SelectAction()
        {
            Player = Player.Instance;
            Actions = new Dictionary<PlayerAction, Action>();
            runSucccess = false;
            inventoryWindow = new InventoryWindow();
        }

        public bool Select()
        {
            bool turnEnd = false;
            Console.WriteLine("=====================");
            Console.WriteLine("1. 공격");
            Console.WriteLine("2. 아이템 사용");
            Console.WriteLine("3. 도망");
            Console.WriteLine("=====================\n");

            Console.WriteLine("=====================");
            Console.Write("행동을 선택하세요. : ");
            try
            {
                //중요하다
                //ReadLine에 남아있는 것을 전부 비워라
                while(Console.KeyAvailable) {Console.ReadKey(true);}

                int inputAction = int.Parse(Console.ReadLine ());

                Console.WriteLine("=====================");
                turnEnd = Action(inputAction);
            }
            catch (Exception e)
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            return turnEnd;
        }

        public bool Action(int action)
        {
            bool turnEnd = false;
            switch (action)
            {
                case (int)PlayerAction.Attack:
                    Console.Write("공격할 몬스터를 선택 : ");           
                    
                    int AttackMonsterIndex = int.Parse(Console.ReadLine());
                    Console.WriteLine("=====================");
                    Console.WriteLine();
                    //몬스터가 사망하면 다시 순서를 정렬한다.
                    turnEnd = Player.Attack(AttackMonsterIndex);                    
                    return turnEnd;

                case (int)PlayerAction.UseItem:
                    turnEnd = inventoryWindow.PirntInventoryWindow();                    
                    Thread.Sleep(1500);                    
                    return turnEnd;

                case (int)PlayerAction.Run:
                    if (Player.Run())
                    {
                        Console.WriteLine("무사히 도망쳤습니다...\n");
                        runSucccess = true;
                    }
                    else
                    { 
                        Console.WriteLine("도망치지 못했습니다.\n");
                        runSucccess = false;
                    }
                    turnEnd = true;
                    return turnEnd;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    return turnEnd;
            }
        }

    }
}
