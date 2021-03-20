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
using MenuStrip_Practice_MVC;

namespace MenuStrip_Practice_MVC.View
{
    public partial class FormFind : Form
    {
        public Form1 MainForm { get; set; }
        public FormFind()
        {
            InitializeComponent();
        }

        public FormFind(Form1 form)
        {
            InitializeComponent();
            this.MainForm = form;
        }

        private void FormFind_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Communication.MainForm_coords.X + 10, Communication.MainForm_coords.Y + 50);
            if (Communication.Search_string != string.Empty)
                textBox1.Text = Communication.Search_string;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((sender as TextBox).Text.Length > 0)
                button1.Enabled = true;
            else
                button1.Enabled = false;

            Communication.Search_string = (sender as TextBox).Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void SearchDown()
        {
            //Я потратил сутки, пытаясь исправить ошибку выделения, как вдруг узнал, что текстбокс вместо \n использует \r\n
            string allText = string.Join("\r\n", Communication.Working_text);

            string searchText = Communication.Search_string;
            string selectionText = string.Empty;
            if (Communication.Cursor_position < allText.Length)
            {
                selectionText = allText.Substring(Communication.Cursor_position);
            }

            //bool check = default(bool); //false
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

                            //TextBox parentTextbox = this.Parent.Controls["textBox1"] as TextBox;
                            TextBox parentTextbox = this.MainForm.Controls["textBox1"] as TextBox;
                            parentTextbox.SelectionStart = Communication.Cursor_position;
                            parentTextbox.SelectionLength = Communication.Selection_length;

                            MainForm.Focus();
                            //this.Activate();
                            //MainForm.ActiveControl = MainForm.Controls["textBox1"];

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

        public void SearchUp()
        {
            string allText = string.Join("\r\n", Communication.Working_text);

            string searchText = Communication.Search_string;
            string selectionText = allText.Substring(0, Communication.Cursor_position);

            bool check = true;

            if (selectionText.Contains(searchText))
            {
                for (int i = Communication.Cursor_position - 1; i >= 0; i--)
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
            if (radioButton2.Checked == true)
            {
                SearchDown();
            }
            else if (radioButton1.Checked == true)
            {
                SearchUp();
            }
        }
    }
}
