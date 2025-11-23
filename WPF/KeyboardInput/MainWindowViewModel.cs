using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace KeyboardInput
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RelayCommand _dummyCommandMainWindowViewModel;

        public SubViewModel SubViewModel { get; }

        public RelayCommand DummyCommandMainWindowViewModel =>
            _dummyCommandMainWindowViewModel ?? (_dummyCommandMainWindowViewModel =
                new RelayCommand(DummyMethodImMainViewModel));

        private void DummyMethodImMainViewModel()
        {
            throw new NotImplementedException();
        }

        public MainWindowViewModel()
        {
            SubViewModel = new SubViewModel();
        }
    }
}
