using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.UI
{
    internal class TitleUI
    {
        public TitleUI() 
        {
            int windowWidth =  Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int CursurPositionX = windowWidth/2;
            int CursurPositionY = windowHeight/2;

            Console.CursorVisible = false;

            Console.Title = "미노타우르스의 미궁";

            Console.SetCursorPosition(22, CursurPositionY - 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("#############################################");
            Console.SetCursorPosition(22, CursurPositionY - 1);
            Console.WriteLine("#                                           #");
            Console.SetCursorPosition(22, CursurPositionY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("#             미노타우르스의 미궁           #");
            Console.SetCursorPosition(22, CursurPositionY + 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("#                                           #");
            Console.SetCursorPosition(22, CursurPositionY + 2);
            Console.WriteLine("#############################################");
            Console.ResetColor();

            Console.SetCursorPosition(27, CursurPositionY + 6);
            Console.WriteLine("진행을 원하면 아무 키나 입력하시오...");
        }
    }
}
