using AddressBookFileIO;

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
        [DataRow("Sanjana", "sanjana@gmail.com", "+91 9535397690", "Karnataka", "Bengaluru", "563 101", true)]
        [DataRow("sanjana", "sanjana@gmail.com", "+91 9535397690", "Karnataka", "Bengaluru", "563 101", false)]
        [DataRow("Sanjana", "sanjanagmail.com", "+91 9535397690", "Karnataka", "Bengaluru", "563 101", false)]
        [DataRow("Sanjana", "sanjana@gmail.com", "+919535397690", "Karnataka", "Bengaluru", "563 101", false)]
        [DataRow("Sanjana", "sanjana@gmail.com", "+91 9535397690", "Karnataka", "Bengaluru", "563101", false)]
        public void CheckIfContactIsAdded(string name, string email, string phone, string state, string city, string zipcode, bool expected)
        {
            bool result = addressBook.AddContact(name, email, phone, state, city, zipcode);
            Assert.AreEqual(expected, result);
        }
    }
}