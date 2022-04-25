using System;
using System.Windows.Media;

namespace RugbyManagementSystem.Database.Models
{
    class PlayerModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string Age { get; set; }
        public string Type { get; set; }
        public string OverallSkill { get; set; }
        public int StandardPass { get; set; }
        public int SpinPass { get; set; }
        public int PopPass { get; set; }
        public int FrontTackle { get; set; }
        public int RearTackle { get; set; }
        public int SideTackle { get; set; }
        public int ScrabbleTackle { get; set; }
        public int DropKick { get; set; }
        public int PuntKick { get; set; }
        public int GrubberKick { get; set; }

        public int GoalKick { get; set; }
        public Brush TeamLogo { get; set; }

        public PlayerModel()
        {
            Random r = new Random();
            TeamLogo = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));
        }
    }
}
