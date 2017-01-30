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
    public partial class AddingReferee : Form
    {
        public AddingReferee(string matchId, string competitionId, string seasonId)
        {
            InitializeComponent();
            textBox1.Text = matchId;
            var licenceProcessor = new LicenseProcessor();
            var referees = licenceProcessor.RetrieveReferees();
            var nes = licenceProcessor.Repository.GetRefereesWithLicence(int.Parse(seasonId), int.Parse(competitionId));
            List<Referee> podaci = new List<Referee>();
            foreach (var referee in referees)
                if (nes.Contains(referee.Id))
                    podaci.Add(referee);

            comboBox1.DataSource = podaci;
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "LastName";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int matchId = int.Parse(textBox1.Text);
            int refereeId = int.Parse(comboBox1.SelectedValue.ToString());

            var matchProcessor = new MatchProcessor();
            matchProcessor.SetMatchreferee(matchId, refereeId);
            MessageBox.Show("Podaci su uspješno ažurirani");
        }
    }
}
