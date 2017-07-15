using Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IAdapter
    {
        Task<List<Transaction>> ParseFileAsync(string path, int index);
    }
}
