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
    public partial class UrediKlub : Form
    {
        int clubId;
        int usId;
        public UrediKlub(string id, string ime, string cityId, string stadiumId, string uId)
        {
            var clubProcessor = new ClubProcessor();
            InitializeComponent();
            clubId = int.Parse(id);
            usId = int.Parse(uId);
            textBox1.Text = ime;
            var city = clubProcessor.RetrieveAllCities();
            var stadium = clubProcessor.RetrieveAllStadiums();
            comboBox3.DataSource = city;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Id";
            comboBox3.SelectedValue = int.Parse(cityId);
            comboBox1.DataSource = stadium;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox1.SelectedValue = int.Parse(stadiumId);
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UrediKlub_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clubProcessor = new ClubProcessor();
            int id = clubId;
            int idu = usId;
            string name = textBox1.Text;
            var stadium = (Stadium)comboBox1.SelectedItem;
            var city = (City)comboBox3.SelectedItem;
            var user = (User)clubProcessor.RetrieveUser(usId);
            clubProcessor.updateClub(id, name, stadium, city, user);
            MessageBox.Show("Dobro je sve.");

        }
    }
}
