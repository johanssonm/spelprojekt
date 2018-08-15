using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class GameGrid
    {
        public int X  { get; set; }
        public int Y  { get; set; }

        public bool[,] GameGridArray { get; set; }

        public List<Block> Squares { get; set; }

        public GameGrid(int x, int y)
        {
            X = x;
            Y = y;

            bool[,] gameGridArray = new bool[x, y];
            Squares = new List<Block>();

            GameGridArray = gameGridArray;
        }


    }
}
