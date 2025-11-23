using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace KeyboardInput4
{
    /// <summary>
    /// Interaction logic for SecondView.xaml
    /// </summary>
    public partial class SecondView : UserControl
    {
        public SecondView()
        {
            InitializeComponent();
            this.PreviewKeyDown += SecondView_PreviewKeyDown;
        }

        private void SecondView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is SecondViewModel vm)
            {
                var msg = vm.HandleKey(e.Key);
                Debug.WriteLine(msg);
            }

            // Example: navigate with F5 back to first view
            if (e.Key == Key.F5)
            {
                if (App.Current.MainWindow.DataContext is MainWindowViewModel mw)
                    mw.CurrentViewModel = new FirstViewModel();

                e.Handled = true;
            }
        }
    }
}
