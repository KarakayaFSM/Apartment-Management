using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartment_Management.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [Column(name: "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength (11, ErrorMessage ="TC kimlik numarası 11 hane olmalıdır")]
        [Column (name:"Tckn")]
        public string Tckn { get; set; }

        [Required]
        [EmailAddress]
        [Column (name: "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Column (name: "PhoneNumber")]
        public string PhoneNumber { get; set; }

        public ICollection<FlatAssignment> FlatAssignments { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<BankCard> Cards { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
