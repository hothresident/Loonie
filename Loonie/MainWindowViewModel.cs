using Loonie.Accounts;
using Loonie.Categories;
using Loonie.ExpandedTransactions;
using Loonie.Transactions;
using System.Windows;

namespace Loonie
{
    public class MainWindowViewModel : BindableBase
    {
        private AccountViewModel _accountViewModel = new AccountViewModel();
        private CategoryViewModel _categoryViewModel = new CategoryViewModel();
        private ExpandedTransactionViewModel _expandedTransactionViewModel = new ExpandedTransactionViewModel();
        private TransactionViewModel _transactionViewModel = new TransactionViewModel();

        public RelayCommand ExitCommand { get; private set; }

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public RelayCommand<string> NavCommand { get; private set; }

        public MainWindowViewModel()
        {
            NavCommand = new RelayCommand<string>(OnNav);

            ExitCommand = new RelayCommand(OnExit, CanExit);
        }

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

        private bool CanExit()
        {
            return true;
        }

        private void OnExit()
        {
            Application.Current.Shutdown();
        }
    }
}
