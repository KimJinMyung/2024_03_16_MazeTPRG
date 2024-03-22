using MazeTPRG.GameManager;
using MazeTPRG.Item.Armor.body;
using MazeTPRG.Item.Armor.foot;
using MazeTPRG.Item.Armor.head;
using MazeTPRG.Item.Potion;
using MazeTPRG.Item.Weapons;
using MazeTPRG.Maze;
using MazeTPRG.Monster.Gobline;
using MazeTPRG.Monster.MonsterListManager;
using MazeTPRG.Monster.Ork;
using MazeTPRG.Monster.Slime;
using MazeTPRG.UI;

namespace MazeTPRG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //플레이어 선언
            Player player = Player.Instance;
            player.InitItem();

            //타이틀 출력
            TitleUI titleUI = new TitleUI();
            while (Console.KeyAvailable) { Console.ReadKey(true); }
            ConsoleKeyInfo InputKey = Console.ReadKey();

            //게임 스토리 출력
            StoryUI storyUI = new StoryUI();
            while (Console.KeyAvailable) { Console.ReadKey(true); }
            ConsoleKeyInfo InputKey2 = Console.ReadKey();

            //게임 시작
            MazeGameManager mazeGame = new MazeGameManager(15, 15);

        }
    }
}
