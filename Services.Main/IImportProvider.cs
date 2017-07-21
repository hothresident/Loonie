using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Services.Main
{
    public interface IImportProvider
    {
        Task<ObservableCollection<Transaction>> ImportAsync(string path);
    }
}