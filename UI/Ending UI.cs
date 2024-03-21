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

            Console.SetCursorPosition(15 ,(windowHeight / 2) - 2);
            TextAni("Congratulation");
            Console.SetCursorPosition(8, (windowHeight / 2));
            TextAni("당신은 무사히 미궁을 빠져나왔습니다.");
        }

    }
}
