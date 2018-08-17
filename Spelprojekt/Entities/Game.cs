using System.Collections.Generic;
using System.Dynamic;

namespace Spelprojekt.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public bool InPlay { get; set; }
        public int ShapesPlayed { get; set; }

        public int GameSpeed { get; set; }
    
        public List<Shape> Shapes { get; set; }

        public GameGrid GameGrid { get; set; }

        public Game()
        {
            InPlay = true;

            var tmpShapes = new List<Shape>
            {
                new IShape(),
                new JShape(),
                new LShape(),
                new OShape(),
                new SShape(),
                new TShape(),
                new ZShape()
            };

            // var types = new ExpandoObject(); TODO: Fixa så alla shapes skapas vid runtime

            GameSpeed = 1000;

            var shapes = tmpShapes;

            Shapes = shapes;

            ShapesPlayed = 0;

        }

    }



}
