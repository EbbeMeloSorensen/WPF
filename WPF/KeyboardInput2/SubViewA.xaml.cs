using System;
using System.Collections.Generic;
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

namespace KeyboardInput2
{
    /// <summary>
    /// Interaction logic for SubViewA.xaml
    /// </summary>
    public partial class SubViewA : UserControl
    {
        public SubViewA()
        {
            InitializeComponent();
        }

        private void SubViewA_OnKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show($"A received {e.Key}");
        }
    }
}
