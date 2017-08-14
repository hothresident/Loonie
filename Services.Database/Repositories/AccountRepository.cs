using Database.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private LoonieContext _context = new LoonieContext();

        public AccountRepository()
        {
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            return _context.Accounts.ToListAsync();
        }

        public Task<Account> GetAccountAsync(int id)
        {
            return _context.Accounts
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Account> AddAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            if (!_context.Accounts.Local.Any(c => c.Id == account.Id))
            {
                _context.Accounts.Attach(account);
            }
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var account = _context.Accounts.FirstOrDefault(c => c.Id == accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
            }
            await _context.SaveChangesAsync();
        }

        //public async Task<int> Save(Account account)
        //{
        //    var retrievedAccount = _context.Accounts
        //        .FirstOrDefaultAsync(a => a.AccountNumber == account.AccountNumber);

        //    if (retrievedAccount != null)
        //    {


        //        return retrievedAccount.Id;
        //    }

        //    var maxId = await _context.Transactions.MaxAsync(t => t.Id);
        //    Models.Account dbAccount = new Models.Account
        //    {
        //        AccountNumber = account.AccountNumber,
        //        Description = account.Description,
        //        Id = maxId + 1,
        //        Transactions = account.Transactions,
        //    Type = account.Type
        //    };

        //    _context.Accounts.Add(dbAccount);
        //    return await _context.SaveChangesAsync();
        //}
    }
}
