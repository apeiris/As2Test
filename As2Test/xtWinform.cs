﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


static class xtWinform
{
    public static IEnumerable<Control> GetAllChildren(Control root)
    {
        var stack = new Stack<Control>();
        stack.Push(root);

        while (stack.Any())
        {
            var next = stack.Pop();
            foreach (Control child in next.Controls)
                stack.Push(child);
            yield return next;
        }
    }
}

