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
    public partial class UrediNatjecanje : Form
    {
        public UrediNatjecanje(string id, string name)
        {
            InitializeComponent();
            textBox1.Text = id;
            textBox2.Text = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox1.Text);
            string name = textBox2.Text;
            var processor = new CompetitionProcessor();
            var result = processor.StoreChanges(id, name);
            MessageBox.Show(result);
        }
    }
}
