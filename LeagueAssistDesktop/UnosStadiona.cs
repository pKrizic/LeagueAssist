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
using LeagueAssist.Entities;

namespace LeagueAssistDesktop
{
    public partial class UnosStadiona : Form
    {
        public ICityRepository _cityRepository;
        public StadiumProcessor sp;
        public UnosStadiona()
        {
            InitializeComponent();
            sp = new StadiumProcessor();
            _cityRepository = new CityRepository();
            comboBox1.DataSource = _cityRepository.getCities();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Name";
            dataGridView1.DataSource = sp.Repository.getStadions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var city = (City)comboBox1.SelectedItem;
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text) && !String.IsNullOrEmpty(textBox3.Text))
            {
                sp.prepareStoreStadium(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, city);
                MessageBox.Show("Stadion je uspješno unesen");
            }
            else
                MessageBox.Show("Nisu ispunjeni svi podaci");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
