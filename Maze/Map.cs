using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MazeTPRG.Maze
{
    enum Direction
    {
        None,
        Up,
        Down,
        Left,
        Right
    }

    enum Tile_Type
    {
        Road,
        Wall,
        Player,
        Monster,
        TreasureBox,
        Exit
    }

    internal class Map
    {
        const char Check = '■';
        private Tile_Type[,] tile;
        public Tile_Type[,] GetTile { get {  return tile; } }
        public void SetTileType(int x, int y, Tile_Type type)
        {
            tile[x,y] = type;
        }
        public int width { get; }
        public int height { get; }
        private bool[,] visited;
        private Random rand;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.rand = new Random();

            //방문 기록 설정
            visited = new bool[this.width, this.height];
            //타일 설정
            tile = new Tile_Type[this.width,this.height];

            Init();
            CreateMaze();
        }

        //전부 벽으로 막아서 시작
        public void Init()
        {
            for (int i = 0; i < this.height; i++)
            {
                for(int j = 0; j < this.width; j++)
                {
                    //아직 방문 안함
                    visited[j, i] = false;
                    this.tile[j, i] = Tile_Type.Wall;
                }
            }
        }

        public Tile_Type[,] CreateMaze()
        {
            //시작 지점(0,0)에서 미로 생성 시작
            visitTile(1, 1); 
            return tile;
        }

        //타일 확인
        public void visitTile(int x, int y)
        {
            //해당 타일을 방문함
            visited[x,y] = true;
            tile[x,y] = Tile_Type.Road;

            //아직 방문 안한 타일 리스트
            List<int[]> list = GetUnVisitedTile(x, y);

            for (int i = 0;i < list.Count;i++)
            {
                //방문 안한 타일 중 무작위로 하나 지정
                int[] nextCell = list[rand.Next(list.Count)];
                //X, Y 좌표 설정
                int nexX = nextCell[0];
                int nexY = nextCell[1];

                //지정된 타일이 방문을 하지 않은 것이면
                if (!visited[nexX, nexY])
                {
                    //현재 셀과 다음 셀 사이의 벽 제거
                    tile[(x + nexX) / 2, (y + nexY) / 2] = Tile_Type.Road;

                    //다음 셀을 기점으로 다시 시작.
                    visitTile(nexX, nexY);
                }

                //지정된 타일이 방문된 것이라면 다시 리스트를 대입받는다.
                list = GetUnVisitedTile(x, y);
            }
        }

        //아직 방문 안한 타일 반환
        private List<int[]> GetUnVisitedTile(int x, int y)
        {
            List<int[]> tiles = new List<int[]>();

            //왼쪽
            if ( x >=2 && !visited[x-2,y] ) 
                tiles.Add(new int[] {x-2,y});
            //위
            if (y >= 2 && !visited[x, y-2])
                tiles.Add(new int[] { x, y-2 });
            //오른쪽
            if (x < width-2 && !visited[x +2, y]) 
                tiles.Add(new int[] { x+2, y });
            //아래
            if (y < height-2 && !visited[x , y+2])
                tiles.Add(new int[] { x, y +2});

            return tiles;
        }

        //화면 출력
        public void Render()
        {
            Console.Clear();
            ConsoleColor consoleColor = Console.ForegroundColor;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.ForegroundColor = GetTileColor(tile[x, y]);
                    Console.Write(Check);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = consoleColor;
        }

        //타일 색 변경
        ConsoleColor GetTileColor(Tile_Type tileType)
        {
            switch (tileType)
            {
                case Tile_Type.Wall:
                    return ConsoleColor.White;
                case Tile_Type.Road:
                    return ConsoleColor.Black;
                case Tile_Type.Exit:
                    return ConsoleColor.Green;
                case Tile_Type.Player:
                    return ConsoleColor.Blue;
                case Tile_Type.Monster:
                    return ConsoleColor.Red;
                case Tile_Type.TreasureBox:
                    return ConsoleColor.Yellow;
                default: 
                    return ConsoleColor.Black;
            }
        }
    }
}
