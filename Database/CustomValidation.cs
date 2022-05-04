using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RugbyManagementSystem.Database
{
    static class CustomValidation
    {
        public static bool ValidateName(string boxName,string name)
        {
            string regexPattern = "^[a-zA-Z]+$";
            Regex nameRegex = new Regex(regexPattern);


            bool validation = true;

            if (name.Length < 0 || name.Length > 20)
            {
                validation = false;
                MessageBox.Show($"{boxName} length is not valid");
            }
            else if (nameRegex.IsMatch(name) == false)
            {
                validation = false;
                MessageBox.Show($"{boxName} input is not valid");
            }

            return validation;
        }
        public static bool ValidateEmail(string boxName, string email)
        {
            string regexPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
            Regex nameRegex = new Regex(regexPattern);


            bool validation = true;

            if (email.Length < 0 || email.Length > 20)
            {
                validation = false;
                MessageBox.Show($"{boxName} length is not valid");
            }
            else if (nameRegex.IsMatch(email) == false)
            {
                validation = false;
                MessageBox.Show($"{boxName} input is not valid");
            }

            return validation;
        }
        public static bool ValidateChoiceBox(string boxName, object selectedItem)
        {
            bool validation = true;

            if(selectedItem == null)
            {
                validation = false;

                MessageBox.Show($"{boxName} cannot be empty");
            }

            return validation;
        }
        /*public static bool ValidateDate(string boxName, DateTime date)
        {
            bool validation = true;

            if (date == null)
            {
                validation = false;

                MessageBox.Show($"{boxName} cannot be empty");
            }

            return validation;
        }*/
        public static bool ValidatePhoneNumber(string boxName, string phoneNumber)
        {
            string regexPattern = "^[0-9]*$";
            Regex nameRegex = new Regex(regexPattern);


            bool validation = true;

            if (phoneNumber.Length > 11 || phoneNumber.Length < 11)
            {
                validation = false;
                MessageBox.Show($"{boxName} length is not valid");
            }
            else if (nameRegex.IsMatch(phoneNumber) == false)
            {
                validation = false;
                MessageBox.Show($"{boxName} input is not valid");
            }

            return validation;
        }
        public static bool ValidateSRUNumber(string boxName, string sruNumber)
        {
            string regexPattern = "^[0-9]*$";
            Regex nameRegex = new Regex(regexPattern);


            bool validation = true;

            if (sruNumber.Length > 11 || sruNumber.Length < 11)
            {
                validation = false;
                MessageBox.Show($"{boxName} length is not valid");
            }
            else if (nameRegex.IsMatch(sruNumber) == false)
            {
                validation = false;
                MessageBox.Show($"{boxName} input is not valid");
            }

            return validation;
        }
        public static bool ValidateSkill(string boxName, string skill)
        {
            string regexPattern = "^[0-9]*$";
            Regex nameRegex = new Regex(regexPattern);
            

            bool validation = true;

            if (skill.Length > 1 || skill.Length < 1)
            {
                validation = false;
                MessageBox.Show($"{boxName} length is not valid");
            }
            else if (nameRegex.IsMatch(skill) == false)
            {
                validation = false;
                MessageBox.Show($"{boxName} input is not valid");
            }
            else if(int.Parse(skill) < 0 || int.Parse(skill) > 5)
            {
                validation = false;
                MessageBox.Show($"{boxName} not in range 1-5");
            }
            return validation;
        }
    }
}
