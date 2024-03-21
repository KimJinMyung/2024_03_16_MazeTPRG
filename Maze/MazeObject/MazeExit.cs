using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze.MazeObject.MazeObject
{
    internal class MazeExit : MazeObject
    {
        private Player player;
        private Map maze;
        public MazeExit(Map map)
        {
            maze = map;
            TileSpawn(map,Tile_Type.Exit);
            player = Player.Instance;
        }

        //public bool Exit()
        //{
        //    bool turm1 = maze.GetTile[player.GetPosX - 1, player.GetPosY] == Tile_Type.Exit;
        //    bool turm2 = maze.GetTile[player.GetPosX + 1, player.GetPosY] == Tile_Type.Exit;
        //    bool turm3 = maze.GetTile[player.GetPosX, player.GetPosY - 1] == Tile_Type.Exit;
        //    bool turm4 = maze.GetTile[player.GetPosX, player.GetPosY + 1] == Tile_Type.Exit;

        //    if (turm1 || turm2 || turm3 || turm4)
        //    {
        //        return true;
        //    }
        //    else return false;
        //}
    }
}
