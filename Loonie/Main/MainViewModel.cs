using Database.Models;
using Database.Repositories;
using System;
using System.Collections.ObjectModel;

namespace Loonie.Main
{
    public class MainViewModel : BindableBase
    {
        private IAccountRepository _accountRepository;
        private ITransactionRepository _transactionRepository;

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnSelectAccount();
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

        public RelayCommand ImportCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }
        public RelayCommand EditAccountCommand { get; private set; }
        public RelayCommand SelectAllAccountsCommand { get; private set; }

        public MainViewModel()
        {
            _accountRepository = ContainerHelper.Container.GetInstance<IAccountRepository>();
            _transactionRepository = ContainerHelper.Container.GetInstance<ITransactionRepository>();

            //EditAccountCommand = new RelayCommand(OnEditAccount);
            SelectAllAccountsCommand = new RelayCommand(OnSelectAllAccounts);

            LoadAccountsAndTransactions();
        }

        private async void LoadAccountsAndTransactions()
        {
            Accounts = new ObservableCollection<Account>(
                await _accountRepository.GetAccountsAsync());
            Transactions = new ObservableCollection<Transaction>(
                await _transactionRepository.GetTransactionsAsync());
        }

        private async void OnSelectAccount()
        {
            Transactions = new ObservableCollection<Transaction>(
                await _transactionRepository.GetTransactionsForAccountAsync(
                    Convert.ToInt32(_selectedAccount.Id)));
        }

        private async void OnSelectAllAccounts()
        {
            Transactions = new ObservableCollection<Transaction>(
                await _transactionRepository.GetTransactionsAsync());
        }
    }
}