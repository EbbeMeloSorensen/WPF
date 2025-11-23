using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardInput4
{
    public class FirstViewModel
    {
        // Example method called from view when a key is pressed
        public string HandleKey(System.Windows.Input.Key key)
        {
            return $"FirstViewModel received {key}";
        }
    }
}
