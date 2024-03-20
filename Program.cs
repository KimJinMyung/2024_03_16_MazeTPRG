using MazeTPRG.GameManager;
using MazeTPRG.Item.Armor.body;
using MazeTPRG.Item.Armor.foot;
using MazeTPRG.Item.Armor.head;
using MazeTPRG.Item.Potion;
using MazeTPRG.Item.Weapons;
using MazeTPRG.Maze;
using MazeTPRG.Monster.MonsterListManager;

namespace MazeTPRG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //플레이어 선언
            Player player = Player.Instance;
            player.InitItem();
            //for(int i = 0; i < 18; i++)
            //{
            //    Console.SetCursorPosition(10, 3 + i);
            //    Console.Write("sdadadasdasasda");
            //}
            //Console.ReadKey();
            //Console.WriteLine("sdfsddsfsdfdfssfsfsfd");
            //for(int i = 0; i < 10; i++)
            //{
            //    Console.SetCursorPosition(10, 10 + i);
            //    Console.WriteLine("sdfsddsfsdfdfssfsfsfd");
            //}
            //Console.SetCursorPosition(10, 10);
            //Console.WriteLine("sdfsddsfsdfdfssfsfsfd");
            //Console.ReadKey(true);

            ////아이템 줍기
            //player.AddItem(new ShortSword(), 2);
            //player.AddItem(new LeatherHat(), 1);
            //player.AddItem(new LeatherBodyArmor(), 1);
            //player.AddItem(new LeatherShoes(), 1);

            ////아이템 사용
            ////장비 타입인 아이템들에 UseItem을 한번만 호출하면 장착, 두번은 해제

            //////장비 착용
            ////player.UseItem("낡은 단검");
            ////player.PrintPlayerInfo();
            //////착용 장비 해제
            ////player.UseItem("낡은 단검");
            ////player.PrintPlayerInfo();
            ////장비 착용
            //player.UseItem("낡은 단검");
            //player.PrintPlayerInfo();
            ////장비 착용
            //player.UseItem("가죽 갑옷");
            //player.PrintPlayerInfo();
            ////장비 착용
            //player.UseItem("가죽 모자");
            //player.PrintPlayerInfo();
            ////장비 착용
            //player.UseItem("가죽 신발");
            //player.PrintPlayerInfo();
            ////착용 장비 해제
            //player.UseItem("가죽 갑옷");
            //player.PrintPlayerInfo();

            ////인벤토리 출력
            //player.PrintPlayerInventory();

            ////장비창 출력
            //player.PrintPlayerEquipInventory();

            ////배틀할 몬스터 리스트 선언
            //BattleMonsterList battleMonsterList = new BattleMonsterList();  

            ////아래의 몬스터와 배틀
            //player.BattleMonster(battleMonsterList);

            ////배틀할 몬스터의 리스트 출력
            //battleMonsterList.PrintBattleMonsterList();

            ////공격할 몬스터의 번호 지정
            //int input = int.Parse(Console.ReadLine());
            //player.Attack(input);
            //Console.WriteLine();

            ////배틀할 몬스터의 리스트 출력
            //battleMonsterList.PrintBattleMonsterList();
                        
            MazeGameManager mazeGame = new MazeGameManager(15,15);

            //배틀 시작
            //Battle.Battle battle = new Battle.Battle();
        }
    }
}
