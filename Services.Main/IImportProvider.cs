using Database.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Services.Main
{
    public interface IImportProvider
    {
        Task<Account> ImportAsync(string path);
    }
}