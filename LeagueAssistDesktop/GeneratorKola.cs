using LeagueAssist;
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
    public partial class GeneratorKola : Form
    {
        public GeneratorKola()
        {
            InitializeComponent();
            var seasonProcessor = new SeasonProcessor();
            comboBox1.DataSource = seasonProcessor.RetrieveSeasons(DateTime.Now);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox2.DataSource = seasonProcessor.RetrieveCompetitions();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int seasonId = int.Parse(comboBox1.SelectedValue.ToString());
            int competitionId = int.Parse(comboBox2.SelectedValue.ToString());
            var seasonProcessor = new SeasonProcessor();
            var message = seasonProcessor.GenerateTheFixturesForTheSeason(competitionId, seasonId);
            MessageBox.Show(message);
        }
    }
}
