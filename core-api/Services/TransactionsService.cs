using core_api.Services.Interfaces;
using System.Transactions;

namespace core_api.Services
{
    public class TransactionsService : ITransactionsService
    {
        public Task<IList<Transaction>> GetTransactions()
        {
            throw new NotImplementedException();
        }
        public Task<Transaction?> GetTransactionById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Transaction> CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
        public bool DeleteTransaction(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Transaction> UpdateTransaction(int id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
