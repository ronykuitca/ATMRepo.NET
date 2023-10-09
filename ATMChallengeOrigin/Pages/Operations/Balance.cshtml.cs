using ATMChallengeOrigin.Data;
using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Models;
using ATMChallengeOrigin.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMChallengeOrigin.Pages.Operations
{
    public class BalanceModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Card Card { get; set; }


        public BalanceModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int cardId)
        {
            Card = _unitOfWork.Card.Get(cardId);
            GenerateBalance();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/Operations/Operation", new { cardId = Card.Id });
        }

        public IActionResult OnPostLogOut()
        {
            return RedirectToPage("/Index");
        }

        private void GenerateBalance()
        {
            var operation = new Operation
            {
                CardId = Card.Id,
                Time = DateTime.Now,
                Code = RandomCode.RandomString(8)
            };

            _unitOfWork.Operation.Add(operation);
            _unitOfWork.Save();
        }
    }
}

