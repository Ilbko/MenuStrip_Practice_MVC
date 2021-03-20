using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuStrip_Practice_MVC.Control;
using System.Windows.Forms;

namespace MenuStrip_Practice_MVC.Model
{
    public static class Command
    {
        internal static void Command_FindForm(TextBox textbox, System.Drawing.Point location, Form1 form, int mode)
        {
            Communication.MainForm_coords = location;
            //Communication.Cursor_position = textbox.SelectionStart;
            //Communication.Working_text = textbox.Lines;
            MyLogic logic = new MyLogic();
            logic.Find(form, mode);
        }
    }
}
