using Database.Models;
using Microsoft.Win32;
using Services.Main;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Loonie.Import
{
    public class ImportViewModel : BindableBase
    {
        private IDatabaseProvider _databaseProvider;
        private IImportProvider _importProvider;

        public Account Account { get; set; }
        private ObservableCollection<Transaction> _transactions;
        public ObservableCollection<Transaction> Transactions
        {
            get { return _transactions; }
            set { SetProperty(ref _transactions, value); }
        }

        //private ObservableCollection<Account> _accounts;
        //public ObservableCollection<Account> Accounts
        //{
        //    get { return _accounts; }
        //    set { SetProperty(ref _accounts, value); }
        //}
        public ImportViewModel()
        {
            _importProvider = ContainerHelper.Container
                .GetInstance<IImportProvider>();
            _databaseProvider = ContainerHelper.Container
                .GetInstance<IDatabaseProvider>();

            Refresh();
        }

        private async void Refresh()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();

            Account = await _importProvider.ImportAsync(openFileDialog.FileName);
            Transactions = new ObservableCollection<Transaction>(Account.Transactions);
        }

        public async Task SaveAsync()
        {
            await _databaseProvider.AddAccount(new Account
            {
                AccountNumber = Account.AccountNumber,
                Type = "Credit",
                Description = "y",
                Transactions = new List<Transaction>(Transactions)
            });
        }
    }
}
