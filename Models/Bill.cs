using System.ComponentModel.DataAnnotations;

namespace Apartment_Management.Models
{
    public class Bill
    {
        public int ID { get; set; }
        public int PeriodID { get; set; }
        public int BillTypeID { get; set; }
        public int FlatID { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Amount { get; set; }
        
        public Period Period { get; set; }
        public BillType BillType { get; set; }
        public Flat Flat { get; set; }
    }
}
