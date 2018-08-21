using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class PlayerScore
    {
       public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int ScoreId { get; set; }
        public Score Score { get; set; }

        public PlayerScore()
        {
            
        }

        public PlayerScore(Player player, Score score)
        {
            Player = player;
            Score = score;

        }

    }
}