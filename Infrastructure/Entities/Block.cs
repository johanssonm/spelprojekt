using Infrastructure.Contracts;
using TetrisUI;

namespace Spelprojekt
{
    public class Block : IBlock
    {
        public int Id { get; set; }
        public ShapeColor ShapeColor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string Coordinates
        {
            get => X.ToString() + "x" + Y.ToString();
            set => throw new System.NotImplementedException();
        }

        public Block(int x, int y, ShapeColor shapecolor)
        {
            X = x;
            Y = y;
            ShapeColor = shapecolor;
        }
    }
}