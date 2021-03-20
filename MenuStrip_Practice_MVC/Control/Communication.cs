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
        public static Point MainForm_coords;

        #region Средства коммуникации между главным окном и окном перехода на строку
        #endregion

        //Эти две переменных используются и для того, и для другого.
        public static string[] Working_text;
        public static Int32 Cursor_position;

        #region Средства коммуникации между главным окном и окном поиска
        public static Int32 Selection_length;
        public static string Search_string = string.Empty;
        #endregion
    }
}
