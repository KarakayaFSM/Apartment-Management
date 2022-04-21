namespace PaymentAPI.Models
{
    public class PaymentDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string BankCardsCollectionName { get; set; } = null!;
    }
}
