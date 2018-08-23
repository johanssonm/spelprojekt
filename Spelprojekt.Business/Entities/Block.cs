using TetrisUI;

namespace Spelprojekt
{
    public class Block
    {
        public int Id { get; set; }
        public ShapeColor ShapeColor { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public string Coordinates => X.ToString() + "x" + Y.ToString();

        public Block(int x, int y, ShapeColor shapecolor)
        {
            X = x;
            Y = y;
            ShapeColor = shapecolor;
        }
    }
}