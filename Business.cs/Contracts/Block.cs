using Business.Contracts;
using TetrisUI;

namespace Spelprojekt
{
    public class Block : IBlock
    {
        public override int Id { get; set; }
        public override ShapeColor ShapeColor { get; set; }
        public override int X { get; set; }
        public override int Y { get; set; }

        public override string Coordinates { get; set; }

        public Block(int x, int y, ShapeColor shapecolor)
        {
            X = x;
            Y = y;
            ShapeColor = shapecolor;
            Coordinates = x.ToString() + "x" + y.ToString();
        }
    }
}