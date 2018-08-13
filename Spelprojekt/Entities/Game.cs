using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class Game
    {
        public int ID { get; set; }
        public bool InPlay { get; set; }
        public List<Shape> Shapes { get; set; }

        public GameGrid GameGrid { get; set; }

    }

}
