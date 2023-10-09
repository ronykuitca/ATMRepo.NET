using ATMChallengeOrigin.Data;
using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMChallengeOrigin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public Card Card { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(string cardNumber)
        {
            if (cardNumber != null)
            {
                cardNumber = cardNumber.Replace("-", "");
            }
            Card cardSearched = _unitOfWork.Card.GetFirstOrDefault(x => x.CardNumber == cardNumber);

            if (cardSearched != null && !cardSearched.IsBlocked)
            {
                return RedirectToPage("cards/Index", new { id = cardSearched.Id });
            }
            if (cardSearched == null)
            {
                TempData["ErrorMessage"] = "ERROR. Tarjeta incorrecta.";
            }
            else { TempData["ErrorMessage"] = "ERROR. Tarjeta bloqueada. Dírigase a la sucursal más cercana para realizar el desbloqueo"; }
            return RedirectToPage("/Error");
        }

    }
}