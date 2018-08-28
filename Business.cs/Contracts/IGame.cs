﻿using Infrastructure.Entities;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IGame
    {
        int Id { get; set; }
        bool InPlay { get; set; }

        IShape ShapeInPlay { get; set; }

        int ShapesPlayed { get; set; }

        int GameSpeed { get; set; }

        bool GameOver { get; set; }

        IEnumerable<IShape> Shapes { get; set; }

        IGameGrid GameGrid { get; set; }

        IScore Score { get; set; }
        IPlayer Player { get; set; }
    }
}
