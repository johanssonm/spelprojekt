using System;
using System.Collections.Generic;
using System.Linq;

namespace Spelprojekt.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public bool InPlay { get; set; }
        public int ShapesPlayed { get; set; }
        public List<Shape> Shapes { get; set; }

        public GameGrid GameGrid { get; set; }

        public Game()
        {
            InPlay = true;

            var tmpShapes = new List<Shape>();

            var shape1 = new IShape();
            shape1.Id = 1;

            var shape2 = new JShape();
            shape2.Id = 2;

            var shape3 = new LShape();
            shape3.Id = 3;

            var shape4 = new OShape();
            shape4.Id = 4;

            var shape5 = new SShape();
            shape5.Id = 5;

            var shape6 = new TShape();
            shape6.Id = 6;

            var shape7 = new ZShape();
            shape7.Id = 7;

            tmpShapes.Add(shape1);
            tmpShapes.Add(shape2);
            tmpShapes.Add(shape3);
            tmpShapes.Add(shape4);
            tmpShapes.Add(shape5);
            tmpShapes.Add(shape6);
            tmpShapes.Add(shape7);

            //var shapes = tmpShapes.OrderBy(a => Guid.NewGuid()).ToList();

            Shapes = tmpShapes;

            ShapesPlayed = 0;

        }

    }



}
