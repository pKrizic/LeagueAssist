using LeagueAssist;
using LeagueAssist.Entities;
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
    public partial class UnosLicencaSudac : Form
    {
        public UnosLicencaSudac()
        {
            InitializeComponent();
            var seasonProcessor = new SeasonProcessor();
            var licenseProcessor = new LicenseProcessor();

            comboBox1.DataSource = licenseProcessor.RetrieveReferees();
            comboBox1.DisplayMember = "FirstName";
            comboBox1.ValueMember = "Id";
            comboBox2.DataSource = seasonProcessor.RetrieveSeasons();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox3.DataSource = licenseProcessor.licenseReturn();
            comboBox3.DisplayMember = "Type";
            comboBox3.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            var pers = (Referee)comboBox1.SelectedItem;
            var seas = (Season)comboBox2.SelectedItem;
            var lic = (LeagueAssist.Entities.License)comboBox3.SelectedItem;
            if (!string.IsNullOrEmpty(comboBox1.Text) || !string.IsNullOrEmpty(comboBox2.Text) || !string.IsNullOrEmpty(comboBox3.Text))
            {
                var licenseProcessor = new LicenseProcessor();
                licenseProcessor.saveRefereeLicense(pers, seas, lic);
                MessageBox.Show("Uspješno dodijeljena licenca.");
            } else
            {
                MessageBox.Show("Krivo uneseni podaci.");
            }
               
            
        }

        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            string firstName = ((Referee)e.ListItem).firstName;
            string lastName = ((Referee)e.ListItem).lastName;
            e.Value = firstName + " " + lastName;
        }
    }
}
