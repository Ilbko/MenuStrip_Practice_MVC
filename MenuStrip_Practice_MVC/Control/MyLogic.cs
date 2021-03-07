using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
                                ToolStripMenuItem paste,
                                ToolStripMenuItem delete,
                                ToolStripMenuItem find,
                                ToolStripMenuItem findEarlier,
                                ToolStripMenuItem findFurther)
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
                delete.Enabled = true;
                find.Enabled = true;
                findEarlier.Enabled = true;
                findFurther.Enabled = true;
            }
            else
            {
                undo.Enabled = false;
                cut.Enabled = false;
                copy.Enabled = false;
                paste.Enabled = false;
                delete.Enabled = false;
                find.Enabled = false;
                findEarlier.Enabled = false;
                findFurther.Enabled = false;
            }
        }

        public void Undo(TextBox textbox) => textbox.Undo();

        public void Cut(TextBox textbox) => textbox.Cut();

        public void Copy(TextBox textbox) => textbox.Copy();

        public void Paste(TextBox textbox) => textbox.Paste();

        public void Delete(TextBox textbox) => textbox.Paste(string.Empty);

        public void TextBoxMouse(TextBox textbox, ToolStripMenuItem bingSearch)
        {
            if (textbox.SelectionLength > 0)
            {
                bingSearch.Enabled = true;
            }
            else
            {
                bingSearch.Enabled = false;
            }
        }

        public void BingSearch(TextBox textbox) => System.Diagnostics.Process.Start($"https://www.bing.com/search?q=" + textbox.SelectedText);

        public void WordWrap(TextBox textbox, ToolStripMenuItem goTo, ToolStripMenuItem wordWrap)
        {
            if (wordWrap.Checked == true)
            {
                //wordWrap.Image = global::MenuStrip_Practice_MVC.Properties.Resources.checked_icon;
                wordWrap.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                goTo.Enabled = true;
                textbox.WordWrap = false;

                wordWrap.Checked = false;
            }
            else if (wordWrap.Checked == false)
            {
                //wordWrap.Image = null;
                wordWrap.DisplayStyle = ToolStripItemDisplayStyle.Text;
                goTo.Enabled = false;
                textbox.WordWrap = true;

                wordWrap.Checked = true;
            }
        }
        
    }
}
