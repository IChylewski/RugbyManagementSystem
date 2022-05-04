using RugbyManagementSystem.Database.Data;
using System;
using System.Windows.Media;

namespace RugbyManagementSystem.Database.Models
{
    public class PlayerModel : MemberModel
    {
        //Fields
        public int TeamID { get; set; }
        public string SRUNumber { get; set; }
        public string TeamName { get; set; }

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


        public PlayerModel(int id, string firstName, string lastName, string email, string dob, string phoneNumber, string sruNumber, int teamID,int standardPass,int spinPass, int popPass, int frontTackle, int rearTackle, int sideTackle, int scrabbleTackle, int dropKick, int puntKick, int grubberKick, int goalKick, string type = "Adult Player") : base (id, firstName, lastName, email, dob, phoneNumber, type)
        {
            TeamID = teamID;
            SRUNumber = sruNumber;


            StandardPass = standardPass;
            SpinPass = spinPass;
            PopPass = popPass;
            FrontTackle = frontTackle;
            RearTackle = rearTackle;
            SideTackle = sideTackle;
            ScrabbleTackle = scrabbleTackle;
            DropKick = dropKick;
            PuntKick = puntKick;
            GrubberKick = grubberKick;
            GoalKick = goalKick;

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

            //FindTeamName();
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
        public void FindTeamName()
        {
            foreach(TeamModel x in DataContainer.Teams)
            {
                if(TeamID == x.ID)
                {
                    TeamName = x.Name;
                    break;
                }
                else
                {
                    TeamName = "Free";
                }
            }
        }
    }
}
