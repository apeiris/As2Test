using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace As2Test
{
   public static class utils
    {
         public static void setControl(Control c, KeyValuePair<string, string> kvp, string nodeSelector)
        {
            c.Text = kvp.Value;
            c.Enabled = kvp.Key == nodeSelector ? false : true;

        }
    }
}
