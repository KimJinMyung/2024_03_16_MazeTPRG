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
                      
            //게임 시작
            MazeGameManager mazeGame = new MazeGameManager(15, 25);                        
        }
    }
}
