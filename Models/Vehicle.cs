namespace Apartment_Management.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Plate { get; set; }

        public User User { get; set; }
    }
}
