using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuStrip_Practice_MVC.Control
{
    public class MyLogic
    {
        public void NewWindow()
        {
            Form1 form = new Form1();
            form.Show();
        }

        public void TextChanged(Form1 form, TextBox textbox,
                                ToolStripMenuItem undo,
                                ToolStripMenuItem cut,
                                ToolStripMenuItem copy,
                                ToolStripMenuItem paste)
        {
            if (form.Text != "Блокнот" && form.Text[0] != '*')
            {
                string name = "*" + form.Text;
                form.Text = name;
            }

            if (textbox.Text != "")
            {
                undo.Enabled = true;
                cut.Enabled = true;
                copy.Enabled = true;
                paste.Enabled = true;
            }
            else
            {
                undo.Enabled = false;
                cut.Enabled = false;
                copy.Enabled = false;
                paste.Enabled = false;
            }
        }

        public void Undo(TextBox textbox)
        {
            textbox.Undo();
        }

        public void Cut(TextBox textbox)
        {
            textbox.Cut();
        }

        public void Copy(TextBox textbox)
        {
            textbox.Copy();
        }

        public void Paste(TextBox textbox)
        {
            textbox.Paste();
        }
    }
}
