using Core.Domain.Models;
using Infrastructure.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Main
{
    public class DatabaseProvider : IDatabaseProvider
    {
        private IRepository _repository;

        public DatabaseProvider(IRepository repository)
        {
            _repository = repository;
        }

        public async Task Save(IEnumerable<Transaction> transactions)
        {
            await _repository.Save(transactions);
        }

        public async Task<List<Transaction>> GetAsync()
        {
            return new List<Transaction>(await _repository.GetAsync());
        }
    }
}
