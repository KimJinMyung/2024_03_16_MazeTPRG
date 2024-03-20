using MazeTPRG.Maze;
using MazeTPRG.Maze.MazeObject.MazeObject;
using MazeTPRG.Monster.Slime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MazeTPRG.Maze.MazeObject
{
    internal class MazeMonster
    {
        private Monster.Monster monster;
        private Map maze;
        //이동하는 타일의 타입 저장소
        private Queue<Tile_Type> NextTileType;

        public MazeMonster()
        {
            NextTileType = new Queue<Tile_Type>();
            //Road에서 스폰되기에 초기값을 선언
            NextTileType.Enqueue(Tile_Type.Road);
        }

        public void MazeMonsterSpawn(Map map)
        {
            //몬스터를 정의하기 위해서 아무 것이나 선언
            monster = new Slime().Clone();

            maze = map;
            monster.TileSpawn(map, Tile_Type.Monster);
        }

        public int[] GetMonsterPosition
        {
            get
            {
                int[] position = new int[2];
                position[0] = monster.GetPosX;
                position[1] = monster.GetPosY;
                return position;
            }

        }

        public Direction RandomDirection()
        {
            int randomDirectionIndex = new Random().Next(1, Enum.GetValues(typeof(Direction)).Length);
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
            int[] ObjectPosition = new int[2];
            while (true)
            {
                ObjectPosition = default(int[]);

                Direction direction = RandomDirection();
                ObjectPosition = monster.Move(direction);

                //이동하려는 좌표에 몬스터가 존재하면 정지한다.
                if (maze.GetTile[ObjectPosition[0], ObjectPosition[1]] == Tile_Type.Monster) break;

                isNotWall = maze.GetTile[ObjectPosition[0], ObjectPosition[1]] != Tile_Type.Wall;
                if (isNotWall)
                {
                    //이동하려는 타일의 타입을 저장한다.
                    NextTileType.Enqueue(maze.GetTile[ObjectPosition[0], ObjectPosition[1]]);
                    maze.SetTileType(monster.GetPosX, monster.GetPosY, NextTileType.Dequeue());
                    maze.SetTileType(ObjectPosition[0], ObjectPosition[1], Tile_Type.Monster);
                    monster.SetPosition(ObjectPosition[0], ObjectPosition[1]);
                    break;
                }
                else continue;
            }
        }


    }
}
