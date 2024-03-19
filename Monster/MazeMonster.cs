using MazeTPRG.Maze;
using MazeTPRG.Maze.MazeObject.MazeObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MazeTPRG.Monster
{
    internal class MazeMonster
    {
        private Monster monster;
        private map maze;

        public MazeMonster(map map)
        {
            //몬스터를 정의하기 위해서 아무 것이나 선언
            monster = new Slime.Slime().Clone();

            maze = map;
            monster.TileSpawn(map, Tile_Type.Monster);
        }

        public int[] GetMonsterPosition()
        {
            int[] position = new int[2];
            position[0] = monster.GetPosX;
            position[1] = monster.GetPosY;
            return position;
        }
               
        public Direction RandomDirection()
        {
            int randomDirectionIndex = new Random().Next(1,Enum.GetValues(typeof(Direction)).Length);
            switch (randomDirectionIndex)
            {
                case 1: return Direction.Up;
                case 2: return Direction.Down;
                case 3: return Direction.Left;
                case 4: return Direction.Right;
                default:
                    return Direction.None;
            }
        }

        //무작위로 상, 하, 좌, 우를 지정
        //몬스터에게 이동을 명하고 이동한 지점이 벽일 경우 다시 이동을 지정
        public void MoveObject()
        {                     
            bool isNotWall = false;
            while (true)
            {
                Direction direction = RandomDirection();
                int[] ObjectPosition = monster.Move(direction);
                //if(maze.GetTile[ObjectPosition[0], ObjectPosition[1]] == Tile_Type.Monster) continue;
                isNotWall = maze.GetTile[ObjectPosition[0], ObjectPosition[1]] != Tile_Type.Wall;
                if (isNotWall)
                {
                    maze.SetTileType(monster.GetPosX, monster.GetPosY, Tile_Type.Road);
                    maze.SetTileType(ObjectPosition[0], ObjectPosition[1], Tile_Type.Monster);
                    monster.SetPosition(ObjectPosition[0], ObjectPosition[1]);
                    break;
                }
                else continue;
            }         
        }


    }
}
