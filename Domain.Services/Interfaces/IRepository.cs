using Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IRepository
    {
        Task Save(IEnumerable<Transaction> transactions);
        Task<List<Transaction>> GetAsync();
        Task<int> GetTransactionIndexAsync();
    }
}
