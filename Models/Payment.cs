using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public int FlatID { get; set; }
        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }
        public Flat Flat { get; set; }
    }
}
