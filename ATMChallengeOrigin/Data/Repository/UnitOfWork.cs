using ATMChallengeOrigin.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMChallengeOrigin.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public ICardRepository Card { get; private set; }
        public IOperationRepository Operation { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Card = new CardRepository(_db);
            Operation = new OperationRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
