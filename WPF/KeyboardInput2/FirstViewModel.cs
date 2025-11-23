using System.Windows.Input;

namespace KeyboardInput2;

public class FirstViewModel
{
    public ICommand GoToSecondViewCommand { get; }

    public FirstViewModel()
    {
        // This switches the ContentControl to the SecondView
        GoToSecondViewCommand = new RelayCommand(_ =>
        {
            // Resolve the MainWindowViewModel (simplest approach for demo)
            var mainVM = (MainWindowViewModel)App.Current.MainWindow.DataContext;
            mainVM.CurrentViewModel = new SecondViewModel();
        });
    }
}