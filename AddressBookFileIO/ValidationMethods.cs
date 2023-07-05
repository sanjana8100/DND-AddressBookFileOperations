using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    public class ValidationMethods
    {
        public bool ValidateName(string name)
        {
            Regex namePattern = new Regex("^[A-Z][a-z]{3,}$");
            Match nameMatcher = namePattern.Match(name);

            return nameMatcher.Success;
        }

        public bool ValidateEmail(string email)
        {
            Regex emailPattern = new Regex("^[0-9a-zA-Z]+([.]([a-z0-9A-Z]+))*[@][a-zA-Z]+[.][a-z]{2,4}([.][a-z]{2})?$");
            Match emailMatcher = emailPattern.Match(email);

            return emailMatcher.Success;
        }

        public bool ValidatePhoneNumber(string phoneNumber)
        {
            Regex phoneNumberPattern = new Regex("^[+]{1}[0-9]{2}\\s[0-9]{10}$");
            Match phoneNumberMatcher = phoneNumberPattern.Match(phoneNumber);

            return phoneNumberMatcher.Success;
        }

        public bool ValidateZIP(string zip)
        {
            Regex zipPattern = new Regex("^[0-9]{3}\\s[0-9]{3}$");
            Match zipMatcher = zipPattern.Match(zip);

            return zipMatcher.Success;
        }
    }
}
