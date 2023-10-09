using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMChallengeOrigin.Pages.Operations
{
    public class OperationModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Card Card { get; set; }

        public OperationModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Card = _unitOfWork.Card.Get(id);
        }

        public IActionResult OnPostBalance()
        {
            return RedirectToPage("../operations/Balance", new { cardId = Card.Id });
        }

        public IActionResult OnPostWithdrawal()
        {
            return RedirectToPage("../operations/Withdrawal", new { cardId = Card.Id });
        }

        public IActionResult OnPostLogOut()
        {
            return RedirectToPage("/Index");
        }
    }
}
