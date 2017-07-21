using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Services.Main
{
    public interface IDatabaseProvider
    {
        Task<List<Transaction>> GetAsync();
        Task Save(IEnumerable<Transaction> transactions);
    }
}