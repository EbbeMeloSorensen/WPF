using System.Windows.Controls;
using System.Windows.Input;
using System.Diagnostics;
using WpfFocusFinal.ViewModels;

namespace WpfFocusFinal.Views
{
    public partial class FirstView : UserControl
    {
        public FirstView()
        {
            InitializeComponent();
            this.PreviewKeyDown += FirstView_PreviewKeyDown;
        }

        private void FirstView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is FirstViewModel vm)
            {
                var msg = vm.HandleKey(e.Key);
                Debug.WriteLine(msg);
            }

            if (e.Key == Key.F5)
            {
                if (App.Current.MainWindow.DataContext is ViewModels.MainWindowViewModel mw)
                    mw.CurrentViewModel = new ViewModels.SecondViewModel();

                e.Handled = true;
            }
        }
    }
}
