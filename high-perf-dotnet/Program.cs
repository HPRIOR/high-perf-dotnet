using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace high_perf_dotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Tile[][] tiles = new Tile[9][];
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i] = new Tile[8];
            }

            var board = new Board(tiles);

            for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                Console.WriteLine($"{board.GetTile(i, j).x}, {board.GetTile(i, j).y}");

            board.GetTile(1, 1).x = 1; // mutate directly
            ref var x = ref board.GetTile(1, 1); // mutate by reference 

            var span = board.Tiles.AsSpan();

            board.GetTiles()[1][1].y = 9;
            
            
            
            
            for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                Console.WriteLine($"{board.GetTile(i, j).x}, {board.GetTile(i, j).y}");
        }
    }

    struct Tile
    {
        public int x;
        public int y;

        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    struct Board
    {
        public readonly Tile[][] Tiles;

        public Board(Tile[][] tiles)
        {
            /*this.tiles = new Tile[8][];
            for (int i = 0; i < this.tiles.Length; i++)
            {
                tiles[i] = new Tile[8];
            }*/
            this.Tiles = tiles;
        }

        public ref Tile GetTile(int x, int y) => ref Tiles[x][y];
        public Span<Tile[]> GetTiles() => Tiles.AsSpan();
    }
}