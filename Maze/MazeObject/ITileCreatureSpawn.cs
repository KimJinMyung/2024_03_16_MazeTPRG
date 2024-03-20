using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze.MazeObject.MazeObject
{
    internal interface ITileCreatureSpawn
    {
        public void TileSpawn(Map map, Tile_Type type);
    }
}
