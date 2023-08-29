using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.RegularExpressions;

namespace Hillel_HW_12
{
    public class ValidFachen
    {

        public bool IsValidName(string ferstName, string lastName)
        {
            string FerstNameValid = @"^[A-Z][a-z]{1,9}$";
            string LastNameValid = @"^[A-Z][a-z]{1,9}$";

            bool a =  Regex.IsMatch(ferstName, FerstNameValid);
            bool b = Regex.IsMatch(lastName, LastNameValid);
            if (a && b) 
            { 
                return true;
            }
            return false;
        }

        public bool ModelValid (MyFamiliar myFamiliar)
        {
            string ageValid = @"^(?:[1-9][0-9]?|100)$";
            bool validFulName = IsValidName(myFamiliar.Name, myFamiliar.Surname);
            bool validAge = Regex.IsMatch(myFamiliar.Age.ToString(), ageValid);
            if(validFulName && validAge) 
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
