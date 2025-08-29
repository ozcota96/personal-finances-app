using System.Transactions;

namespace core_api.Services.Interfaces
{
    public interface ITransactionsService
    {
        Task<IList<Transaction>> GetTransactions();
        Task<Transaction?> GetTransactionById(int id);
        Task<Transaction> CreateTransaction(Transaction transaction);
        Task<Transaction> UpdateTransaction(int id, Transaction transaction);
        bool DeleteTransaction(int id);
    }
}
