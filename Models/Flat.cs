using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{

    public enum FlatSize { 
        ONE_PLUS_ONE,
        TWO_PLUS_ONE,
        THREE_PLUS_ONE,
        FOUR_PLUS_ONE
    }

    public class Flat
    {
        public int FlatID { get; set; }
        [Required]
        public string BlockCode { get; set; }
        public bool IsFull { get; set; }
        [Required]
        public FlatSize FlatSize { get; set; }
        [Required]
        public int Floor { get; set; }
        [Required]
        public int DoorNum { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
