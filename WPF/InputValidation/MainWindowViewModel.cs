using InputValidation.View1;
using InputValidation.View2;
using InputValidation.View3;
using InputValidation.View4;
using InputValidation.View5;

namespace InputValidation
{
    public class MainWindowViewModel
    {
        public ViewModel1 ViewModel1 { get; }
        public ViewModel2 ViewModel2 { get; }
        public ViewModel3 ViewModel3 { get; }
        public ViewModel4 ViewModel4 { get; }
        public ViewModel5 ViewModel5 { get; }

        public MainWindowViewModel()
        {
            ViewModel1 = new ViewModel1();
            ViewModel2 = new ViewModel2();
            ViewModel3 = new ViewModel3();
            ViewModel4 = new ViewModel4();
            ViewModel5 = new ViewModel5();
        }
    }
}
