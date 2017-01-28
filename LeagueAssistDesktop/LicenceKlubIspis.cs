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
    public partial class LicenceKlubIspis : Form
    {
        public LicenceKlubIspis()
        {
            InitializeComponent();
            LicenseProcessor lp = new LicenseProcessor();
            var obj = lp.LicenseClubReturn();

            // dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = obj.Select(o => new
            {
                Klub = o.Organization.Name,
                Sezona = o.Season.Name,
                Licenca = o.License.Type 
            }).ToList();
           
        }
    }
}
