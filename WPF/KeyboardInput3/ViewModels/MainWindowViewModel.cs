namespace KeyboardInput3.ViewModels
{
    public class MainWindowViewModel
    {
        public SubviewViewModel SubviewVM { get; }

        public MainWindowViewModel()
        {
            SubviewVM = new SubviewViewModel();

            // Automatically focus the TextBox at startup
            SubviewVM.FocusInput();
        }
    }
}
