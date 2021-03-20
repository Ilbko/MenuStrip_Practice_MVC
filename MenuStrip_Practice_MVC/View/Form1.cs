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

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e) => this.Text = "Безымянный - Блокнот";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NewWindowToolStripMenuItem_Click(object sender, EventArgs e) => logic.NewWindow();
         //new Form1().Show();
        
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.OpenFile(textBox1, this);

        private void textBox1_TextChanged(object sender, EventArgs e) => logic.TextChanged(this, (sender as TextBox),
        UndoToolStripMenuItem, CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem,
        DeleteToolStripMenuItem, FindToolStripMenuItem, FindFurtherToolStripMenuItem, FindEarlierToolStripMenuItem);

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveFile(textBox1, this);

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveAs(textBox1);

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e) => logic.Undo(textBox1);

        private void CutToolStripMenuItem_Click(object sender, EventArgs e) => logic.Cut(textBox1);

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) => logic.Copy(textBox1);

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) => logic.Paste(textBox1);

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Print();

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Exit(this);

        private void PageParametersToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.PageParams();

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e) => logic.Delete(textBox1);

        private void textBox1_MouseMove(object sender, MouseEventArgs e) => logic.TextBoxMouse(textBox1, SearchWithBingToolStripMenuItem);

        private void SearchWithBingToolStripMenuItem_Click(object sender, EventArgs e) => logic.BingSearch(textBox1);

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e) => logic.WordWrap(textBox1, GoToToolStripMenuItem, WordWrapToolStripMenuItem);

        private void GoToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Communication.MainForm_coords = this.Location;
            logic.MoveTo(textBox1);
            textBox1.SelectionStart = Convert.ToInt32(Communication.Cursor_position);
            Communication.Cursor_position = 0;
        }

        private void SelectВсеToolStripMenuItem_Click(object sender, EventArgs e) => logic.SelectAll(textBox1);

        private void TimeAndDataToolStripMenuItem_Click(object sender, EventArgs e) => logic.TimeAndData(textBox1);

        private void FontToolStripMenuItem_Click(object sender, EventArgs e) => logic.FontSelection(textBox1);

        private void FindToolStripMenuItem_Click(object sender, EventArgs e) => Command.Command_FindForm(this.Location, this, 0);

        private void FindFurtherToolStripMenuItem_Click(object sender, EventArgs e) => Command.Command_FindForm(this.Location, this, 1);

        private void FindEarlierToolStripMenuItem_Click(object sender, EventArgs e) => Command.Command_FindForm(this.Location, this, 2);

        private void ReplaceToolStripMenuItem_Click(object sender, EventArgs e) => logic.Replace(this.Location, this);

        //internal void TextBoxRedirection() => logic.TextSelection(textBox1, Communication.Cursor_position, Communication.Selection_length);
    }
}
