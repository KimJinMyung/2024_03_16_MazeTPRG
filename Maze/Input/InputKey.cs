using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze.Input
{
    internal class InputKey
    {
        //ConsoleKeyInfo key = Console.ReadKey();
        //this.direction = input_key.GetDirection(key.Key);
        //if (direction != Direction.None)
        //{
        //    bool moveSuccess = MoveObject(direction);
        //}

        public Direction GetDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    return Direction.Up;
                case ConsoleKey.DownArrow:
                    return Direction.Down;
                case ConsoleKey.LeftArrow:
                    return Direction.Left;
                case ConsoleKey.RightArrow:
                    return Direction.Right;
                default:
                    return Direction.None;
            }
        }
    }
}
