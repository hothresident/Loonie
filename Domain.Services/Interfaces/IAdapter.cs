using Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IAdapter
    {
        Task<IEnumerable<Transaction>> ParseFileAsync(string path);
    }
}
