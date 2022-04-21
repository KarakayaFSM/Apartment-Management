using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace PaymentAPI.Models
{
    public class Account
    {
        public string CardHolderName { get; set; }

        [Required]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string CardNumber { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [Required]
        public int ExpireYear { get; set; }

        [Required]
        public int ExpireMonth { get; set; }

        [Required]
        public int CVV { get; set; }
        [Required]
        public decimal Balance { get; set; } = 10000;
    }
}
