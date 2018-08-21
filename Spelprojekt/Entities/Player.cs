using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public Identity Identity { get; set; }
        public List<PlayerScore> PlayerScores { get; set; }


    }

}
