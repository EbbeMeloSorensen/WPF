using System.Windows;
using WpfFocusFinal.ViewModels;

namespace WpfFocusFinal
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
