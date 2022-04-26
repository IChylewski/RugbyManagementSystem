using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RugbyManagementSystem.Database.Models
{
    class TeamModel
    {
        public Brush TeamLogo { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int PlayersNumber { get; set;}
        public string PlayersNumberDisplay { get; set; }
        public List<PlayerModel> PlayersList { get; set; }

        public TeamModel(int id, string name)
        {
            Random r = new Random();
            TeamLogo = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

            PlayersList = new List<PlayerModel>();
            PlayersNumber = PlayersList.Count;

            ID = id;
            Name = name;

            PlayersNumberDisplay = PlayersNumber.ToString() + " / 50";
        }
    }
}
