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

namespace KeyboardInput1
{
    /// <summary>
    /// Interaction logic for SubviewView.xaml
    /// </summary>
    public partial class SubviewView : UserControl
    {
        public SubviewView()
        {
            InitializeComponent();
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"SubviewView received key: {e.Key}");
        }

        private void SubviewView_OnLoaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
        }

        private void SubviewView_OnKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show($"UserControl received key: {e.Key}");
        }
    }
}
