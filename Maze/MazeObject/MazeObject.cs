using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze.MazeObject.MazeObject
{
    internal abstract class MazeObject : ITileCreatureSpawn, IMazeObjectAction
    {
        private Random random = new Random();
        private int tile_Width;
        private int tile_height;
        protected int PosX;
        protected int PosY;

        public int GetPosX {  get { return PosX; } }
        public int GetPosY { get {  return PosY; } }

        public int[] Move(Direction direction)
        {
            int x = this.PosX;
            int y = this.PosY;

            switch (direction)
            {
                case Direction.Up: y--; break;
                case Direction.Down: y++; break;
                case Direction.Left: x--; break;
                case Direction.Right: x++; break;
            }
            int[] Position = new int[2] { x, y };
            return Position;
        }

        public void SetPosition(int x, int y)
        {
            this.PosX = x;
            this.PosY = y;
        }

        public void TileSpawn(Map map, Tile_Type type)
        {
            tile_Width = map.width;
            tile_height = map.height;

            while (true)
            {
                int x = random.Next(map.width);
                int y = random.Next(map.height);                
                
                bool playerNear = false;
                for(int i = x - 1; i <= x + 1 &&!playerNear; i++)
                {
                    for (int j = y - 1; j <= y + 1&&!playerNear; j++) 
                    {
                        if(i == x && j == y) continue;
                        if(i <= 0 || i >= map.width || j >= map.height || j <= 0) continue;
                        if (map.GetTile[i, j] == Tile_Type.Player)
                        {
                            playerNear = true;
                        }
                    }
                }

                if (playerNear) continue;

                if (map.GetTile[x,y]==Tile_Type.Road)
                {
                    map.SetTileType(x,y,type);
                    SetPosition(x,y);
                    break;
                }
            }
        }
    }
}
