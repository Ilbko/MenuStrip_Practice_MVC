using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace MenuStrip_Practice_MVC.Model
{
    public static class MyModel
    {
        private static string path = string.Empty;
        private static Lazy<PrintDocument> printDoc; 
        public static void OpenFile(TextBox textbox, Form1 form)
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

                path = openFileDialog.FileName;

                FileInfo fi = new FileInfo(path);
                textbox.Text = File.ReadAllText(path, Encoding.Default);
                string name = fi.Name;

                form.Text = $"{name} - Блокнот";
            }
        }

        public static void SaveFile(TextBox textbox, Form1 form)
        {
            if (path != string.Empty)
            {
                File.WriteAllText(path, textbox.Text, Encoding.Default);

                string name = string.Empty;
                for (int i = 1; i < form.Text.Length; i++)
                {
                    name += form.Text[i];
                }

                form.Text = name;
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text|*.txt"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog.FileName;
                    File.WriteAllText(path, textbox.Text, Encoding.Default);
                }

                path = saveFileDialog.FileName;

                FileInfo fi = new FileInfo(path);
                textbox.Text = File.ReadAllText(path, Encoding.Default);
                string name = fi.Name;

                form.Text = $"{name} - Блокнот";
            }
        }

        public static void SaveAs(TextBox textbox)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text|*.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;
                File.WriteAllText(path, textbox.Text, Encoding.Default);
            }
        }

        public static void Print()
        {
            PrintDialog printDialog = new PrintDialog
            {
                AllowSomePages = true,
                ShowHelp = true,
                AllowSelection = true
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                if (printDoc == null)
                    printDoc = new Lazy<PrintDocument>();

                printDoc.Value.Print();
                //PrintDocument printDoc = new PrintDocument();
                //printDoc.Print();
            }
        }

        public static void Exit(Form1 form)
        {
            form.Close();
        }

        public static void PageParams()
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog
            {
                PageSettings = new PageSettings()
            };

            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                if (printDoc == null)
                    printDoc = new Lazy<PrintDocument>();

                printDoc.Value.DefaultPageSettings = pageSetupDialog.PageSettings;
                printDoc.Value.PrinterSettings = pageSetupDialog.PrinterSettings;
            }
        }
    }
}
