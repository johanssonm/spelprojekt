using Spelprojekt.Entities;

namespace Spelprojekt.Data
{
    public class DatabaseService
    {
        public void SaveScore(Score score)
        {
            using (var context = new GameContext())
            {
                context.Add(score);

            }
        }
    }
}
