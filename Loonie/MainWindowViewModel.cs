using Loonie.Categories;
using Loonie.ExpandedTransactions;
using Loonie.Main;
using Loonie.Import;
using System.Windows;
using System.Threading.Tasks;

namespace Loonie
{
    public class MainWindowViewModel : BindableBase
    {
        private MainViewModel _mainViewModel = new MainViewModel();
        private ImportViewModel _importViewModel;
        //private CategoryViewModel _categoryViewModel = new CategoryViewModel();
        //private ExpandedTransactionViewModel _expandedTransactionViewModel = new ExpandedTransactionViewModel();

        public delegate Task SaveHandler();
        public event SaveHandler SavedEvent;

        public RelayCommand ExitCommand { get; private set; }
        public RelayCommand SaveCommand { get; private set; }

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
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CurrentViewModel = _mainViewModel;
        }

        private void OnNav(string destination)
        {
            switch (destination)
            {
                //case "expandedTransactions":
                //    CurrentViewModel = _expandedTransactionViewModel;
                //    break;
                case "import":
                    _importViewModel = new ImportViewModel();
                    CurrentViewModel = _importViewModel; //_importViewModel;
                    SavedEvent += new SaveHandler(_importViewModel.SaveAsync);
                    break;
                //case "categories":
                //    CurrentViewModel = _categoryViewModel;
                    //break;
                default:
                    CurrentViewModel = _mainViewModel;
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

        private bool CanSave()
        {
            return true;
        }

        private void OnSave()
        {
            Application.Current.Shutdown();
        }
    }
}
