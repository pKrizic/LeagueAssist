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
    public partial class PopisSudacaILicenci : Form
    {
        public PopisSudacaILicenci()
        {
            InitializeComponent();
            var proc = new SeasonProcessor();
            var referees = proc.RetrieveReferees();
            dataGridView1.DataSource = referees.Select(o => new
            { Id = o.Id, Ime = o.FirstName, Prezime = o.LastName, Rođenje = o.BirthDate, Email = o.Email, Telefon = o.Phone }).ToList();

            dataGridView1.CellClick += dataGridView1_CellClick;
            var buttonCol = new DataGridViewButtonColumn();
            buttonCol.UseColumnTextForButtonValue = true;
            buttonCol.Name = "ButtonColumnName";
            buttonCol.HeaderText = "";
            buttonCol.Text = "Uredi suca";
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
                    UnosSudca frm2 = new UnosSudca(int.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));
                    frm2.Show();
                }

            }
        }
    }
}
