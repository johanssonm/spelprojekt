using Microsoft.EntityFrameworkCore;
using Spelprojekt.Data;
using Spelprojekt.Entities;

namespace Spelprojekt.Services
{
    public class DatabaseService
    {
        public void SaveScore(Score score)
        {
            using (var context = new GameContext())
            {
                context.Add(score);
                context.SaveChanges();
            }
        }
    }
}
