using System.Collections.Generic;

namespace Spelprojekt.Entities
{
    public class TestPlayers
    {
        public static List<Player> Players()
        {
            var players = new List<Player>();

            var player = new Player();
            var score = new Score();

            player.Identity.Name = "Kurt";
            score.Points = 11;
            player.Scores.Add(score);

            var player1 = new Player();
            var score1 = new Score();

            player1.Identity.Name = "Anna";
            score1.Points = 22;
            player1.Scores.Add(score1);

            var player2 = new Player();
            var score2 = new Score();

            player2.Identity.Name = "Lisa";
            score2.Points = 33;
            player2.Scores.Add(score2);

            var player3 = new Player();
            var score3 = new Score();

            player3.Identity.Name = "Bertil";
            score3.Points = 44;
            player3.Scores.Add(score3);

            var player4 = new Player();
            var score4 = new Score();

            player4.Identity.Name = "Gunhild";
            score4.Points = 55;
            player4.Scores.Add(score4);

            players.Add(player);
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            return players;
        }
    }
}
