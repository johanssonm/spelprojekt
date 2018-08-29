using TetrisUI;

namespace Infrastructure.Contracts
{
    public interface IShape
    {
        int Id { get; set; }
        bool IsInPlay { get; set; }
        string Name { get; set; }
        bool CanBeRotated { get; set; }
        bool[,] ShapeGrid { get; set; }

        int GameGridXPosition { get; set; }
        int GameGridYPosition { get; set; }

        ShapeColor ShapeColor { get; set; }

    }
}
