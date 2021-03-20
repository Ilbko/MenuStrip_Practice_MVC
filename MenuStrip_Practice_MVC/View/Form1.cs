using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MenuStrip_Practice_MVC.Control;
using MenuStrip_Practice_MVC.Model;

namespace MenuStrip_Practice_MVC
{
    public partial class Form1 : Form
    {
        readonly MyLogic logic = new MyLogic();
        public Form1()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip1;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e) => this.Text = "Безымянный - Блокнот";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void новоеОкноToolStripMenuItem_Click(object sender, EventArgs e) => logic.NewWindow();
         //new Form1().Show();
        
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.OpenFile(textBox1, this);

        private void textBox1_TextChanged(object sender, EventArgs e) => logic.TextChanged(this, (sender as TextBox),
        отменитьToolStripMenuItem, вырезатьToolStripMenuItem, копироватьToolStripMenuItem, вставитьToolStripMenuItem,
        удалитьToolStripMenuItem, найтиToolStripMenuItem, найтиДалееToolStripMenuItem, найтиРанееToolStripMenuItem);

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveFile(textBox1, this);

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveAs(textBox1);

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Undo(textBox1);

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Cut(textBox1);

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Copy(textBox1);

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Paste(textBox1);

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Print();

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Exit(this);

        private void параметрыСтраницыToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.PageParams();

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Delete(textBox1);

        private void textBox1_MouseMove(object sender, MouseEventArgs e) => logic.TextBoxMouse(textBox1, поискСПомощьюBingToolStripMenuItem);

        private void поискСПомощьюBingToolStripMenuItem_Click(object sender, EventArgs e) => logic.BingSearch(textBox1);

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e) => logic.WordWrap(textBox1, перейтиToolStripMenuItem, переносПоСловамToolStripMenuItem);

        private void перейтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communication.MainForm_coords = this.Location;
            logic.MoveTo(textBox1);
            textBox1.SelectionStart = Convert.ToInt32(Communication.Cursor_position);
            Communication.Cursor_position = 0;
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e) => logic.SelectAll(textBox1);

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e) => logic.TimeAndData(textBox1);

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e) => logic.FontSelection(textBox1);

        private void найтиToolStripMenuItem_Click(object sender, EventArgs e) => Command.Command_FindForm(textBox1, this.Location, this, 0);

        private void найтиДалееToolStripMenuItem_Click(object sender, EventArgs e) => Command.Command_FindForm(textBox1, this.Location, this, 1);

        private void найтиРанееToolStripMenuItem_Click(object sender, EventArgs e) => Command.Command_FindForm(textBox1, this.Location, this, 2);

        //internal void TextBoxRedirection() => logic.TextSelection(textBox1, Communication.Cursor_position, Communication.Selection_length);
    }
}
