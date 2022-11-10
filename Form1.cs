using System;
using System.Windows.Forms;

namespace Test_Svel
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox_search.Focus();
            
        }

        Solver solver = new Solver();

        public TextBox textBoxSearch { get { return textBox_search; } }
        public ListBox listBox { get { return listBox1; } }
        public OpenFileDialog fileDialog { get { return openFileDialog1; } }
        

        private void созданиеСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solver.CreateDict(this);
        }

        private void обновлениеСловаряToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solver.UpdateDict(this);
        }

        private void очиститьСловарьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solver.DeleteDict(this);
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            solver.Search(this);
            solver.DelSpace(this);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            solver.ListBoxChange(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
    }
}
