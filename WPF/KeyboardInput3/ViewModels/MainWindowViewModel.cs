using GalaSoft.MvvmLight;

namespace KeyboardInput3.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private object _currentViewModel;

        public SubviewViewModel SubviewVM { get; }

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
            SubviewVM = new SubviewViewModel();
            CurrentViewModel = SubviewVM;

            // Automatically focus the TextBox at startup
            SubviewVM.FocusInput();
        }
    }
}
