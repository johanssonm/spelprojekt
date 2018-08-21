using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int Points { get; set; }

        public List<PlayerScore> PlayerScore { get; set; }

    }
}
