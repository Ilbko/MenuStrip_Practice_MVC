using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MenuStrip_Practice_MVC.Model
{
    public static class MyModel
    {
        public static void OpenFile(ref string path, TextBox textbox, Form1 form)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                /*path = openFileDialog.FileName;
                textbox.Text = File.ReadAllText(path);
                string name = string.Empty;

                for (int i = path.Length - 1; i > 0; i--)
                {
                    if (path[i] == '\\')
                    {
                        break;
                    }
                    else
                    {
                        name += path[i];
                    }
                }

                char[] arr = name.ToCharArray();
                Array.Reverse(arr);
                name = new string(arr); */

                FileInfo fi = new FileInfo(path);
                textbox.Text = File.ReadAllText(path);
                string name = fi.Name;

                form.Text = $"{name} - Блокнот";
            }
        }

        public static void SaveFile(ref string path, TextBox textbox, Form1 form)
        {
            if (path != string.Empty)
            {
                File.WriteAllText(path, textbox.Text);

                string name = string.Empty;
                for (int i = 1; i < form.Text.Length; i++)
                {
                    name += form.Text[i];
                }

                form.Text = name;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text|*.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    File.WriteAllText(path, textbox.Text);
                }

                path = saveFileDialog.FileName;
                //textBox1.Text = File.ReadAllText(path);

                /*for (int i = path.Length - 1; i > 0; i--)
                {
                    if (path[i] == '\\')
                    {
                        break;
                    }
                    else
                    {
                        name += path[i];
                    }
                }

                char[] arr = name.ToCharArray();
                Array.Reverse(arr);
                name = new string(arr);*/

                FileInfo fi = new FileInfo(path);
                textbox.Text = File.ReadAllText(path);
                string name = fi.Name;

                form.Text = $"{name} - Блокнот";
            }
        }

        public static void SaveAs(ref string path, TextBox textbox)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                File.WriteAllText(path, textbox.Text);
            }
        }
    }
}
