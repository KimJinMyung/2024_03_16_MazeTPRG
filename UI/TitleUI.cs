using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.UI
{
    internal class TitleUI : TextAnimation
    {
        private List<string> title;
        public TitleUI() 
        {
            title = new List<string>();

            int windowWidth =  Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int CursurPositionX = windowWidth/2;
            int CursurPositionY = windowHeight/2;

            Console.CursorVisible = false;

            Console.Title = "미노타우르스의 미궁";

            PrintTitleText();

            //2씩 증가            
            int line = 0;
            foreach (var item in title)
            {                
                Console.SetCursorPosition(10, 10 +line);
                Console.WriteLine(item);
                line++;
            }

            Console.SetCursorPosition(16, 20);
            Console.WriteLine("진행을 원하면 아무 키나 입력하시오...");
        }

        public void PrintTitleText()
        {
            title.Clear();
            title.Add("#############################################");
            title.Add("#                                           #");
            title.Add("#            미노타우르스의 미궁            #");
            title.Add("#                                           #");
            title.Add("#############################################");
        }
    }
}
