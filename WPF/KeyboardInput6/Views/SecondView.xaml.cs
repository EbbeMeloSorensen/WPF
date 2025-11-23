using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using WpfFocusFinal.ViewModels;

namespace WpfFocusFinal.Views
{
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

            if (e.Key == Key.F5)
            {
                if (App.Current.MainWindow.DataContext is ViewModels.MainWindowViewModel mw)
                    mw.CurrentViewModel = new ViewModels.FirstViewModel();

                e.Handled = true;
            }
        }
    }
}
