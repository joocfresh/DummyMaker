using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DummyMaker
{
    public static class ControlExtensions
    {
        public static T Invoke<T>(this Control control, Func<T> func)
        {
            if (control.InvokeRequired)
                return (T)control.Invoke(func);
            else
                return func();
        }
    }
}
