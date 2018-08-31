using System.Collections.Generic;
using Infrastructure.Contracts;
using Spelprojekt.Entities;

namespace Repositories
{
    public class ApiQueryPlayerResult : IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Score> Scores { get; set; }
    }
}