using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    public class AddressBook
    {
        List<Contact> ContactList = new List<Contact>();
        ValidationMethods validationMethods = new ValidationMethods();

        string path = "C:\\Users\\INS 5570\\source\\repos\\AddressBookFileIO\\AddressBookFileIO\\JSONFile.json";

        public AddressBook()
        {
            ContactList = LoadContactsFromFile();
        }

        private List<Contact> LoadContactsFromFile()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                return contacts ?? new List<Contact>();
            }

            return new List<Contact>();
        }

        public bool AddContact(string name, string email, string phone, string state, string city, string zipcode)
        {
            if (!validationMethods.ValidateName(name))
            {
                Console.WriteLine("INVALID NAME!!! Enter the valid data...\n");
                return false;
            }

            if (!validationMethods.ValidateEmail(email))
            {
                Console.WriteLine("INVALID EMAIL!!! Enter the valid data...\n");
                return false;
            }

            if (!validationMethods.ValidatePhoneNumber(phone))
            {
                Console.WriteLine("INVALID PHONE NUMBER!!! Enter the valid data...\n");
                return false;
            }

            if (!validationMethods.ValidateZIP(zipcode))
            {
                Console.WriteLine("INVALID ZIP CODE!!! Enter the valid data...\n");
                return false;
            }

            Contact contact = new Contact(name, email, phone, state, city, zipcode);

            foreach (Contact c in ContactList)
            {
                if (c.phone == phone || c.name == name)
                {
                    throw new DuplicateContactException("DUPLICATE CONTACT FOUND!!! Please add contact with different attributes.");
                }
            }

            ContactList.Add(contact);
            Console.WriteLine("Contact Added...");
            return true;
        }

        public Contact EditContact(string editName, string newData, int editType)
        {
            for (int index = 0; index < ContactList.Count; index++)
            {
                Contact contact = ContactList[index];
                if (editName.Equals(contact.name))
                {
                    switch (editType)
                    {
                        case 1:
                            if (!validationMethods.ValidateName(newData))
                            {
                                Console.WriteLine("INVALID NAME!!! Enter the valid data...\n");
                                return null;
                            }
                            contact.name = newData;
                            break;
                        case 2:
                            if (!validationMethods.ValidateEmail(newData))
                            {
                                Console.WriteLine("INVALID EMAIL!!! Enter the valid data...\n");
                                return null;
                            }
                            contact.email = newData;
                            break;
                        case 3:
                            if (!validationMethods.ValidatePhoneNumber(newData))
                            {
                                Console.WriteLine("INVALID PHONE NUMBER!!! Enter the valid data...\n");
                                return null;
                            }
                            contact.phone = newData;
                            break;
                        case 4:
                            contact.state = newData;
                            break;
                        case 5:
                            contact.city = newData;
                            break;
                        case 6:
                            if (!validationMethods.ValidateZIP(newData))
                            {
                                Console.WriteLine("INVALID ZIP CODE!!! Enter the valid data...\n");
                                return null;
                            }
                            contact.zipcode = newData;
                            break;
                        default:
                            Console.WriteLine("Enter a valid field!!!");
                            break;
                    }
                    Console.WriteLine("Contact Edited!!!");
                    Console.WriteLine("Contact Details AFTER Edit:");
                    Console.WriteLine(contact.ToString());
                    return contact;
                }
            }
            throw new Exception("CONTACT NOT FOUND!!! Please enter the name of an existing contact.");
        }

        public Contact DeleteContact(string deleteName)
        {
            for (int index = 0; index < ContactList.Count; index++)
            {
                Contact contact = ContactList[index];
                if (deleteName == contact.name)
                {
                    ContactList.Remove(contact);
                    Console.WriteLine("Contact Deleted!!!");
                    return contact;
                }
            }
            throw new Exception("CONTACT NOT FOUND!!! Please enter the name of an existing contact.");
        }

        public Contact DisplayContact(string displayName)
        {
            for (int index = 0; index < ContactList.Count; index++)
            {
                Contact contact = ContactList[index];
                if (displayName == contact.name)
                {
                    Console.WriteLine("Details of the Contact: ");
                    Console.WriteLine(contact);
                    Console.WriteLine();
                    return contact;
                }
            }
            throw new Exception("CONTACT NOT FOUND!!! Please enter the name of an existing contact.");
        }

        public void Display()
        {
            Console.WriteLine("The Contacts in the Address Book are: ");
            foreach (Contact contact in ContactList)
            {
                Console.WriteLine(contact.ToString());
                Console.WriteLine();
            }
        }


        public void AddToCSVFile()
        {
            string path = "C:\\Users\\INS 5570\\source\\repos\\AddressBookFileIO\\AddressBookFileIO\\CSVFile.csv";
            StreamWriter Writer = new StreamWriter(path, true);
            CsvWriter CSVwriter = new CsvWriter(Writer, CultureInfo.InvariantCulture);
            CSVwriter.WriteRecords(ContactList);
            CSVwriter.Dispose();
            Writer.Close();
        }

        public bool ReadFromCSVFile()
        {
            List<Contact> CSVFileList = new List<Contact>();
            string path = "C:\\Users\\INS 5570\\source\\repos\\AddressBookFileIO\\AddressBookFileIO\\CSVFile.csv";
            try
            {
                StreamReader reader = new StreamReader(path);
                CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                CSVFileList = csvReader.GetRecords<Contact>().ToList();
                foreach (Contact contact in CSVFileList)
                {
                    Console.WriteLine(contact);
                    Console.WriteLine();
                }
                reader.Close();
                csvReader.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AdddToJSONFile()
        {
            string jsonContent = JsonConvert.SerializeObject(ContactList);
            File.WriteAllText(path, jsonContent);
        }

        public bool ReadFronJSONFile()
        {
            List<Contact> JSONFileList = new List<Contact>();

            try
            {
                string fileContent = File.ReadAllText(path);
                JSONFileList = JsonConvert.DeserializeObject<List<Contact>>(fileContent);
                foreach (var contact in JSONFileList)
                {
                    Console.WriteLine(contact);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
