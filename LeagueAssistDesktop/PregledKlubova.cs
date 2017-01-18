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
        }

        private void PregledKlubova_Load(object sender, EventArgs e)
        {

            m_bs.DataSource = m_data;
            m_bs.AllowNew = true;

            dataGridView1.DataSource = m_bs;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.AllowUserToAddRows = true;
        }
    }
}
