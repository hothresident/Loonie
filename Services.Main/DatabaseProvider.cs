using Database.Models;
using Database.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Main
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private ITransactionRepository _transactionRepository;
        private IAccountRepository _accountRepository;

        public DatabaseProvider(ITransactionRepository transactionRepository, 
            IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }

        //public async Task SaveTransactions(IEnumerable<Transaction> transactions)
        //{
        //    await _repository.Save(transactions);
        //}

        //public async Task<List<Transaction>> GetTransactionsAsync()
        //{
        //    return new List<Transaction>(await _repository.GetAsync());
        //}

        public async Task<List<Account>> GetAccountsAsync()
        {
            return new List<Account>(
                await _accountRepository.GetAccountsAsync());
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return new List<Transaction>(
                await _transactionRepository.GetTransactionsAsync());
        }

        public async Task AddAccount(Account account)
        {
            await _accountRepository.AddAccountAsync(account);
        }
    }
}
