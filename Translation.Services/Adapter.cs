using System;
using System.Collections.Generic;
using Core.Domain.Models;
using Domain.Services.Interfaces;
using Translation.Services.Parsers;
using System.Threading.Tasks;
using System.Linq;

namespace Translation.Services
{
    public class Adapter : IAdapter
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
