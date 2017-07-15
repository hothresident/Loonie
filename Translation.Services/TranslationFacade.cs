using Core.Domain.Models;
using Infrastructure.Translation.Parsers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Translation
{
    public class TranslationFacade : ITranslationFacade
    {
        public async Task<List<Transaction>> ParseFileAsync(string path, int index)
        {
            return await Task.Run(() => SetTransactionIds(QifParser.Parse(path).ToList(), index));
        }

        private List<Transaction> SetTransactionIds(List<Transaction> transactions, int index)
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                index += 1;
                transactions[i].Id = index;
            }

            return transactions;
        }
    }
}
