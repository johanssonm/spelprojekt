using Infrastructure.Entities;
using System.Collections.Generic;
using Business.Contracts;
using Spelprojekt.Services;

namespace Spelprojekt.Entities
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public bool InPlay { get; set; }

        public int ShapesPlayed { get; set; }

        public int GameSpeed { get; set; }

        public bool GameOver { get; set; }

        public IShape ShapeInPlay { get; set; }

        public IEnumerable<IShape> Shapes { get; set; }

        public IGameGrid GameGrid { get; set; }

        public IScore Score { get; set; }
        public IPlayer Player { get; set; }

        public Game()
        {
            InPlay = true;

            var tmpShapes = new List<IShape>
            {
                ShapeFactory.MakeShape("i"),
                ShapeFactory.MakeShape("j"),
                ShapeFactory.MakeShape("l"),
                ShapeFactory.MakeShape("o"),
                ShapeFactory.MakeShape("s"),
                ShapeFactory.MakeShape("t"),
                ShapeFactory.MakeShape("z")

            };

            // var types = new ExpandoObject(); TODO: Fixa så alla shapes skapas vid runtime



            var shapes = tmpShapes;

            Shapes = shapes;

            ShapesPlayed = 0;

        }

    }



}
