using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardInput4
{
    public class SecondViewModel
    {
        public string HandleKey(System.Windows.Input.Key key)
        {
            return $"SecondViewModel received {key}";
        }
    }
}
