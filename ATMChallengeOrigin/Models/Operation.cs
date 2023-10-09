using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMChallengeOrigin.Models
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        public int CardId { get; set; }
        
        [ForeignKey("CardId")]
        [ValidateNever]
        public Card Card { get; set; }

        public string Code { get; set; }
        public DateTime Time { get; set; }        
        public double? MoneyWithdrawn { get; set; }

    }
}
