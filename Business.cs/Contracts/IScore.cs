namespace Business.Contracts
{
    public interface IScore
    {
        int Id { get; set; }
        int Points { get; set; }
        IPlayer Player { get; set; }

        int PlayerId { get; set; }
    }
}