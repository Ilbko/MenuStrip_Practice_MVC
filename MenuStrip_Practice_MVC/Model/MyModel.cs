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
    //Класс модели
    public static class MyModel
    {
        //Путь и ленивый принтДокумент (печать)
        private static string path = string.Empty;
        private static Lazy<PrintDocument> printDoc;

        //Открытие файла
        public static void OpenFile(TextBox textbox, Form1 form)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            //Если файл был открыт, то копируется его текст и устанавливается его имя на главное окно
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

        //Сохранение файла
        public static void SaveFile(TextBox textbox, Form1 form)
        {
            //Если путь не пустой
            if (path != string.Empty)
            {
                //Запись текста и изменение имени главного окна
                File.WriteAllText(path, textbox.Text, Encoding.Default);

                string name = string.Empty;
                for (int i = 1; i < form.Text.Length; i++)
                {
                    name += form.Text[i];
                }

                form.Text = name;
            }
            //Если путь пустой, то вызывается диалог сохранения
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

                    path = saveFileDialog.FileName;

                    FileInfo fi = new FileInfo(path);
                    textbox.Text = File.ReadAllText(path, Encoding.Default);
                    string name = fi.Name;

                    form.Text = $"{name} - Блокнот";
                }
            }
        }

        //Сохранить как
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

        //Печать
        public static void Print()
        {
            //Создание диалога печати с дополнительными настройками (разрешениями)
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

        //Выход
        public static void Exit(Form1 form)
        {
            form.Close();
        }

        //Параметры страницы (для печати)
        public static void PageParams()
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog
            {
                PageSettings = new PageSettings()
            };

            //Установка настройки печати
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
