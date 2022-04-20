using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apartment_Management.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public int PeriodID { get; set; }
        public int InvoiceTypeID { get; set; }
        public int FlatID { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        
        public Period Period { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public Flat Flat { get; set; }
    }
}
