using TetrisUI;

namespace Spelprojekt
{
    public class Square
    {
        public bool HasBlock { get; set; }

        public Square(bool hasblock)
        {
            HasBlock = hasblock;
        }
    }
}