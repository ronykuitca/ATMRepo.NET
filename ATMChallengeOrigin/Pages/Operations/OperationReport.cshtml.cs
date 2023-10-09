using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMChallengeOrigin.Pages.Operations
{
    public class OperationReportModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Card Card { get; set; }
        public Operation Operation { get; set; }

        public OperationReportModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(string operationCode)
        {
            Operation = _unitOfWork.Operation.GetFirstOrDefault(x => x.Code == operationCode);
            Card = _unitOfWork.Card.Get(Operation.CardId);
           
        }
    }
}
