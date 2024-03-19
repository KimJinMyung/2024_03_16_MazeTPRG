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
        private int[] PlayerPosition;
        protected Player Player = Player.Instance;
        private bool BattleStart = false;
        public bool GetBattleStart { get { return BattleStart; } }
        private map maze;

        public MazePlayerPosition(map map)
        {
            UpdateMazeMap(map);
            Player.TileSpawn(map,Tile_Type.Player);
            PlayerPosition = new int[2];
        }

        public bool MoveObject(Direction direction)
        {
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

        public void EncounterMonster(int[] position)
        {
            PlayerPosition[0] = Player.GetPosX;
            PlayerPosition[1] = Player.GetPosY;

            bool turm1 = PlayerPosition[0] - 1 == position[0] && PlayerPosition[1] == position[1];            
            bool turm2 = PlayerPosition[0] + 1 == position[0] && PlayerPosition[1] == position[1];            
            bool turm3 = PlayerPosition[0] == position[0] && PlayerPosition[1] == position[1]+1;        
            bool turm4 = PlayerPosition[0] == position[0] && PlayerPosition[1] == position[1]-1;                
            bool turm5 = PlayerPosition[0] == position[0] && PlayerPosition[1] == position[1];
            
            if (turm1 || turm2 || turm3 || turm4 || turm5) 
            { 
                BattleStart = true;                
            }
            else BattleStart = false;
        }
    }
}
