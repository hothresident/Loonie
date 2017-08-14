using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Main
{
    public interface IDatabaseProvider
    {
        //Task<List<Transaction>> GetTransactionsAsync();
        //Task SaveTransactions(IEnumerable<Transaction> transactions);
        Task<List<Account>> GetAccountsAsync();
        Task<List<Transaction>> GetTransactionsAsync();
        Task AddAccount(Account account);
    }
}