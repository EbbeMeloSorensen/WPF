using System.Windows.Input;

namespace KeyboardInput2;

public class SecondViewModel
{
    public ICommand GoToFirstViewCommand { get; }

    public SecondViewModel()
    {
        GoToFirstViewCommand = new RelayCommand(_ =>
        {
            var mainVM = (MainWindowViewModel)App.Current.MainWindow.DataContext;
            mainVM.CurrentViewModel = new FirstViewModel();
        });
    }
}