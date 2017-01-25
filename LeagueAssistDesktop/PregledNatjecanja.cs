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
    public partial class PregledNatjecanja : Form
    {
        public PregledNatjecanja()
        {
            InitializeComponent();
            var proc = new CompetitionProcessor();
            var objects = proc.RetrieveCompetitions();
            dataGridView1.DataSource = objects.Select(o => new
            { Id = o.Id, Naziv = o.Name}).ToList();
            dataGridView1.Columns[1].Width = 240;

            dataGridView1.CellClick += dataGridView1_CellClick;
            var buttonCol = new DataGridViewButtonColumn();
            buttonCol.UseColumnTextForButtonValue = true;
            buttonCol.Name = "ButtonColumnName";
            buttonCol.HeaderText = "";
            buttonCol.Text = "Uredi natjecanje";
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
                    UrediNatjecanje frm2 = new UrediNatjecanje(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    frm2.Show();
                }

            }
        }
    }
}
