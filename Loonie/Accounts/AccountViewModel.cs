using Database.Models;
using Database.Repositories;
using Microsoft.Win32;
using Services.Main;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Loonie.Accounts
{
    public class AccountViewModel : BindableBase
    {
        private IAccountRepository _accountRepository;

        public AccountViewModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;//ContainerHelper.Container.GetInstance<IAccountRepository>();
        }
    }
}
