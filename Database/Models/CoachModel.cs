using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RugbyManagementSystem.Database.Models
{
    //The only difference between Parent class and this one is that Coach Class always has property 'type' set on default

    public class CoachModel : MemberModel
    {
        public CoachModel(int id, string firstName, string lastName, string email, string dob, string phoneNumber,string type = "Coach") : base(id, firstName, lastName, email, dob, phoneNumber, type)
        {
        }
    }
}
