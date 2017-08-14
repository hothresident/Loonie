using Database.Models;
using System.Threading.Tasks;

namespace Infrastructure.Translation
{
    public interface ITranslationFacade
    {
        Task<Account> ParseFileAsync(string path, int index);
    }
}
