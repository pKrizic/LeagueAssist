using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeagueAssist;
using LeagueAssist.Entities;

namespace LeagueAssistDesktop
{
    public partial class PopisKlubovaILicence : Form
    {
        public PopisKlubovaILicence()
        {
            InitializeComponent();
            LicenseProcessor lp = new LicenseProcessor();
            var obj = lp.LicenseClubReturn();
            dataGridView1.DataSource = obj.Select(o => new
            { Id = o.Id, Name = o.Organization.Name, season = o.Season.Name, license = o.License.Type}).ToList();
            dataGridView1.CellClick += dataGridView1_CellClick;
            var buttonCol = new DataGridViewButtonColumn();
            buttonCol.UseColumnTextForButtonValue = true;
            buttonCol.Name = "ButtonColumnName";
            buttonCol.HeaderText = "";
            buttonCol.Text = "Uredi licencu";
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
                    LicenseClub frm2 = new LicenseClub(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                    frm2.Show();
                }

            }
        }
    }
    }

