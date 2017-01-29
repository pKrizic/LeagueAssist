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

namespace LeagueAssistDesktop
{
    public partial class PrikazSvihLicenci : Form
    {
        public PrikazSvihLicenci()
        {
            InitializeComponent();
            LicenseProcessor lp = new LicenseProcessor();
            var obj = lp.licenseReturn();
            dataGridView1.DataSource = obj.Select(o => new
            { Id = o.Id, Name = o.Type}).ToList();
        }
    }
}
