using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PaymentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentAPI.Services
{
    public class PaymentService
    {
        private readonly IMongoCollection<Account> _accountsCollection;

        public PaymentService(IOptions<PaymentDbSettings> paymentDbSettings)
        {
            var mongoClient = new MongoClient(paymentDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(paymentDbSettings.Value.DatabaseName);
            _accountsCollection = mongoDatabase.GetCollection<Account>(paymentDbSettings.Value.BankCardsCollectionName);
        }

        public async Task<List<Account>> GetAsync() => await _accountsCollection.Find(_ => true).ToListAsync();

        public async Task<Account> GetAsync(string cardNumber)
        {
            return await _accountsCollection.Find(x => x.CardNumber == cardNumber).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Account account) => await _accountsCollection.InsertOneAsync(account);

        public async Task UpdateAsync(string cardNumber, Account account) =>
            await _accountsCollection.ReplaceOneAsync(x => x.CardNumber == cardNumber, account);

        public async Task RemoveAsync(string cardNumber) => 
            await _accountsCollection.DeleteOneAsync(x => x.CardNumber == cardNumber);














    }
}
