using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueAssistDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fl = new Form1();
            fl.FormClosed += new FormClosedEventHandler(Form1_FormClosing);
            fl.Show();
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void generatorKolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneratorKola generatorForm = new GeneratorKola();
            generatorForm.MdiParent = this;
            generatorForm.Dock = DockStyle.Fill;
            generatorForm.Show();
        }

        private void pregledKolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PregledIDetaljnoDefiniranjeKola pregledKolaForm = new PregledIDetaljnoDefiniranjeKola();
            pregledKolaForm.MdiParent = this;
            pregledKolaForm.Dock = DockStyle.Fill;
            pregledKolaForm.Show();
        }

        private void natjecanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pregledNatjecanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PregledNatjecanja pregledKolaForm = new PregledNatjecanja();
            pregledKolaForm.MdiParent = this;
            pregledKolaForm.Dock = DockStyle.Fill;
            pregledKolaForm.Show();
        }
    }
}
