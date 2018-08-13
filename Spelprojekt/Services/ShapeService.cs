using Spelprojekt.Entities;
using System.Windows.Forms;

namespace Spelprojekt.Services
{
    public class ShapeService
    {
        public int ShapeInPlayX { get; set; }
        public int ShapeInPlayY { get; set; }
        public Shape ShapeInPlayState { get; set; }

        public bool InBounds(Shape shape, Game game)
        {
            var grid = game.GameGrid.GameGridArray;
            var message = "Out of bounds";


            if (shape.GameGridXPosition > game.GameGrid.X)
            {
              //  MessageBox.Show(message);
                return false;
            }

            return true;

        }


        public bool[,] Rotate(bool[,] matrix, int n)
        {
            bool[,] result = new bool[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    result[i, j] = matrix[j,n - i - 1];
                }
            }

            return result;
        }


    }
}
