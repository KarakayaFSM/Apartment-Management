namespace Apartment_Management.Models
{
    public class FlatAssignment
    {
        public int FlatID { get; set; }
        public int UserID { get; set; }
        public Flat Flat { get; set; }
        public User User { get; set; }
    }
}
