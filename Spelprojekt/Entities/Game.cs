using System;
using System.Collections.Generic;
using System.Linq;

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

            var tmpShapes = new List<Shape>();

            var shape1 = new IShape();
            var shape2 = new JShape();
            var shape3 = new LShape();
            var shape4 = new OShape();
            var shape5 = new SShape();
            var shape6 = new TShape();
            var shape7 = new ZShape();


            tmpShapes.Add(shape1);
            tmpShapes.Add(shape2);
            tmpShapes.Add(shape3);
            tmpShapes.Add(shape4);
            tmpShapes.Add(shape5);
            tmpShapes.Add(shape6);
            tmpShapes.Add(shape7);

            var shapes = tmpShapes.OrderBy(a => Guid.NewGuid()).ToList();

            Shapes = shapes;

        }

    }



}
