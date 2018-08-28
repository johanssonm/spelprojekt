using TetrisUI;

namespace Business.Contracts
{
    public abstract class IBlock
    {
        public abstract int Id { get; set; }
        public abstract ShapeColor ShapeColor { get; set; }
        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract string Coordinates { get; set; }
    }
}