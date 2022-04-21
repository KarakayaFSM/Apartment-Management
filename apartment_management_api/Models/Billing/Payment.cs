using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartment_Management.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public int FlatID { get; set; }
        
        [Required]
        [Range(1, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }

        public Flat Flat { get; set; }
    }
}
