﻿using System.Collections.Generic;

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

            var shapes = tmpShapes;

            //int i = 0;

            //foreach (var shape in shapes) // TODO: Kan behövas för debug
            //{
            //    shape.Id = i;
            //    i++;
            //}

            Shapes = shapes;

            ShapesPlayed = 0;

        }

    }



}
