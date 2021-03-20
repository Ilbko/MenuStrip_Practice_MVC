using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MenuStrip_Practice_MVC.View;

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
            Communication.Working_text = textbox.Lines;

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
            Communication.Cursor_position = textbox.SelectionStart;
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
        
        public void MoveTo(TextBox textbox)
        {
            /*FormMoveTo moveTo = new FormMoveTo();
            moveTo.Show();*/

            Communication.Working_text = textbox.Lines;
            new FormMoveTo().ShowDialog(); 
        }

        public void FontSelection(TextBox textbox)
        {
            FontDialog fontDialog = new FontDialog
            {
                ShowColor = true,

                Color = textbox.ForeColor,
                Font = textbox.Font
            };

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textbox.Font = fontDialog.Font;
                textbox.ForeColor = fontDialog.Color;
            }
        }

        public void TimeAndData(TextBox textbox)
        {
            string newText = textbox.Text.Insert(textbox.SelectionStart, DateTime.Now.ToString());
            textbox.Text = newText;
        }

        public void SelectAll(TextBox textbox)
        {
            textbox.SelectAll();
        }

        public void Find(Form1 form, int mode)
        {
            FormCollection fc = Application.OpenForms;

            bool foundOpen = false;

            foreach(Form item in fc)
            {
                if (item.Name == "FormFind")
                    foundOpen = true;
            }

            if (mode == 0)
            {
                if (!foundOpen)
                    new FormFind(form).Show();
                else
                    fc["FormFind"].Focus();
            }
            else if (mode == 1 && Communication.Search_string != string.Empty)
            {
                //new FormFind(form).SearchDown();
                FormFind formFind = new FormFind(form);
                formFind.SearchDown();
                GC.Collect(GC.GetGeneration(formFind));
            }
            else if (mode == 2 && Communication.Search_string != string.Empty)
            {
                //new FormFind(form).SearchUp();
                FormFind formFind = new FormFind(form);
                formFind.SearchUp();
                GC.Collect(GC.GetGeneration(formFind));
            }
            else
            {
                new FormFind(form).Show();
            }
        }

        public void Replace (System.Drawing.Point location, Form1 form)
        {
            Communication.MainForm_coords = location;
            new FormReplace(form).Show();
        }
    }
}
