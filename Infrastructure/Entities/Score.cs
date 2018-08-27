namespace Spelprojekt.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public Player Player { get; set; }

        public int PlayerId { get; set; }

    }
}
