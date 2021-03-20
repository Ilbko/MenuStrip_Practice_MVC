using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuStrip_Practice_MVC.Control;
using System.Windows.Forms;

namespace MenuStrip_Practice_MVC.Model
{
    //Класс команды
    public static class Command
    {
        internal static void Command_FindForm(System.Drawing.Point location, Form1 form, int mode)
        {
            //Обновление локации главного окна в классе коммуникации
            Communication.MainForm_coords = location;
            //Communication.Cursor_position = textbox.SelectionStart;
            //Communication.Working_text = textbox.Lines;
            MyLogic logic = new MyLogic();
            logic.Find(form, mode);
        }
    }
}
