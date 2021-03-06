﻿using System;
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
    public partial class StvoriNatjecanje : Form
    {
        public OrganizationProcessor op;
        public CompetitionProcessor cp;
        public StvoriNatjecanje()
        {
            InitializeComponent();
            op = new OrganizationProcessor();
            cp = new CompetitionProcessor();
            comboBox1.DataSource = op.getOrganizations();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var org = (Organization)comboBox1.SelectedItem;
            var radio = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            var result = cp.PrepareStoreCompetition(textBox2.Text, org, radio);
            MessageBox.Show(result);
        }

       
    }
}
