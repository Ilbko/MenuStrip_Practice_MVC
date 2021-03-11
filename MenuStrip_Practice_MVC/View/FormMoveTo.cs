using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MenuStrip_Practice_MVC.Control;

namespace MenuStrip_Practice_MVC
{
    public partial class FormMoveTo : Form
    {
        public FormMoveTo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //В этом случае событие закрытия формы не сработает. (его и нет)
            this.Dispose();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                toolTip1.ToolTipTitle = "Недопустимый символ";
                toolTip1.IsBalloon = true;
                toolTip1.ToolTipIcon = ToolTipIcon.Error;
                toolTip1.UseAnimation = true;

                toolTip1.Show("Здесь можно ввести только число.", (textBox1));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(textBox1.Text) > Communication.Working_text.Length || Convert.ToInt32(textBox1.Text) == 0)
            {
                MessageBox.Show("Номер строки превышает общее количество строк.", "Блокнот - переход на строку", MessageBoxButtons.OK);
            }
            else
            {
                //Communication.Cursor_position = Convert.ToInt32(textBox1.Text) - 1;
                for (int i = 0; i < Convert.ToInt32(textBox1.Text) - 1; i++)
                {
                    // + 2 - учёт эскейп-последовательности перехода на новую строку.
                    Communication.Cursor_position += Communication.Working_text[i].Length + 2;
                }
                this.Dispose();
            }
        }

        private void FormMoveTo_Load(object sender, System.EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Communication.MainForm_coords.X + 10, Communication.MainForm_coords.Y + 50);
        }
    }
}
