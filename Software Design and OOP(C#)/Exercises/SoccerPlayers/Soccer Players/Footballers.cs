using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soccer_Players
{
    public partial class Footballers : Form
    {
        IList<CPlayer> Players = new List<CPlayer>();

        public Footballers()
        {           
            InitializeComponent();          
            lstbxPlayers.Items.Add("Name".PadRight(10) + "Age".PadRight(10) + "Goals".PadRight(15) + "Assists".PadRight(10));
            lstbxPlayers.Items.Add("===================================================================");
        }

        private void Footballers_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            CPlayer Player = new CPlayer(txbName.Text, (int)nudGoals.Value, (int)nudAssists.Value, (int)nudAge.Value);
            Players.Add(Player);
            UpdateList();
        }
        public void UpdateList()
        {
            lstbxPlayers.Items.Clear();
            lstbxPlayers.Items.Add("Name".PadRight(10) + "Age".PadRight(10) + "Goals".PadRight(15) + "Assists".PadRight(10));
            lstbxPlayers.Items.Add("===================================================================");

            if (txbName.Text == null)
            {
                MessageBox.Show("Please insert a player name.");
            }
            else if ()
            {

            }
            else
            {
                foreach (CPlayer Player in Players)
                {
                    lstbxPlayers.Items.Add(Player.Description());
                }
            }

            
        }
    }
}
