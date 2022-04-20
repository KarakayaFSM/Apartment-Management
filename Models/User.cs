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
        
        [Required]
        [Column(name: "ManagerId")]
        public int ManagerId { get; set; }

        public ICollection<Flat> Flats { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
