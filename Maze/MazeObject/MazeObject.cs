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
        private map maze;

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

        public void TileSpawn(map map, Tile_Type type)
        {
            tile_Width = map.width;
            tile_height = map.height;

            while (true)
            {
                int x = random.Next(map.width);
                int y = random.Next(map.height);

                if (x < tile_Width&& x > 0 && y < tile_height && y > 0)
                {                  
                    if (map.GetTile[x, y] == Tile_Type.Road)
                    {
                        bool term1 = map.GetTile[x + 1, y] == Tile_Type.Player;
                        if (term1) continue;
                        bool term2 = map.GetTile[x - 1, y] == Tile_Type.Player;
                        if (term2) continue;
                        bool term3 = map.GetTile[x, y + 1] == Tile_Type.Player;
                        if (term3) continue;
                        bool term4 = map.GetTile[x, y - 1] == Tile_Type.Player;
                        if (term4) continue;

                        map.SetTileType(x, y, type);
                        SetPosition(x, y);
                        break;
                    }
                }                                                         
            }
        }
    }
}
