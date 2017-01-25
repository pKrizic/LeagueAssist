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
            dataGridView1.Columns[1].Width = 300;
        }
    }
}
