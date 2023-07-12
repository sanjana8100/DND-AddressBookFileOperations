using AddressBookFileIO;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;

namespace AddressBookTesting
{
    [TestClass]
    public class UnitTest1
    {
        public AddressBookFileIO.ValidationMethods validationMethods = new AddressBookFileIO.ValidationMethods();
        public AddressBookFileIO.AddressBook addressBook = new AddressBookFileIO.AddressBook();


        [TestMethod]
        [DataRow("Sanjana", true)]
        [DataRow("shreyas", false)]
        public void CheckAndReturnTrueIfNameIsValid(string name, bool expected)
        {
            bool result = validationMethods.ValidateName(name);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("Sanjana@gmail.com", true)]
        [DataRow("shreyasgmail.co", false)]
        public void CheckAndReturnTrueIfEmailIsValid(string email, bool expected)
        {
            bool result = validationMethods.ValidateEmail(email);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("+91 9535397690", true)]
        [DataRow("9005234567", false)]
        public void CheckAndReturnTrueIfPhoneNumberIsValid(string phone, bool expected)
        {
            bool result = validationMethods.ValidatePhoneNumber(phone);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("563 101", true)]
        [DataRow("563 1000", false)]
        public void CheckAndReturnTrueIfZipCodeIsValid(string zip, bool expected)
        {
            bool result = validationMethods.ValidateZIP(zip);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("Akshara", "akshara@gmail.com", "+91 9535397694", "Karnataka", "Bengaluru", "563 101", true)]
        [DataRow("sanjana", "sanjana@gmail.com", "+91 9535397690", "Karnataka", "Bengaluru", "563 101", false)]
        [DataRow("Sanjana", "sanjanagmail.com", "+91 9535397690", "Karnataka", "Bengaluru", "563 101", false)]
        [DataRow("Sanjana", "sanjana@gmail.com", "+919535397690", "Karnataka", "Bengaluru", "563 101", false)]
        [DataRow("Sanjana", "sanjana@gmail.com", "+91 9535397690", "Karnataka", "Bengaluru", "563101", false)]
        public void CheckIfContactIsAdded(string name, string email, string phone, string state, string city, string zipcode, bool expected)
        {
            bool result = addressBook.AddContact(name, email, phone, state, city, zipcode);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("Shreyas", "Shrax", 1, true)]
        [DataRow("Shreyas", "shrax@gmail.com", 2, true)]
        [DataRow("Shreyas", "+91 8792451230", 3, true)]
        [DataRow("Shreyas", "Delhi", 4, true)]
        [DataRow("Shreyas", "Delhi", 5, true)]
        [DataRow("Shreyas", "574 003", 6, true)]
        public void CheckIfContactIsEdited(string editName, string newData, int editType, bool expected)
        {
            Contact resultContact = addressBook.EditContact(editName, newData, editType);
            bool result = false;
            if (addressBook.ContactList.Contains(resultContact))
            {
                switch (editType)
                {
                    case 1:
                        if (resultContact.Name.Equals(newData))
                        {
                            result = true;
                        }   
                        break;
                    case 2:
                        if (resultContact.Email.Equals(newData))
                        {
                            result = true;
                        }
                        break;
                    case 3:
                        if (resultContact.Phone.Equals(newData))
                        {
                            result = true;
                        }
                        break;
                    case 4:
                        if (resultContact.State.Equals(newData))
                        {
                            result = true;
                        }
                        break;
                    case 5:
                        if (resultContact.City.Equals(newData))
                        {
                            result = true;
                        }
                        break;
                    case 6:
                        if (resultContact.Zipcode.Equals(newData))
                        {
                            result = true;
                        }
                        break;
                }
            }
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("Namratha", true)]
        [DataRow("Akash", true)]
        public void CheckIfContactIsDeleted(string deleteName, bool expected)
        {
            Contact resultContact = addressBook.DeleteContact(deleteName);
            bool result = false;
            if (resultContact.Name.Equals(deleteName) && !addressBook.ContactList.Contains(resultContact)) 
            {
                result = true;
            }
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow("Namratha", true)]
        [DataRow("Akash", true)]
        public void CheckIfSpecificContactIsDisplayed(string displayName, bool expected)
        {
            Contact resultContact = addressBook.DisplayContact(displayName);
            bool result = false;
            if (resultContact.Name.Equals(displayName))
            {
                result = true;
            }
            Assert.AreEqual(expected, result);
        }
    }
}