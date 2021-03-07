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
        MyLogic logic = new MyLogic();
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
        отменитьToolStripMenuItem, вырезатьToolStripMenuItem, копироватьToolStripMenuItem, вставитьToolStripMenuItem);

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveFile(textBox1, this);

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveAs(textBox1);

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Undo(textBox1);

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Cut(textBox1);

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Copy(textBox1);

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e) => logic.Paste(textBox1);

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Print();

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Exit(this);

        private void параметрыСтраницыToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.PageParams(textBox1);
    }
}
