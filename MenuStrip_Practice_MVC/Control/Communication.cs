using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuStrip_Practice_MVC.Control
{
    public static class Communication
    {
        #region Средства коммуникации между главным окном и окном перехода на строку
        public static string[] Working_text;
        public static Int32 Cursor_position;
        public static Point MainForm_coords;
        #endregion
    }
}
