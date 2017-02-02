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
    public partial class StvoriNovoNatjecanje : Form
    {
        public StvoriNovoNatjecanje()
        {
            InitializeComponent();
            var seasonProc = new SeasonProcessor();
            var organizationProc = new OrganizationProcessor();

            comboBox1.DataSource = seasonProc.RetrieveCompetitions();
            comboBox2.DataSource = seasonProc.RetrieveSeasons(DateTime.Now);
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox1.SelectedIndexChanged += SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += SelectedIndexChanged;
            var organizations = organizationProc.getOrganizations();
            var orglic = organizationProc.RetrieveOrganizationWithLicence(int.Parse(comboBox2.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()));
            List<Organization> lista = new List<Organization>();
            foreach (var org in organizations)
                if (orglic.Contains(org.Id))
                    lista.Add(org);

            listBox1.DataSource = lista;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";
            listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SelectedIndexChanged(object sender, EventArgs e)
        {
            var organizationProc = new OrganizationProcessor();
            var organizations = organizationProc.getOrganizations();
            var orglic = organizationProc.RetrieveOrganizationWithLicence(int.Parse(comboBox2.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString()));
            List<Organization> lista = new List<Organization>();
            foreach (var org in organizations)
                if (orglic.Contains(org.Id))
                    lista.Add(org);
            listBox1.DataSource = lista;
        }

        private void StvoriNovoNatjecanje_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var compProcessor = new CompetitionProcessor();
            var competition = (Competition)comboBox1.SelectedItem;
            var season = (Season)comboBox2.SelectedItem;
            var clubs = listBox1.SelectedItems.Cast<Organization>();
            List<Organization> listOrg = new List<Organization>();
            listOrg.AddRange(clubs);
            var message = compProcessor.StoreOrganizationsIncompetition(competition, season, listOrg);
            MessageBox.Show(message);
        }
    }
}
