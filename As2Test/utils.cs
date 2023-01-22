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

        public static string elementAxisOfXpath(String xpathWithAttribute)
        {
            string[] strings = xpathWithAttribute.Split("/@",StringSplitOptions.RemoveEmptyEntries);
            string s = "";
        for(int i=0;i < strings.Length -1;i++)
            {
                s += strings[i];
                s+=i < strings.Length-2 ? "@":"";
            }
           return s.TrimEnd('/');
        }
    }
}
