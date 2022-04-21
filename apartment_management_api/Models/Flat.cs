using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class Flat
    {
        public int ID { get; set; }
        [Required]
        public string FlatLabel { get; set; }
        [Required]
        public string BlockCode { get; set; }
        public bool IsFull { get; set; } = false;
        [Required]
        public string FlatSize { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int DoorNum { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
