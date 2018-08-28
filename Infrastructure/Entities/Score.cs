using Business.Contracts;

namespace Spelprojekt.Entities
{
    public class Score : IScore
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public IPlayer Player { get; set; }

        public int PlayerId { get; set; }

    }
}
