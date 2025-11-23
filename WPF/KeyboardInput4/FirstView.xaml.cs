using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeyboardInput4
{
    /// <summary>
    /// Interaction logic for FirstView.xaml
    /// </summary>
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

            // Example: navigate with F5 to second view (communicate via MainWindow VM)
            if (e.Key == Key.F5)
            {
                if (App.Current.MainWindow.DataContext is MainWindowViewModel mw)
                    mw.CurrentViewModel = new SecondViewModel();

                e.Handled = true;
            }
        }
    }
}
