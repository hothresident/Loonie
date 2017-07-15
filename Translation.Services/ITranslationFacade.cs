using Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Translation
{
    public interface ITranslationFacade
    {
        Task<List<Transaction>> ParseFileAsync(string path, int index);
    }
}
