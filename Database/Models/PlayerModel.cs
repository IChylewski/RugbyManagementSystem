using System;
using System.Windows.Media;

namespace RugbyManagementSystem.Database.Models
{
    class PlayerModel : MemberModel
    {
        public string Team { get; set; }
        public int Age { get; set; }

        //Skills
        public int OverallSkill { get; set; }
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
        

        public PlayerModel(int id, string firstName, string lastName, string email, DateTime dob, string type, string phoneNumber, string sruNumber, string Consent = "Not Required") : base (id, firstName, lastName, email, dob, type, phoneNumber, sruNumber, Consent = "Not Required")
        {
            StandardPass = 0;
            SpinPass = 0;
            PopPass = 0;
            FrontTackle = 0;
            RearTackle = 0;
            SideTackle = 0;
            ScrabbleTackle = 0;
            DropKick = 0;
            PuntKick = 0;
            GrubberKick = 0;
            GoalKick = 0;

            OverallSkill = (StandardPass +
                            SpinPass +
                            PopPass +
                            FrontTackle +
                            RearTackle +
                            SideTackle +
                            ScrabbleTackle +
                            DropKick +
                            PuntKick +
                            GrubberKick +
                            GoalKick) / 11;
        }

        public void UpdateOverallSkill()
        {
            OverallSkill = (StandardPass +
                            SpinPass +
                            PopPass +
                            FrontTackle +
                            RearTackle +
                            SideTackle +
                            ScrabbleTackle +
                            DropKick +
                            PuntKick +
                            GrubberKick +
                            GoalKick) / 11;
        }
    }
}
