using MazeTPRG.Item.Armor.body;
using MazeTPRG.Item.Armor.foot;
using MazeTPRG.Item.Armor.head;
using MazeTPRG.Item.Potion;
using MazeTPRG.Item.Weapons;

namespace MazeTPRG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //플레이어 선언
            Player player = Player.Instance;

            //아이템 줍기
            player.AddItem(new ShortSword(), 2);
            player.AddItem(new LeatherHat(), 1);
            player.AddItem(new LeatherBodyArmor(), 1);
            player.AddItem(new LeatherShoes(), 1);

            //아이템 사용
            //장비 타입인 아이템들에 UseItem을 한번만 호출하면 장착, 두번은 해제

            //장비 착용
            player.UseItem("낡은 단검");
            player.PrintPlayerInfo();
            //착용 장비 해제
            player.UseItem("낡은 단검");
            player.PrintPlayerInfo();
            //장비 착용
            player.UseItem("낡은 단검");
            player.PrintPlayerInfo();
            //장비 착용
            player.UseItem("가죽 갑옷");
            player.PrintPlayerInfo();
            //장비 착용
            player.UseItem("가죽 모자");
            player.PrintPlayerInfo();
            //장비 착용
            player.UseItem("가죽 신발");
            player.PrintPlayerInfo();
            //착용 장비 해제
            player.UseItem("가죽 갑옷");
            player.PrintPlayerInfo();
        }
    }
}
