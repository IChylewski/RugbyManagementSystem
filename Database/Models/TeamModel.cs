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
        public int PlayersNumber { get; set;}         // stores number of players that are currently in the team
        public string PlayersNumberDisplay { get; set; }     // stores string that is displayed in the xaml control
        public List<PlayerModel> PlayersList { get; set; }     // stores all players that belongs to this team

        public TeamModel(int id, string name)
        {
            Random r = new Random();
            TeamLogo = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));  // unique random color for each team

            PlayersList = new List<PlayerModel>();

            ID = id;
            Name = name;

            FindPlayers();  // On Create finds all players that belongs to this team

            
        }

        public void FindPlayers()             // Searches DataBase List for all players that have TeamID set to ID of this team
        {
            PlayersList.Clear();
            foreach(PlayerModel player in DataContainer.Players)
            {
                if(player.TeamID == ID)
                {
                    PlayersList.Add(player);
                }
            }
            PlayersNumber = PlayersList.Count;            // UPDATES Number and String

            PlayersNumberDisplay = PlayersNumber.ToString() + " / 50";
        }
    }
}
