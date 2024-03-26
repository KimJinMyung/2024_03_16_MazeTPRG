using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.UI
{
    internal class Ending_UI : TextAnimation
    {        

        public Ending_UI()
        { 
            Console.Clear();

            Console.SetCursorPosition(17 ,(windowHeight / 2) - 5);
            TextAni("Congratulation");
            Console.SetCursorPosition(10, (windowHeight / 2)-4);
            TextAni("당신은 무사히 미궁을 빠져나왔습니다.");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
            Thread.Sleep(1500);
        }

    }
}
