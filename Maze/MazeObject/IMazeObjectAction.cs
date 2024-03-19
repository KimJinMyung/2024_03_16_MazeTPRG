using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze.MazeObject.MazeObject
{
    internal interface IMazeObjectAction
    {
        public void SetPosition(int x, int y);
        public int[] Move(Direction direction);
    }
}
