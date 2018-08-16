using TetrisUI;

namespace Spelprojekt
{
    public class Block
    {
        public string Id { get; set; }
        public ShapeColor ShapeColor { get; set; }
        private int X { get; set; }
        private int Y { get; set; }

        public Block(int x, int y, ShapeColor shapecolor)
        {
            X = x;
            Y = y;
            ShapeColor = shapecolor;
        }
    }
}