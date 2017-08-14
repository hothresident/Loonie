using Database.Models;
using Infrastructure.Translation.Parsers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Translation
{
    public class TranslationFacade : ITranslationFacade
    {
        public async Task<Account> ParseFileAsync(string path, int index)
        {
            var account = QifParser.Parse(path);

            return await Task.Run(() => SetTransactionIds(QifParser.Parse(path), index));
        }

        private Account SetTransactionIds(Account account, int index)
        {
            for (int i = 0; i < account.Transactions.Count(); i++)
            {
                index += 1;
                account.Transactions[i].Id = index;
            }

            return account;
        }
    }
}
