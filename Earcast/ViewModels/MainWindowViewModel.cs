using Core.Domain.Models;
using Domain.Services.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace Loonie.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IAdapter _adapter;
        private IMapper _mapper;
        private IRepository _repository;
        private BindableBase _CurrentViewModel;
        private ObservableCollection<Transaction> _transactions;

        //BindableBase
        //public BindableBase CurrentViewModel
        //{
        //    get { return _CurrentViewModel; }
        //    set { SetProperty(ref _CurrentViewModel, value); }
        //}

        public RelayCommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                //case "orderPrep":
                //    CurrentViewModel = _orderPrepViewModel;
                //    break;
                //case "customers":
                //default:
                //    CurrentViewModel = _customerListViewModel;
                //    break;
            }
        }

        public MainWindowViewModel()
        {
            _adapter = ContainerHelper.Container.GetInstance<IAdapter>();
            _repository = ContainerHelper.Container.GetInstance<IRepository>();
            //_mapper = ContainerHelper.Container.GetInstance<IMapper>();

            NavCommand = new RelayCommand<string>(OnNav);
            ExitCommand = new RelayCommand(OnExit, CanExit);
            ImportCommand = new RelayCommand(OnImport);
            SaveCommand = new RelayCommand(OnSave);
        }

        private async Task ImportAsync()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;

            Transactions = new ObservableCollection<Transaction>(await _adapter.ParseFileAsync(@"c:\ccd.qfx"));
        }

        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand ImportCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

        private void OnSave()
        {
            _repository.Save(Transactions);
        }

        private async void OnImport()
        {
            await ImportAsync();
        }

        private bool CanExit()
        {
            return true;
        }

        private void OnExit()
        {
            Application.Current.Shutdown();
        }
        public ObservableCollection<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                if (_transactions != value)
                {
                    _transactions = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Transactions"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
