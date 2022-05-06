using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RugbyManagementSystem.Database.Models
{
    // Parent class that stores all basic information that all members - Players, Coaches share.
    public class MemberModel
    {
        public Brush LogoColor { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public object[] Identifier { get; set; }  // This fields works as identifier that is put into Tag Property of xaml controls. It allows to store two values in one property.


        public MemberModel(int id, string firstName, string lastName, string email, string dob, string phoneNumber, string type)
        {
            Random r = new Random();
            LogoColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));  // Creates unique random color every time object is created

            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DOB = dob;
            PhoneNumber = phoneNumber;
            Type = type;
            
            FullName = FirstName + " " + LastName;  // Connects two strings to create Full Name

            Identifier = new object[2] { id, type};        // Creates new object and saves values that helps to indentify specific member


        }
    }
}
