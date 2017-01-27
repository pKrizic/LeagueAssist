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
    public partial class UnosSudca : Form
    {
        public UnosSudca(int id = 0)
        {
            InitializeComponent();
            textBox6.Text = id.ToString();
            var proc = new DataProcessor();
            comboBox1.DataSource = proc.Repository.GetUsers();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Username";
            if (id != 0)
            {
                var refere = proc.GetPerson(id);
                textBox1.Text = refere.FirstName;
                textBox2.Text = refere.LastName;
                textBox3.Text = refere.BirthDate.ToString("dd/MM/yyyy");
                textBox4.Text = refere.Email;
                textBox5.Text = refere.Phone;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var procesor = new DataProcessor();
            int id = int.Parse(textBox6.Text);
            string name = textBox1.Text;
            string lastName = textBox2.Text;
            string date = textBox3.Text;
            string email = textBox4.Text;
            string phone = textBox5.Text;
            var user = (User)comboBox1.SelectedItem;
            var message = procesor.SaveUpdatePerson(id, name, lastName, date, email, phone, user);
            MessageBox.Show(message);
        }
    }
}
