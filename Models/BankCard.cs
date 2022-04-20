using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class BankCard
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [Required]
        public string Name { get; set; }
        public string CardHolderName { get; set; }
        public int CardNumber { get; set; }
        public int ExpireYear { get; set; }
        public int ExpireMonth { get; set; }
        public int CVV { get; set; }
        public User User { get; set; }
    }
}
