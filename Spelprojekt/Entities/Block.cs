using TetrisUI;

namespace Spelprojekt
{
    public class Block
    {
        public string Id { get; set; }
        public ShapeColor ShapeColor { get; set; }

        public Block(string id, ShapeColor shapecolor)
        {
            Id = id;
            ShapeColor = shapecolor;
        }
    }
}