using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Models;

namespace ATMChallengeOrigin.Data.Repository
{
    public class OperationRepository : Repository<Operation>, IOperationRepository
    {
        private ApplicationDbContext _db;
        public OperationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Operation obj)
        {
            _db.Operations.Update(obj);
        }
    }
}