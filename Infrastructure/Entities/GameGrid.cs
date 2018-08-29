using System.Collections.Generic;
using Infrastructure.Contracts;

namespace Spelprojekt.Entities
{
    public class GameGrid : IGameGrid
    {
        public int Width  { get; set; }
        public int Height  { get; set; }
        public bool[,] GameGridArray { get; set; }

        public List<IBlock> Blocks { get; set; }

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
