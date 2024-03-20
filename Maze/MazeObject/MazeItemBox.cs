using MazeTPRG.Item;
using MazeTPRG.Item.Potion;
using MazeTPRG.Maze.MazeObject.MazeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze.MazeObject.MazeObject
{
    internal class MazeItemBox : MazeObject
    {
        private Map maze;
        private Player player;
        private itemClass item;
        public MazeItemBox(Map map)
        {            
            maze = map;
            player = Player.Instance;
            item = new HealingPotion();
            TileSpawn(map, Tile_Type.TreasureBox);
        }

        public bool EncountItemBox()
        {
            bool turm1 = player.GetPosX - 1 == GetPosX && player.GetPosY == GetPosY;
            bool turm2 = player.GetPosX + 1 == GetPosX && player.GetPosY == GetPosY;
            bool turm3 = player.GetPosX == GetPosX && player.GetPosY - 1 == GetPosY;
            bool turm4 = player.GetPosX == GetPosX && player.GetPosY + 1 == GetPosY;
            if (turm1 || turm2 || turm3 || turm4)
            {
                return true;
            }
            else return false;
        }
    }
}
