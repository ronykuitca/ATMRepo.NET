using ATMChallengeOrigin.Models;

namespace ATMChallengeOrigin.Data.Repository.IRepository
{
    public interface ICardRepository : IRepository<Card>
    {
        void Update(Card obj);
    }
}
