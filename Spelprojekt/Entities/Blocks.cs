using TetrisUI;

namespace Spelprojekt
{
    public class Block
    {

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public ShapeColor ShapeColor { get; set; }


        public Block(int x, int y, ShapeColor shapecolor)
        {

            XPosition = x;
            YPosition = y;
            ShapeColor = shapecolor;
        }
    }
}