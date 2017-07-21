using Core.Domain.Models;
using Infrastructure.Common.Mappings;
using Infrastructure.Database;
using Infrastructure.Translation;
using Loonie.Accounts;
using Loonie.Categories;
using Loonie.ExpandedTransactions;
using Loonie.Transactions;
using Services.Main;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Loonie
{
    public class MainWindowViewModel : BindableBase
    {
        private AccountViewModel _accountViewModel = new AccountViewModel();
        private CategoryViewModel _categoryViewModel = new CategoryViewModel();
        private ExpandedTransactionViewModel _expandedTransactionViewModel = new ExpandedTransactionViewModel();
        private TransactionViewModel _transactionViewModel = new TransactionViewModel();

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        //private IImportProvider _importProvider;
        ////private ITranslationFacade _translationFacade;
        //private IDatabaseProvider _databaseProvider;
        //private IMapper _mapper;
        ////private IRepository _repository;
        //private BindableBase _CurrentViewModel;

        //private ObservableCollection<Transaction> _transactions;

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "expandedTransactions":
                    CurrentViewModel = _expandedTransactionViewModel;
                    break;
                case "transactions":
                    CurrentViewModel = _transactionViewModel;
                    break;
                case "categories":
                    CurrentViewModel = _categoryViewModel;
                    break;
                default:
                    CurrentViewModel = _accountViewModel;
                    break;
            }
        }

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);

            //_importProvider = ContainerHelper.Container.GetInstance<IImportProvider>();
            //_databaseProvider = ContainerHelper.Container.GetInstance<IDatabaseProvider>();
            //_mapper = ContainerHelper.Container.GetInstance<IMapper>();

            //ExitCommand = new RelayCommand(OnExit, CanExit);
            //ImportCommand = new RelayCommand(OnImport);
            //SaveCommand = new RelayCommand(OnSaveAsync);

            //Refresh();
        }

        //private async void Refresh()
        //{
        //    Transactions = new ObservableCollection<Transaction>(await _databaseProvider.GetAsync());
        //}

        //private async Task ImportAsync()
        //{
        //    if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;

        //    Transactions = await _importProvider.ImportAsync(@"c:\discover.qfx");
        //    //var databaseTransactionIndex = await _repository.GetTransactionIndexAsync();
        //    //Transactions = new ObservableCollection<Transaction>(await _adapter.ParseFileAsync(@"c:\discover.qfx", databaseTransactionIndex));
        //}

        //public RelayCommand ExitCommand { get; private set; }
        //public RelayCommand ImportCommand { get; private set; }
        //public RelayCommand SaveCommand { get; private set; }

        //private async void OnSaveAsync()
        //{
        //    await _databaseProvider.Save(Transactions);
        //    Refresh();
        //}

        //private async void OnImport()
        //{
        //    await ImportAsync();
        //}

        //private bool CanExit()
        //{
        //    return true;
        //}

        //private void OnExit()
        //{
        //    Application.Current.Shutdown();
        //}

        //public ObservableCollection<Transaction> Transactions
        //{
        //    get
        //    {
        //        return _transactions;
        //    }
        //    set
        //    {
        //        if (_transactions != value)
        //        {
        //            _transactions = value;
        //            PropertyChanged(this, new PropertyChangedEventArgs("Transactions"));
        //        }
        //    }
        //}
    }
}
