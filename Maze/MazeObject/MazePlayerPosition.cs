using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeTPRG.Maze.MazeObject.MazeObject;

namespace MazeTPRG.Maze.MazeObject
{
    internal class MazePlayerPosition
    {
        private int[] PlayerPosition;
        protected Player Player = Player.Instance;
        private bool BattleStart = false;
        public bool GetBattleStart { get { return BattleStart; } }
        public bool SetBattleStart { set { BattleStart = value; } }
        private Map maze;

        public MazePlayerPosition(Map map)
        {
            UpdateMazeMap(map);
            Player.TileSpawn(map, Tile_Type.Player);
            //while (true)
            //{
            //    Player.TileSpawn(map, Tile_Type.Player);
            //    bool turm1 = maze.GetTile[Player.GetPosX - 1, Player.GetPosY] == Tile_Type.Road;
            //    bool turm2 = maze.GetTile[Player.GetPosX + 1, Player.GetPosY] == Tile_Type.Road;
            //    bool turm3 = maze.GetTile[Player.GetPosX, Player.GetPosY - 1] == Tile_Type.Road;
            //    bool turm4 = maze.GetTile[Player.GetPosX, Player.GetPosY + 1] == Tile_Type.Road;
            //    if (turm1 && turm2 && turm3 && turm4) break;
            //}            

            PlayerPosition = new int[2];
        }

        public bool MoveObject(Direction direction)
        {
            if (BattleStart) return true;

            int[] ObjectPosition = Player.Move(direction);
            bool isNotWall = maze.GetTile[ObjectPosition[0], ObjectPosition[1]] != Tile_Type.Wall;
            if (ObjectPosition[0] == Player.GetPosX && ObjectPosition[1] ==Player.GetPosY) { return false; }
            if (isNotWall)
            {
                maze.SetTileType(Player.GetPosX, Player.GetPosY, Tile_Type.Road);
                maze.SetTileType(ObjectPosition[0], ObjectPosition[1], Tile_Type.Player);
                Player.SetPosition(ObjectPosition[0], ObjectPosition[1]);
                return true;
            }
            else return false;
        }

        public void UpdateMazeMap(Map map)
        {
            maze = map;
        }

        public int[] EncounterMonster(int[] position)
        {
            PlayerPosition[0] = Player.GetPosX;
            PlayerPosition[1] = Player.GetPosY;

            bool turm1 = PlayerPosition[0] - 1 == position[0] && PlayerPosition[1] == position[1];
            bool turm2 = PlayerPosition[0] + 1 == position[0] && PlayerPosition[1] == position[1];
            bool turm3 = PlayerPosition[0] == position[0] && PlayerPosition[1] == position[1] + 1;
            bool turm4 = PlayerPosition[0] == position[0] && PlayerPosition[1] == position[1] - 1;
            bool turm5 = PlayerPosition[0] == position[0] && PlayerPosition[1] == position[1];

            if (turm1 || turm2 || turm3 || turm4 || turm5)
            {
                BattleStart = true;
                return position;
            }
            else BattleStart = false;
            return default;
        }
        
    }
}
