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
    public partial class PregledIDetaljnoDefiniranjeKola : Form
    {
        private SeasonProcessor _seasonProcessor;
        public PregledIDetaljnoDefiniranjeKola()
        {
            InitializeComponent();
            if (_seasonProcessor == null)
                _seasonProcessor = new SeasonProcessor();
            comboBox1.DataSource = _seasonProcessor.RetrieveCompetitions();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox3.DataSource = _seasonProcessor.RetrieveSeasons(DateTime.Now);
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
            comboBox2.DataSource = _seasonProcessor.RetrieveFixtures();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var matches = _seasonProcessor.RetrieveMatchesInOneFixture(int.Parse(comboBox2.SelectedValue.ToString()));
            var lista = new List<Match>();
            foreach (var match in matches)
                lista.Add(new Match { Id = match.Id, HomeTeam = match.FirstOrg.Name, AwayTeam = match.SecondOrg.Name, Date = match.DateTime });
            dataGridView1.DataSource = lista;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var lista = dataGridView1.DataSource;
            var nesto = _seasonProcessor.Repository.GetMatchesInOneFixture(1);
        }

        private class Match
        {
            public int Id { get; set; }
            public string HomeTeam { get; set; }
            public string AwayTeam { get; set; }
            public DateTime Date { get; set; }
        }
    }
}
