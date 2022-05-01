using RugbyManagementSystem.Database.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace RugbyManagementSystem.Database.Models
{
    public class TeamModel
    {
        public Brush TeamLogo { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int PlayersNumber { get; set;}
        public string PlayersNumberDisplay { get; set; }
        public List<PlayerModel> PlayersList { get; set; }
        //private DataContainer dataContainer { get; set; }

        public TeamModel(int id, string name)
        {
            Random r = new Random();
            TeamLogo = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

            PlayersList = new List<PlayerModel>();

            ID = id;
            Name = name;

            FindPlayers();

            
        }

        public void FindPlayers()
        {
            foreach(PlayerModel player in DataContainer.Players)
            {
                if(player.TeamID == ID)
                {
                    PlayersList.Add(player);
                    MessageBox.Show("Found Player2");
                }
            }
            PlayersNumber = PlayersList.Count;

            PlayersNumberDisplay = PlayersNumber.ToString() + " / 50";
        }
    }
}
