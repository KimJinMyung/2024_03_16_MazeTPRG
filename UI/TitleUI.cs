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

            Console.Title = "어둠의 미궁";

            Console.SetCursorPosition(22, CursurPositionY - 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("#############################################");
            Console.SetCursorPosition(22, CursurPositionY - 1);
            Console.WriteLine("#                                           #");
            Console.SetCursorPosition(22, CursurPositionY);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("#     어둠의 미궁에 오신 것을 환영합니다.   #");
            Console.SetCursorPosition(22, CursurPositionY + 1);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("#                                           #");
            Console.SetCursorPosition(22, CursurPositionY + 2);
            Console.WriteLine("#############################################");

            Console.ResetColor();
        }
    }
}
