using ATMChallengeOrigin.Data;
using ATMChallengeOrigin.Data.Repository;
using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMChallengeOrigin.Pages.Cards
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;



        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnPost(string pin, int id)
        {
            Card card = _unitOfWork.Card.Get(id);

            bool existPin = card.EncryptedPin == pin;

            if (existPin)
            {
                card.CountError = 0;
                _unitOfWork.Card.Update(card);
                _unitOfWork.Save();
                return RedirectToPage("/operations/Operation", new { id = card.Id });

            }
            else
            {
                card.CountError++;
                _unitOfWork.Card.Update(card);
                _unitOfWork.Save();

            }

            if (card.CountError > 4)
            {
                card.IsBlocked = true;
                _unitOfWork.Card.Update(card);
                _unitOfWork.Save();
                TempData["ErrorMessage"] = "PIN Incorrecto. El usuario puede ingresar un PIN inválido hasta una cantidad máxima de 4 veces. Su tarjeta ha sido bloqueada.";
                return RedirectToPage("/Error");
            }
            TempData["error"] = "El pin ingresado es incorrecto. Por favor, intente nuevamente"; 
            return Page();
        }
        public void OnGet()
        {
        }




    }
}
