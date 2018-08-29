using System.Collections.Generic;
using Infrastructure.Contracts;
using Infrastructure.Entities.Contracts;

namespace Spelprojekt.Entities
{
    public class Player : IPlayer
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
