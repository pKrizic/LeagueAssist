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
    public partial class LicenseClub : Form
    {
        int licId;
        public LicenseClub(string id)
        {
            InitializeComponent();
            ClubProcessor cp = new ClubProcessor();
            SeasonProcessor sp = new SeasonProcessor();
            LicenseProcessor lp = new LicenseProcessor();
            licId = int.Parse(id);
            comboBox1.DataSource = cp.RetrieveAllClubs();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            comboBox1.SelectedValue = id;
            comboBox2.DataSource = sp.RetrieveSeasons();
            comboBox2.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";
            comboBox2.SelectedValue = id;
            comboBox3.DataSource = lp.licenseReturn();
            comboBox3.ValueMember = "Id";
            comboBox3.DisplayMember = "Type";
            comboBox3.SelectedValue = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LicenseProcessor lp = new LicenseProcessor();
            var club = (Organization)comboBox1.SelectedItem;
            var season = (Season)comboBox2.SelectedItem;
            var license = (LeagueAssist.Entities.License)comboBox3.SelectedItem;
            lp.updateClubLicense(licId, club, season, license);
            MessageBox.Show("Dobro je sve.");
        }
    }
}
