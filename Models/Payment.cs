namespace Apartment_Management.Models
{
    public class Payment
    {
        public int ID { get; set; }
        public int FlatID { get; set; }
        public decimal Amount { get; set; }
        public Flat Flat { get; set; }
    }
}
