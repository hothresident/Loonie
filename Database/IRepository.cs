using Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public interface IRepository
    {
        Task Save(IEnumerable<Transaction> transactions);
        Task<List<Transaction>> GetAsync();
        Task<int> GetTransactionIndexAsync();
    }
}
