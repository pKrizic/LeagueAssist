using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeagueAssist;
using LeagueAssist.Entities;

namespace LeagueAssistDesktop
{
    public partial class UnosLicencaKlub : Form
    {
        public UnosLicencaKlub()
        {
            InitializeComponent();
            ClubProcessor cp = new ClubProcessor();
            comboBox1.DataSource = cp.RetrieveAllClubs();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            SeasonProcessor sp = new SeasonProcessor();
            comboBox2.DataSource = sp.RetrieveSeasons(DateTime.Now);
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";
            LicenseProcessor lp = new LicenseProcessor();
            comboBox3.DataSource = lp.licenseReturn();
            comboBox3.ValueMember = "Id";
            comboBox3.DisplayMember = "Type";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var club = (Organization)comboBox1.SelectedItem;
            var season = (Season)comboBox2.SelectedItem;
            var license = (LeagueAssist.Entities.License)comboBox3.SelectedItem;
            if (!string.IsNullOrEmpty(comboBox1.Text) || !string.IsNullOrEmpty(comboBox2.Text) || !string.IsNullOrEmpty(comboBox3.Text))
            {
                LicenseProcessor lp = new LicenseProcessor();
                lp.startLicenseStore(club, season, license);
                MessageBox.Show("Uspjesno uneseni podaci");
            }
            else
                MessageBox.Show("Krivo uneseni podaci");
        }
    }
}
