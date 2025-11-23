using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfFocusFinal.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public ICommand ShowFirstCommand { get; }
        public ICommand ShowSecondCommand { get; }

        public MainWindowViewModel()
        {
            ShowFirstCommand = new RelayCommand(_ => CurrentViewModel = new FirstViewModel());
            ShowSecondCommand = new RelayCommand(_ => CurrentViewModel = new SecondViewModel());

            CurrentViewModel = new FirstViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
