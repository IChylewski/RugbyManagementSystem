using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RugbyManagementSystem.Database.Models
{
    class MemberModel
    {
        public Brush LogoColor { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string Type { get; set; }
        public string PhoneNumber { get; set; }
        public string SRUNumber { get; set; }
        public string Consent { get; set; }


        public MemberModel(int id, string firstName, string lastName, string email, string dob, string type, string phoneNumber, string sruNumber = null, string consent = "Not Required")
        {
            Random r = new Random();
            LogoColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DOB = dob;
            Type = type;
            PhoneNumber = phoneNumber;
            SRUNumber = sruNumber;
            Consent = consent;
            
            FullName = FirstName + " " + LastName;


        }
    }
}
