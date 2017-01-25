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
            var sudci = _seasonProcessor.RetrieveReferees();
            foreach (var match in matches)
                lista.Add(new Match { Id = match.Id, HomeTeam = match.FirstOrg.Name, AwayTeam = match.SecondOrg.Name, Date = match.DateTime });
            dataGridView1.DataSource = lista;
            dataGridView1.CellClick += dataGridView1_CellClick;
            var buttonCol = new DataGridViewButtonColumn();
            buttonCol.UseColumnTextForButtonValue = true;
            buttonCol.Name = "ButtonColumnName";
            buttonCol.HeaderText = "Sudac";
            buttonCol.Text = "Postavi sudca";

            dataGridView1.Columns.Add(buttonCol);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewButtonCell button = (row.Cells["ButtonColumnName"] as DataGridViewButtonCell);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    AddingReferee frm2 = new AddingReferee(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    frm2.Show();
                }

            }
        }

        private class Match
        {
            public int Id { get; set; }
            public string HomeTeam { get; set; }
            public string AwayTeam { get; set; }
            public DateTime Date { get; set; }
        }

        private void PregledIDetaljnoDefiniranjeKola_Load(object sender, EventArgs e)
        {

        }
    }
}
