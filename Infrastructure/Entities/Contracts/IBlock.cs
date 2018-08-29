using TetrisUI;

namespace Infrastructure.Contracts
{
    public interface IBlock
    {
        int Id { get; set; }
        ShapeColor ShapeColor { get; set; }
        int X { get; set; }
        int Y { get; set; }
        string Coordinates { get; set; }
    }
}