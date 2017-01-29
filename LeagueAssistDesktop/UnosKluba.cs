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
    public partial class UnosKluba : Form
    {
        public UnosKluba(int id = 0)
        {
            InitializeComponent();
            var clubProcessor = new ClubProcessor();
            comboBox1.DataSource = clubProcessor.RetrieveAllStadiums();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox2.DataSource = clubProcessor.RetrieveAllCities();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox3.DataSource = clubProcessor.RetrieveAllUsers();
            comboBox3.DisplayMember = "UserName";
            comboBox3.ValueMember = "Id";
            if (id != 0)
            {
                var refere = clubProcessor.GetClubInformation(id);
                comboBox1.DataSource = clubProcessor.RetrieveAllStadiums();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                comboBox2.DataSource = clubProcessor.RetrieveAllCities();
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
                comboBox3.DataSource = clubProcessor.RetrieveAllUsers();
                comboBox3.DisplayMember = "UserName";
                comboBox3.ValueMember = "Id";
            }
        }

        private void UnosKluba_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clubProcessor = new ClubProcessor();
            string name = textBox1.Text;
            var stadium = (Stadium)comboBox1.SelectedItem;
            var city = (City)comboBox2.SelectedItem;
            var user = (User)comboBox3.SelectedItem;
            var result = clubProcessor.saveClub(name, stadium, city, user);
            MessageBox.Show(result);
        }
    }
}
