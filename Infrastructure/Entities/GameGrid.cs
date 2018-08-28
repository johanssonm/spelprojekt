using System.Collections.Generic;
using Business.Contracts;

namespace Spelprojekt.Entities
{
    public class GameGrid : IGameGrid
    {
        public int Width  { get; set; }
        public int Height  { get; set; }
        public bool[,] GameGridArray { get; set; }

        public IEnumerable<IBlock> Blocks { get; set; }

        public GameGrid(int width, int height)
        {
            Width = width;
            Height = height;

            bool[,] gameGridArray = new bool[width, height];
            Blocks = new List<IBlock>();

            GameGridArray = gameGridArray;
        }


    }
}
