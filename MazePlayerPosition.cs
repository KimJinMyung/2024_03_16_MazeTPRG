using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeTPRG.Maze.MazeObject.MazeObject;
using MazeTPRG.Maze.MazeObject;

namespace MazeTPRG.Maze
{ 
    internal class MazePlayerPosition
    {
        protected Player Player = Player.Instance;
        private bool BattleStart = false;
        public bool GetBattleStart { get { return BattleStart; } }
        private map maze;

        public MazePlayerPosition(map map)
        {
            UpdateMazeMap(map);
            Player.TileSpawn(map,Tile_Type.Player);            
        }

        public bool MoveObject(Direction direction)
        {
            EncounterMonster();
            if (BattleStart) return true;

            int[] ObjectPosition = Player.Move(direction);
            bool isNotWall = maze.GetTile[ObjectPosition[0], ObjectPosition[1]]!=Tile_Type.Wall;           

            if (isNotWall)
            {
                maze.SetTileType(Player.GetPosX, Player.GetPosY, Tile_Type.Road);
                maze.SetTileType(ObjectPosition[0], ObjectPosition[1], Tile_Type.Player);
                Player.SetPosition(ObjectPosition[0], ObjectPosition[1]);
                return true;    
            }else return false;
        }        

        public void UpdateMazeMap(map map)
        {
            this.maze = map;
        }

        public void EncounterMonster()
        {
            bool turm1 = maze.GetTile[Player.GetPosX - 1, Player.GetPosY] == Tile_Type.Monster;
            bool turm2 = maze.GetTile[Player.GetPosX + 1, Player.GetPosY] == Tile_Type.Monster;
            bool turm3 = maze.GetTile[Player.GetPosX, Player.GetPosY + 1] == Tile_Type.Monster;
            bool turm4 = maze.GetTile[Player.GetPosX, Player.GetPosY - 1] == Tile_Type.Monster;
            bool turm5 = maze.GetTile[Player.GetPosX, Player.GetPosY] == Tile_Type.Monster;
            if (turm1 || turm2 || turm3 || turm4 || turm5) 
            { 
                BattleStart = true;                
            }
            else BattleStart = false;
        }
    }
}
