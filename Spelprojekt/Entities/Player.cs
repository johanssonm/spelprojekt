using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Score> Scores { get; set; }
    }
}
