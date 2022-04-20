using System.ComponentModel.DataAnnotations;

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
        public decimal Amount { get; set; }
        
        public Period Period { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public Flat Flat { get; set; }
    }
}
