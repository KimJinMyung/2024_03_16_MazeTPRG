using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze
{
    enum Tile_Type
    {
        Road,
        Wall,
        Player,
        Monster,
        TreasureBox,
        Exit
    }

    internal class map
    {
        private Tile_Type[,] tile;
        private int tileSize;

        public map(int size)
        {
            tileSize = size;
            tile = new Tile_Type[tileSize,tileSize];

            for (int i = 0; i < tileSize; i++)
            {
                for (int j = 0; j < tileSize; j++)
                {
                    tile[i,j] = Tile_Type.Wall;
                }
            }

        }
    }
}
