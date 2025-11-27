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
    /// Interaction logic for SubViewB.xaml
    /// </summary>
    public partial class SubViewB : UserControl
    {
        public SubViewB()
        {
            InitializeComponent();
        }

        private void SubViewB_OnKeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show($"B received {e.Key}");
        }
    }
}
