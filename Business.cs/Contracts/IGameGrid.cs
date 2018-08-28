using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IGameGrid
    {
        int Width { get; set; }
        int Height { get; set; }
        bool[,] GameGridArray { get; set; }

        List<IBlock> Blocks { get; set; }

    }
}