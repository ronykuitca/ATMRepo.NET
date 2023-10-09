using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMChallengeOrigin.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICardRepository Card { get; }
        IOperationRepository Operation { get; }

        void Save();
    }
}
