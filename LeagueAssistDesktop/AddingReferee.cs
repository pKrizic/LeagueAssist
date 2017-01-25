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
    public partial class AddingReferee : Form
    {
        public AddingReferee(string matchId)
        {
            InitializeComponent();
            textBox1.Text = matchId;
            var seasonProcessor = new SeasonProcessor();
            comboBox1.DataSource = seasonProcessor.RetrieveReferees();
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
