using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ATMChallengeOrigin.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            ErrorMessage = TempData["ErrorMessage"]?.ToString();
        }
        public IActionResult OnPostLogOut()
        {
            return RedirectToPage("/Index");
        }
    }

}