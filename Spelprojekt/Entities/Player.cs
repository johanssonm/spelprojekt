using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class Player
    {
        public int PlayerId { get; set; }
        public Identity Identity { get; set; }

        public List<Score> Scores { get; set; }

    }
}
