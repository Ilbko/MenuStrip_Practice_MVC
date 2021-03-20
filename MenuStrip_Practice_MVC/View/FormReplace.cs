using MenuStrip_Practice_MVC.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuStrip_Practice_MVC.View
{
    public static class StringExtension
    {
        public static string ReplaceAtWith(this string str, int startIndex, int length, string value)
        {
            StringBuilder stringBuilder = new StringBuilder(str);
            stringBuilder.Remove(startIndex, length);
            stringBuilder.Insert(startIndex, value);
            str = stringBuilder.ToString();

            return str;
        }
    }
    public partial class FormReplace : Form
    {
        public Form1 MainForm { get; set; }
        public FormReplace()
        {
            InitializeComponent();
        }

        public FormReplace(Form1 form)
        {
            InitializeComponent();
            this.MainForm = form;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void SearchDown()
        {
            string allText = string.Join("\r\n", Communication.Working_text);

            string searchText = textBox1.Text;
            if (!checkBox1.Checked)
            {
                allText = allText.ToLower();
                searchText = searchText.ToLower();
            }

            string selectionText = string.Empty;
            if (Communication.Cursor_position < allText.Length)
            {
                selectionText = allText.Substring(Communication.Cursor_position);
            }

            bool check = true;

            if (selectionText.Contains(searchText))
            {
                for (int i = Communication.Cursor_position; i < allText.Length; i++)
                {
                    if (allText[i] == searchText[0])
                    {
                        for (int j = 0; j < searchText.Length; j++)
                        {
                            if (allText[i + j] != searchText[j])
                            {
                                check = false;
                                break;
                            }
                            check = true;
                        }

                        if (check == true)
                        {
                            Communication.Cursor_position = i;
                            Communication.Selection_length = searchText.Length;

                            TextBox parentTextbox = this.MainForm.Controls["textBox1"] as TextBox;
                            parentTextbox.SelectionStart = Communication.Cursor_position;
                            parentTextbox.SelectionLength = Communication.Selection_length;

                            MainForm.Focus();

                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"Не удаётся найти \"{searchText}\"", "Блокнот", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchDown();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
            {
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((MainForm.Controls["textBox1"] as TextBox).SelectionLength == 0)
                SearchDown();
            else
            {
                string allText = string.Join("\r\n", Communication.Working_text);

                //StringBuilder stringBuilder = new StringBuilder(allText);
                //stringBuilder.Remove(Communication.Cursor_position, Communication.Selection_length);
                //stringBuilder.Insert(Communication.Cursor_position, textBox2.Text);
                //allText = stringBuilder.ToString();
                //(MainForm.Controls["textBox1"] as TextBox).Text = allText;
                (MainForm.Controls["textBox1"] as TextBox).Text = allText.ReplaceAtWith(Communication.Cursor_position,
                    Communication.Selection_length, textBox2.Text);

                SearchDown();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string allText = string.Join("\r\n", Communication.Working_text);
            allText = allText.Replace(textBox1.Text, textBox2.Text);
            (MainForm.Controls["textBox1"]).Text = allText;
        }

        private void FormReplace_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Communication.MainForm_coords.X + 10, Communication.MainForm_coords.Y + 50);
        }
    }
}
