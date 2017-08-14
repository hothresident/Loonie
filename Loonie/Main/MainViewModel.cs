using Database.Models;
using Services.Main;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Database.Repositories;
using System;
using System.Threading.Tasks;

namespace Loonie.Main
{
    public class MainViewModel : BindableBase
    {
        private IAccountRepository _accountRepository;
        private ITransactionRepository _transactionRepository;
        //private IMapper _mapper;

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnSelectAccount(_selectedAccount);
            }
        }

        private ObservableCollection<Account> _accounts;
        public ObservableCollection<Account> Accounts
        {
            get { return _accounts; }
            set { SetProperty(ref _accounts, value); }
        }

        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get { return _transactions; }
            set { SetProperty(ref _transactions, value); }
        }

        //public RelayCommand ExitCommand { get; private set; }
        public RelayCommand ImportCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand<Account> EditAccountCommand { get; private set; }
        //public RelayCommand<Account> SelectAccountCommand { get; private set; }

        //public event Action<Account> EditAccountRequested = delegate { };
        //public event Action<Account> SelectAccountRequested = delegate { };

        public MainViewModel()
        {
            //NavCommand = new RelayCommand<string>(OnNav);

            _accountRepository = ContainerHelper.Container.GetInstance<IAccountRepository>();
            _transactionRepository = ContainerHelper.Container.GetInstance<ITransactionRepository>();
            //_mapper = ContainerHelper.Container.GetInstance<IMapper>();

            //ExitCommand = new RelayCommand(OnExit, CanExit);
            //ImportCommand = new RelayCommand(OnImport);
            //SaveCommand = new RelayCommand(OnSaveAsync);
            //EditAccountCommand = new RelayCommand<Account>(OnEditAccount);
            //SelectAccountCommand = new RelayCommand<Account>(OnSelectAccount);

            Refresh();
        }

        private async void Refresh()
        {
            Accounts = new ObservableCollection<Account>(
                await _accountRepository.GetAccountsAsync());
            Transactions = new ObservableCollection<Transaction>(
                await _transactionRepository.GetTransactionsAsync());
        }

        //private async void ImportAsync(string path)
        //{
        //    if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;

        //    Account = await _importProvider.ImportAsync(path);
        //    Transactions = new ObservableCollection<Transaction>(Account.Transactions);
        //    //var databaseTransactionIndex = await _repository.GetTransactionIndexAsync();
        //    //Transactions = new ObservableCollection<Transaction>(await _adapter.ParseFileAsync(@"c:\discover.qfx", databaseTransactionIndex));
        //}

        //private async void OnSaveAsync()
        //{
        //    await _databaseProvider.AddAccount(new Account
        //    {
        //        AccountNumber = Account.AccountNumber,
        //        Type = "Credit",
        //        Description = "y",
        //        Transactions = new List<Transaction>(Transactions)
        //    });
        //    Refresh();
        //}

        //private void OnImport()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.ShowDialog();
        //    ImportAsync(openFileDialog.FileName);
        //}

        private async void OnSelectAccount(Account account)
        {
            Transactions = new ObservableCollection<Transaction>(
                await _transactionRepository.GetTransactionsForAccountAsync(
                    Convert.ToInt32(account.Id)));
        }
    }
}