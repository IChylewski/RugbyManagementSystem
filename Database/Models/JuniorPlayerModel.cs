using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManagementSystem.Database.Models
{
    public class JuniorPlayerModel : PlayerModel
    {
        public string Consent { get; set; }
        public JuniorPlayerModel(int id, string firstName, string lastName, string email, string dob, string phoneNumber, string sruNumber, string consent, int teamID , int standardPass, int spinPass, int popPass, int frontTackle, int rearTackle, int sideTackle, int scrabbleTackle, int dropKick, int puntKick, int grubberKick, int goalKick, string type = "Junior Player") : base(id, firstName, lastName, email, dob, phoneNumber, sruNumber,teamID, standardPass, spinPass, popPass, frontTackle, rearTackle, sideTackle, scrabbleTackle, dropKick, puntKick, grubberKick, goalKick, type)
        {
            Consent = consent;
        }
    }
}
