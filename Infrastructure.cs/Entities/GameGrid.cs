using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class GameGrid
    {
        public int Width  { get; set; }
        public int Height  { get; set; }

        public int FilledColumns { get; set; }
        public int FilledRows { get; set; }

        public bool[,] GameGridArray { get; set; }

        public List<Block> Squares { get; set; }

        public GameGrid(int width, int height)
        {
            Width = width;
            Height = height;

            bool[,] gameGridArray = new bool[width, height];
            Squares = new List<Block>();

            GameGridArray = gameGridArray;
        }


    }
}
