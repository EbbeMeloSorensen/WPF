using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace KeyboardInput
{
    public class SubViewModel : ViewModelBase
    {
        private RelayCommand _dummyCommandInSubViewModel;

        public RelayCommand DummyCommandInSubViewModel =>
            _dummyCommandInSubViewModel ?? (_dummyCommandInSubViewModel =
                new RelayCommand(DummyMethodInSubViewModel));

        private void DummyMethodInSubViewModel()
        {
            throw new NotImplementedException();
        }
    }
}
