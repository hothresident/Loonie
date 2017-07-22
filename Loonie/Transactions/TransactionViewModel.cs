using Core.Domain.Models;
using Infrastructure.Common.Mappings;
using Services.Main;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Loonie.Transactions
{
    public class TransactionViewModel : BindableBase
    {
        private IImportProvider _importProvider;
        private IDatabaseProvider _databaseProvider;
        private IMapper _mapper;

        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get { return _transactions; }
            set { SetProperty(ref _transactions, value); }
        }

        //public RelayCommand ExitCommand { get; private set; }
        public RelayCommand ImportCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        public TransactionViewModel()
        {
            //NavCommand = new RelayCommand<string>(OnNav);
            _importProvider = ContainerHelper.Container.GetInstance<IImportProvider>();
            _databaseProvider = ContainerHelper.Container.GetInstance<IDatabaseProvider>();
            _mapper = ContainerHelper.Container.GetInstance<IMapper>();

            //ExitCommand = new RelayCommand(OnExit, CanExit);
            ImportCommand = new RelayCommand(OnImport);
            SaveCommand = new RelayCommand(OnSaveAsync);

            Refresh();
        }

        private async void Refresh()
        {
            Transactions = new ObservableCollection<Transaction>(await _databaseProvider.GetAsync());
        }

        private async Task ImportAsync()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;

            Transactions = await _importProvider.ImportAsync(@"c:\discover.qfx");
            //var databaseTransactionIndex = await _repository.GetTransactionIndexAsync();
            //Transactions = new ObservableCollection<Transaction>(await _adapter.ParseFileAsync(@"c:\discover.qfx", databaseTransactionIndex));
        }

        private async void OnSaveAsync()
        {
            await _databaseProvider.Save(Transactions);
            Refresh();
        }

        private async void OnImport()
        {
            await ImportAsync();
        }
    }
}