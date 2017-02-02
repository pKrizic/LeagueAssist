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
    public partial class UnosLicence : Form
    {
        public UnosLicence()
        {
            InitializeComponent();
            var compProcessor = new CompetitionProcessor();
            comboBox1.DataSource = compProcessor.RetrieveCompetitions();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string name = textBox1.Text;
            var comp = (Competition)comboBox1.SelectedItem;
            if (!string.IsNullOrEmpty(textBox1.Text) || !string.IsNullOrEmpty(comboBox1.Text))
            {
                var licenseProcessor = new LicenseProcessor();
                licenseProcessor.saveLicence(name, comp);
                MessageBox.Show("Unos je uspješan!");
            }
            else
            {
                MessageBox.Show("Krivo uneseni podaci.");
            }
            
            
        }
    }
}
