using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMChallengeOrigin.Data.Repository
{
    public class CardRepository: Repository<Card>, ICardRepository
    {
        private ApplicationDbContext _db;
        public CardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Card obj)
        {
            _db.Cards.Update(obj);
        }
    }
}
