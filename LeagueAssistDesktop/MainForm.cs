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
            PregledNatjecanja pregledNatjecanjaForm = new PregledNatjecanja();
            pregledNatjecanjaForm.MdiParent = this;
            pregledNatjecanjaForm.Dock = DockStyle.Fill;
            pregledNatjecanjaForm.Show();
        }

        private void kreirajNatjecanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StvoriNatjecanje stvoriNatjecanjeForm = new StvoriNatjecanje();
            stvoriNatjecanjeForm.MdiParent = this;
            stvoriNatjecanjeForm.Dock = DockStyle.Fill;
            stvoriNatjecanjeForm.Show();
        }

        private void stvoriNovoNatjecanjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StvoriNovoNatjecanje stvoriNovoNatjecanjeForm = new StvoriNovoNatjecanje();
            stvoriNovoNatjecanjeForm.MdiParent = this;
            stvoriNovoNatjecanjeForm.Dock = DockStyle.Fill;
            stvoriNovoNatjecanjeForm.Show();
        }

        private void pregledKlubovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PregledKlubova pregledKlubovaForm= new PregledKlubova();
            pregledKlubovaForm.MdiParent = this;
            pregledKlubovaForm.Dock = DockStyle.Fill;
            pregledKlubovaForm.Show();
        }

        private void dodajKlubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosKluba unosKlubovaForm = new UnosKluba();
            unosKlubovaForm.MdiParent = this;
            unosKlubovaForm.Dock = DockStyle.Fill;
            unosKlubovaForm.Show();
        }


        private void stadioniToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unosStadionaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosStadiona unosStadionaForm = new UnosStadiona();
            unosStadionaForm.MdiParent = this;
            unosStadionaForm.Dock = DockStyle.Fill;
            unosStadionaForm.Show();
        }

        private void koloToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unosSudcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosSudca unosSudcaForm = new UnosSudca();
            unosSudcaForm.MdiParent = this;
            unosSudcaForm.Dock = DockStyle.Fill;
            unosSudcaForm.Show();
        }

        private void podaciToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prikazSudacaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PopisSudacaILicenci popisSudacaILicenciForm = new PopisSudacaILicenci();
            popisSudacaILicenciForm.MdiParent = this;
            popisSudacaILicenciForm.Dock = DockStyle.Fill;
            popisSudacaILicenciForm.Show();
        }

        private void prikazSvihLicenciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrikazSvihLicenci prikazSvihLicenciForm = new PrikazSvihLicenci();
            prikazSvihLicenciForm.MdiParent = this;
            prikazSvihLicenciForm.Dock = DockStyle.Fill;
            prikazSvihLicenciForm.Show();
        }

        private void urediKlubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UrediKlub urediKlubForm = new UrediKlub();
            urediKlubForm.MdiParent = this;
            urediKlubForm.Dock = DockStyle.Fill;
            urediKlubForm.Show();
        }

        private void klubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnosLicencaKlub licencaKlub = new UnosLicencaKlub();
            licencaKlub.MdiParent = this;
            licencaKlub.Dock = DockStyle.Fill;
            licencaKlub.Show();
        }
    }
}

