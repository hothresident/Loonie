using Core.Domain.Models;
using Infrastructure.Database;
using Infrastructure.Translation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Services.Main
{
    public class ImportProvider : IImportProvider
    {
        private IRepository _repository;
        private ITranslationFacade _translationFacade;

        public ImportProvider(IRepository repository, 
            ITranslationFacade translationFacade)
        {
            _repository = repository;
            _translationFacade = translationFacade;
        }

        public async Task<ObservableCollection<Transaction>> ImportAsync(string path)
        {
            var databaseTransactionIndex =
                await _repository.GetTransactionIndexAsync();

            return new ObservableCollection<Transaction>(await _translationFacade
                .ParseFileAsync(path, databaseTransactionIndex));
        }
    }
}
