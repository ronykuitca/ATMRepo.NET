using ATMChallengeOrigin.Models;

namespace ATMChallengeOrigin.Data.Repository.IRepository
{
    public interface IOperationRepository : IRepository<Operation>
    {
        void Update(Operation obj);
    }
}
