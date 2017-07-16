using Loonie.ViewModels;
using System.Windows;

namespace Loonie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel
        {
            set { DataContext = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        //private void CanExit(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        //private void ImportCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = true;
        //}

        //private void ImportCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        //{
        //}
    }
}
