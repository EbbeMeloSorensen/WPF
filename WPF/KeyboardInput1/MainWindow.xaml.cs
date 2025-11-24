using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyboardInput1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SubviewViewModel Subview { get; } = new SubviewViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // IMPORTANT: move focus to content on startup
            Loaded += (_, __) => Keyboard.Focus((UIElement)Content);
        }
    }
}