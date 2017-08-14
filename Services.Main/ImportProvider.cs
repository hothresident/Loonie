using Database.Models;
using Database.Repositories;
using Infrastructure.Translation;
using System.Threading.Tasks;

namespace Services.Main
{
    public class ImportProvider : IImportProvider
    {
        private ITransactionRepository _repository;
        private ITranslationFacade _translationFacade;

        public ImportProvider(ITransactionRepository repository, 
            ITranslationFacade translationFacade)
        {
            _repository = repository;
            _translationFacade = translationFacade;
        }

        //public async Task<ObservableCollection<Transaction>> ImportAsync(string path)
        //{
        //    var databaseTransactionIndex =
        //        await _repository.GetTransactionIndexAsync();

        //    return new ObservableCollection<Transaction>(await _translationFacade
        //        .ParseFileAsync(path, databaseTransactionIndex));
        //}

        public async Task<Account> ImportAsync(string path)
        {
            var databaseTransactionIndex =
                await _repository.GetTransactionIndexAsync();

            return await _translationFacade
                .ParseFileAsync(path, databaseTransactionIndex);
        }
    }
}
