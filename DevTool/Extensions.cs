using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTool
{

    public static class Extensions
    {
        public static void AppendNewText(this System.Windows.Controls.TextBox tb, string data)
        {
            tb.Text = tb.Text + "\n" + data;
        }
    }
}
