using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public interface ITransactionRepository
    {
        Task<List<Transaction>> GetTransactionsForAccountAsync(int accountId);
        Task<List<Transaction>> GetTransactionsAsync();
        Task<Transaction> AddTransactionAsync(Transaction transaction);
        Task<Transaction> UpdateTransactionAsync(Transaction transaction);

        Task<int> GetTransactionIndexAsync();
    }
}
