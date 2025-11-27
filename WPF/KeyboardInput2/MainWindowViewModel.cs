using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace KeyboardInput2
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ICommand ShowACommand { get; }
        public ICommand ShowBCommand { get; }

        private object _currentViewModel;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                RaisePropertyChanged();

            }
        }

        public MainWindowViewModel()
        {
            SubviewA = new SubviewAViewModel();
            SubviewB = new SubviewBViewModel();

            ShowACommand = new RelayCommand(() => CurrentViewModel = SubviewA);
            ShowBCommand = new RelayCommand(() => CurrentViewModel = SubviewB);

            CurrentViewModel = SubviewA; // default
        }

        public SubviewAViewModel SubviewA { get; }
        public SubviewBViewModel SubviewB { get; }
    }
}
