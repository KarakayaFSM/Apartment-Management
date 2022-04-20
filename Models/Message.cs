using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class Message
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsRead { get; set; }

        public User User { get; set; }
    }
}
