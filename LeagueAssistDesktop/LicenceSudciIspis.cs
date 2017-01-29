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
    public partial class LicenceSudciIspis : Form
    {
        public LicenceSudciIspis()
        {
            InitializeComponent();
            LicenseProcessor lp = new LicenseProcessor();
            var obj = lp.LicenseRefereeReturn();

            dataGridView1.DataSource = obj.Select(o => new
            {
                Sudac = o.referee.ToString(),
                Sezona = o.season.Name,
                Licenca = o.license.Type
            }).ToList();
            //dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void LicenceSudciIspis_Load(object sender, EventArgs e)
        {

        }
    }
}
