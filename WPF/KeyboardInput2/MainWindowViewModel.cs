using System.ComponentModel;
using System.Windows.Input;

namespace KeyboardInput2
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void Raise(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public ICommand ShowFirstViewCommand { get; }
        public ICommand ShowSecondViewCommand { get; }

        private object _currentViewModel;

        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                Raise(nameof(CurrentViewModel));
            }
        }

        public MainWindowViewModel()
        {
            ShowFirstViewCommand = new RelayCommand(_ => CurrentViewModel = new FirstViewModel());
            ShowSecondViewCommand = new RelayCommand(_ => CurrentViewModel = new SecondViewModel());

            // Start with the first view
            CurrentViewModel = new FirstViewModel();
        }
    }
}
