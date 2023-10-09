using System;
using ATMChallengeOrigin.Data.Repository.IRepository;
using ATMChallengeOrigin.Migrations;
using ATMChallengeOrigin.Models;
using ATMChallengeOrigin.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMChallengeOrigin.Pages
{
    public class WithdrawalModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Card Card { get; set; }

        public WithdrawalModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int cardId)
        {
            Card = _unitOfWork.Card.Get(cardId);
        }


        public IActionResult OnPostWithdraw(double mount)
        {
            Card = _unitOfWork.Card.Get(Card.Id);
            if (mount > Card.Balance)
            {
                TempData["ErrorMessage"] = "ERROR. El monto es superior al saldo disponible.";
                return RedirectToPage("/Error");
            }
            else
            {
                string operationCode = CreateRecord(mount); 
                Card.Balance -= mount;
                _unitOfWork.Card.Update(Card);
                _unitOfWork.Save();

                return Redirect($"/operations/OperationReport?operationCode={operationCode}");
            }
        }

        private string CreateRecord(double mount)
        {
            var operation = new Operation
            {
                CardId = Card.Id,
                Time = DateTime.Now,
                Code = RandomCode.RandomString(8),
                MoneyWithdrawn = mount
            };
            _unitOfWork.Operation.Add(operation);
            _unitOfWork.Save();

            return operation.Code; 
        }

    }
}
