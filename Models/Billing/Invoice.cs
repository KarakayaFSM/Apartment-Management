

namespace Apartment_Management.Models
{
    public class Invoice
    {
        public int ID { get; set; }
        public int PeriodID { get; set; }
        public int InvoiceTypeID { get; set; }
        public int FlatID { get; set; }

        public Period Period { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public Flat Flat { get; set; }
    }
}
