using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class BankCard
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CardHolderName { get; set; }

        [Required]
        
        public int CardNumber { get; set; }
        [Required]
        
        public int ExpireYear { get; set; }
        [Required]
        
        public int ExpireMonth { get; set; }
        [Required]
        
        public int CVV { get; set; }
        public User User { get; set; }
    }
}
