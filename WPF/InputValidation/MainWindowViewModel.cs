using InputValidation.View1;
using InputValidation.View2;

namespace InputValidation
{
    public class MainWindowViewModel
    {
        public ViewModel1 ViewModel1 { get; }
        public ViewModel2 ViewModel2 { get; }

        public MainWindowViewModel()
        {
            ViewModel1 = new View1.ViewModel1();
            ViewModel2 = new ViewModel2();
        }
    }
}
