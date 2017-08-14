using Database;
using Database.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private LoonieContext _context = new LoonieContext();


        //public async Task Save(IEnumerable<Transaction> transactions)
        //{
        //    _context.Transactions.AddRange(transactions);
        //    await _context.SaveChangesAsync();
        //}
        public async Task<List<Transaction>> GetTransactionsForAccountAsync(int accountId)
        {
            return await _context.Transactions.Where(t => t.AccountId == accountId)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsAsync()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<Transaction> AddTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> UpdateTransactionAsync(Transaction transaction)
        {
            if (!_context.Transactions.Local.Any(t => t.Id == transaction.Id))
            {
                _context.Transactions.Attach(transaction);
            }
            _context.Entry(transaction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<int> GetTransactionIndexAsync()
        {
            var count = _context.Transactions.CountAsync();
            return await (await count == 0 ? count : _context.Transactions.MaxAsync(t => t.Id)); 
        }
    }
}
