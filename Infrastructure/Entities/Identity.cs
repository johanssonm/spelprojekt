using Infrastructure.Contracts;
using Infrastructure.Entities.Contracts;

namespace Spelprojekt.Entities
{
    public class Identity : IIdentity

    {
    
    public int Id { get; set; }
    public string Name { get; set; }

    public int PlayerId { get; set; }
    public Player Player { get; set; }

    }
}