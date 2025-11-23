using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KeyboardInput3.ViewModels
{
    public class SubviewViewModel : INotifyPropertyChanged
    {
        private bool _shouldFocusInput;
        public bool ShouldFocusInput
        {
            get => _shouldFocusInput;
            set { _shouldFocusInput = value; OnPropertyChanged(); }
        }

        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set { _inputText = value; OnPropertyChanged(); }
        }

        public void FocusInput()
        {
            ShouldFocusInput = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
