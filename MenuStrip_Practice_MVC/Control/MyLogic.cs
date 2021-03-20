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
    //Класс логики
    public class MyLogic
    {
        //Метод создания нового окна
        public void NewWindow()
        {
            Form1 form = new Form1();
            form.Show();
        }

        //Метод изменения текста, вызываемый событием изменения текста
        public void TextChanged(Form1 form, TextBox textbox,
                                ToolStripMenuItem undo,
                                ToolStripMenuItem cut,
                                ToolStripMenuItem copy,
                                ToolStripMenuItem paste,
                                ToolStripMenuItem delete,
                                ToolStripMenuItem Find,
                                ToolStripMenuItem FindEarlier,
                                ToolStripMenuItem FindFurther)
        {
            //Обновление текста в классе коммуникации
            Communication.Working_text = textbox.Lines;

            //Если окно не показывает изменения в имени
            if (form.Text != "Блокнот" && form.Text[0] != '*')
            {
                string name = "*" + form.Text;
                form.Text = name;
            }

            //Если текст присутствует, то возможно взаимодействие с частью функционала
            if (textbox.Text != "")
            {
                undo.Enabled = true;
                cut.Enabled = true;
                copy.Enabled = true;
                paste.Enabled = true;
                delete.Enabled = true;
                Find.Enabled = true;
                FindEarlier.Enabled = true;
                FindFurther.Enabled = true;
            }
            else
            {
                undo.Enabled = false;
                cut.Enabled = false;
                copy.Enabled = false;
                paste.Enabled = false;
                delete.Enabled = false;
                Find.Enabled = false;
                FindEarlier.Enabled = false;
                FindFurther.Enabled = false;
            }
        }

        //Метод отмены изменений текста
        public void Undo(TextBox textbox) => textbox.Undo();

        //Метод вырезки текста
        public void Cut(TextBox textbox) => textbox.Cut();

        //Метод копирования текста
        public void Copy(TextBox textbox) => textbox.Copy();

        //Метод вставки текста
        public void Paste(TextBox textbox) => textbox.Paste();

        //Метод удаления текста
        public void Delete(TextBox textbox) => textbox.Paste(string.Empty);

        //Метод наведения мышки на текстбокс, вызываемый этим событием
        public void TextBoxMouse(TextBox textbox, ToolStripMenuItem bingSearch)
        {
            //Если был выделен текст, то можно найти его в Бинге
            if (textbox.SelectionLength > 0)
            {
                bingSearch.Enabled = true;
            }
            else
            {
                bingSearch.Enabled = false;
            }
            //Изменение позиции курсора в классе коммуникации 
            Communication.Cursor_position = textbox.SelectionStart;
        }

        //Метод поиска в Бинге
        public void BingSearch(TextBox textbox) => System.Diagnostics.Process.Start($"https://www.bing.com/search?q=" + textbox.SelectedText);

        //Метод переноса по словам
        public void WordWrap(TextBox textbox, ToolStripMenuItem goTo, ToolStripMenuItem wordWrap)
        {
            //Если перенос по словам был выключен (запутанно)
            if (wordWrap.Checked == true)
            {
                //Устанавливается картинка (а именно устанавливается режим показа "картинка и текст", картинка всегда была установлена)
                //wordWrap.Image = global::MenuStrip_Practice_MVC.Properties.Resources.checked_icon;
                wordWrap.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                //Возможен переход к строке
                goTo.Enabled = true;
                //Перенос по словам у текстбокса выключается
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

        //Метод перехода к строке (создание нового окна)
        public void MoveTo(TextBox textbox)
        {
            /*FormMoveTo moveTo = new FormMoveTo();
            moveTo.Show();*/

            //Communication.Working_text = textbox.Lines;
            new FormMoveTo().ShowDialog(); 
        }

        //Метод изменения шрифта 
        public void FontSelection(TextBox textbox)
        {
            //Создание нового диалога, где можно выбирать текст и куда применяются текущие цвет букв и шрифт
            FontDialog fontDialog = new FontDialog
            {
                ShowColor = true,

                Color = textbox.ForeColor,
                Font = textbox.Font
            };

            //Если была нажата кнопка "ок", то устанавливается шрифт и цвет букв
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textbox.Font = fontDialog.Font;
                textbox.ForeColor = fontDialog.Color;
            }
        }

        //Метод вставки текущего времени и даты
        public void TimeAndData(TextBox textbox)
        {
            string newText = textbox.Text.Insert(textbox.SelectionStart, DateTime.Now.ToString());
            textbox.Text = newText;
        }

        //Метод выделения всего текста
        public void SelectAll(TextBox textbox) => textbox.SelectAll();

        //Метод поиска по тексту (создание нового окна)
        public void Find(Form1 form, int mode)
        {
            //Чтобы проверить, открыто ли окно поиска на данный момент, создаётся коллекция текущих (открытых) форм
            FormCollection fc = Application.OpenForms;

            bool foundOpen = false;

            //Поиск открытой формы поиска
            foreach (Form item in fc)
            {
                if (item.Name == "FormFind")
                    foundOpen = true;
            }

            /*В меню "Правка" есть три кнопки: "Найти", "Найти далее" и "Найти ранее". Если в окне поиска не был ранее введён текст, то все кнопки
              будут вызывать окно поиска. Если в окне поиска был введён текст перед закрытием, то последние две кнопки произведут поиск вниз или вверх 
              соответственно по тексту без вызова окна. Переменная "mode" нужна для корректной работы этого функционала*/
            if (mode == 0)
            { 
                if (!foundOpen)
                    new FormFind(form).Show();
                //Если форма уже открыта, то на неё переходит фокус
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
            else if (!foundOpen)
            {
                new FormFind(form).Show();
            }
            else
            {
                fc["FormFind"].Focus();
            }
        }

        //Метод замены текста (создание нового окна)
        public void Replace (System.Drawing.Point location, Form1 form)
        {
            //Обновление позиции главного окна в классе коммуникации
            Communication.MainForm_coords = location;
            new FormReplace(form).Show();
        }
    }
}
