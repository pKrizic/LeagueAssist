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
    public partial class PregledKlubova : Form
    {
        private List<Organization> m_data = new List<Organization>();
        private BindingSource m_bs = new BindingSource();
        public PregledKlubova()
        {
            InitializeComponent();
            var clubProcessor = new ClubProcessor();
            var clubstadium = clubProcessor.RetrieveAllClubInfo();
            dataGridView1.DataSource = clubstadium.Select(o => new
            { Id = o.Id, Name = o.OrgName, City = o.OrgCityName, CityId = o.OrgCityId,StadiumId = o.StadiumId,UserId = o.UserOrgId, Stadium = o.StadiumName}).ToList();

            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            var buttonCol = new DataGridViewButtonColumn();
            buttonCol.UseColumnTextForButtonValue = true;
            buttonCol.Name = "ButtonColumnName";
            buttonCol.HeaderText = "";
            buttonCol.Text = "Uredi klub";
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
                    UrediKlub frm2 = new UrediKlub(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
                    frm2.Show();
                }

            }
        }

        private void PregledKlubova_Load(object sender, EventArgs e)
        {

            //m_bs.DataSource = m_data;
            //m_bs.AllowNew = true;

            //dataGridView1.DataSource = m_bs;
            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.AllowUserToAddRows = true;
        }

        private void PregledKlubova_Load_1(object sender, EventArgs e)
        {
         }
    }
}
