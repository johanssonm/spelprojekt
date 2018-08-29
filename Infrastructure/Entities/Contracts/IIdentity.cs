using Infrastructure.Contracts;

namespace Infrastructure.Entities.Contracts
{
    public interface IIdentity
    {

            int Id { get; set; }
            string Name { get; set; }

    }
}

