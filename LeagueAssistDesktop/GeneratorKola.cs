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
    public partial class GeneratorKola : Form
    {
        public GeneratorKola()
        {
            InitializeComponent();
            var clas = new Class1();
            comboBox1.DataSource = clas.GetFutureSeasons();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
            comboBox2.DataSource = clas.GetCompetititons();
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var clas = new Class1();
            int seasonId = int.Parse(comboBox1.SelectedValue.ToString());
            int competitionId = int.Parse(comboBox2.SelectedValue.ToString());
            List<int> dohvatiBrojEkipaULigi = clas.GetIdsOfClubsInCompetition(competitionId, seasonId);
            var dict = RoundRobinScheduler(dohvatiBrojEkipaULigi);
            clas.StoreMatchesFromSeason(dict, competitionId);
        }

        private Dictionary<int, List<int[]>> RoundRobinScheduler (List<int> ids)
        {
            Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>();
            List<int[]> listaParova = new List<int[]>();
            if ((ids.Count % 2) == 1)
                ids.Add(0);
            int brojKola = (ids.Count - 1);
            int halfSize = ids.Count / 2;

            List<int> teams = new List<int>();
            teams.AddRange(ids.Skip(halfSize).Take(halfSize));
            teams.AddRange(ids.Skip(1).Take(halfSize - 1).ToArray().Reverse());
            int teamsSize = teams.Count;

            for (int day = 0; day < brojKola; day++)
            {
                dict.Add(day + 1, null);
                int teamIdx = day % teamsSize;
                if ((day % 2) == 1)
                {
                    int[] ekipe = { teams[teamIdx], ids[0] };
                    listaParova.Add(ekipe);
                    for (int idx = 1; idx < halfSize; idx++)
                    {
                        int firstTeam = (day + idx) % teamsSize;
                        int secondTeam = (day + teamsSize - idx) % teamsSize;
                        int[] ekip = { teams[firstTeam], teams[secondTeam] };
                        listaParova.Add(ekip);
                    }
                }
                else
                {
                    int[] ekipe = { ids[0], teams[teamIdx] };
                    listaParova.Add(ekipe);
                    for (int idx = 1; idx < halfSize; idx++)
                    {
                        int firstTeam = (day + teamsSize - idx) % teamsSize;
                        int secondTeam = (day + idx) % teamsSize;
                        int[] ekip = { teams[firstTeam], teams[secondTeam] };
                        listaParova.Add(ekip);
                    }
                }
                dict[day + 1] = listaParova;
                listaParova = new List<int[]>();
            }
            return dict;
        }
    }
}
