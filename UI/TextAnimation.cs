using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.UI
{
    internal class TextAnimation
    {
        protected int windowWidth = Console.WindowWidth;
        protected int windowHeight = Console.WindowHeight;
        public void TextAni(string str)
        {
            foreach (var item in str)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
            Thread.Sleep(800);
            Console.WriteLine();
        }
    }
}
