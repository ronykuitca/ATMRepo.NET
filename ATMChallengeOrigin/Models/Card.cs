using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMChallengeOrigin.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[0-9]{16}$")]
        public string CardNumber { get; set; }
        [Required]
        [RegularExpression("^[0-9]{4}$")]
        public string EncryptedPin { get; set; }
        public bool IsBlocked { get; set; }
        public double Balance { get; set; }
        public int CountError { get; set; }
        public DateTime ExpirationDate { get; set; }

    }
}
