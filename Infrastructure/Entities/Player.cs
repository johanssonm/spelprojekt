using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class Player
    {
        public int Id { get; set; }

        public Identity Identity { get; set; }

        public ICollection<Score> Scores { get; set; }

        public Player()
        {
            Identity = new Identity();
            Scores = new List<Score>();
        }
    }

}
