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
        public string ID { get; set; }
        public string Name { get; set; }
        public string PlayersNumber { get; set;}
        public List<PlayerModel> PlayersList { get; set; }

        public TeamModel()
        {
            Random r = new Random();
            TeamLogo = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
        }
    }
}
