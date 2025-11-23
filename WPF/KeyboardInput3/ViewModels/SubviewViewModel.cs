using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;

namespace KeyboardInput3.ViewModels
{
    public class SubviewViewModel : ViewModelBase
    {
        private bool _shouldFocusInput;
        public bool ShouldFocusInput
        {
            get => _shouldFocusInput;
            set
            {
                _shouldFocusInput = value; 
                RaisePropertyChanged();
            }
        }

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                RaisePropertyChanged();
            }
        }

        public void FocusInput()
        {
            ShouldFocusInput = true;
        }
    }
}
