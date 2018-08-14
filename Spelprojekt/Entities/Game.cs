using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class Game
    {
        public int ID { get; set; }
        public bool InPlay { get; set; }
        public List<Shape> Shapes { get; set; }

        public GameGrid GameGrid { get; set; }

        public Game()
        {
            InPlay = true;

            var shapes = new List<Shape>();

            var shape = new TestShape();


            shapes.Add(shape);

            Shapes = shapes;

        }

    }



}
