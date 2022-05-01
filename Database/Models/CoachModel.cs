using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManagementSystem.Database.Models
{
    public class CoachModel : MemberModel
    {

        public CoachModel(int id, string firstName, string lastName, string email, string dob, string phoneNumber,string type = "Coach") : base(id, firstName, lastName, email, dob, phoneNumber, type)
        {
        }
    }
}
