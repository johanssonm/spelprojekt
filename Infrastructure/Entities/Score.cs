using Infrastructure.Contracts;

namespace Spelprojekt.Entities
{
    public class Score : IScore
    {
        public int Id { get; set; }
        public int Points { get; set; }

    }
}
