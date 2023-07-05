namespace AddressBookFileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("Welcome to AddressBook : ");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("******************MENU:******************");
                Console.WriteLine("=> To Add Contact: PRESS 1");
                Console.WriteLine("=> To Edit an Existing Contact: PRESS 2");
                Console.WriteLine("=> To Delete a Contact: PRESS 3");
                Console.WriteLine("=> To Display a specific Contact: PRESS 4");
                Console.WriteLine("=> To Display all Contacts in the Address Book: PRESS 5");
                Console.WriteLine("=> To Read the Contacts from the CSV File: PRESS 6");
                Console.WriteLine("=> To Read the Contacts from the JSON File: PRESS 7");
                Console.WriteLine("=> To EXIT: PRESS 8");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            try
                            {
                                bool isAdded = false;
                                while (!isAdded)
                                {
                                    Console.WriteLine("Enter the details to add a contact: ");

                                    Console.Write("\nEnter name: ");
                                    string name = Console.ReadLine();

                                    Console.Write("Enter email: ");
                                    string email = Console.ReadLine();

                                    Console.Write("Enter phone number: ");
                                    string phone = Console.ReadLine();

                                    Console.Write("Enter state: ");
                                    string state = Console.ReadLine();

                                    Console.Write("Enter city: ");
                                    string city = Console.ReadLine();

                                    Console.Write("Enter zip: ");
                                    string zip = Console.ReadLine();

                                    isAdded = addressBook.AddContact(name, email, phone, state, city, zip);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            try
                            {
                                Console.WriteLine("Enter the First Name of the Contact you want to Edit: ");
                                String editName = Console.ReadLine();

                                addressBook.DisplayContact(editName);

                                Console.WriteLine("Select the name of the Field you want to Edit in Contact's Details:");
                                Console.WriteLine("1.First Name\t2.E-mail Address\t3.Phone Number\t4.State\t5.City\t6.ZIP Code");
                                int option = Convert.ToInt32(Console.ReadLine());

                                string newData = null;
                                switch (option)
                                {
                                    case 1:
                                        Console.Write("Enter the NEW Name: ");
                                        newData = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.Write("Enter the NEW E-mail Address: ");
                                        newData = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.Write("Enter the NEW Phone Number: ");
                                        newData = Console.ReadLine();
                                        break;
                                    case 4:
                                        Console.Write("Enter the NEW State: ");
                                        newData = Console.ReadLine();
                                        break;
                                    case 5:
                                        Console.Write("Enter the NEW City: ");
                                        newData = Console.ReadLine();
                                        break;
                                    case 6:
                                        Console.Write("Enter the NEW ZIP Code: ");
                                        newData = Console.ReadLine();
                                        break;
                                    default:
                                        Console.WriteLine("Enter a valid field!!!");
                                        break;
                                }
                                if (newData != null)
                                {
                                    Contact contact = addressBook.EditContact(editName, newData, option);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 3:
                        {
                            try
                            {
                                Console.WriteLine("Enter the Name of the Contact you want to Delete: ");
                                string deleteName = Console.ReadLine();

                                addressBook.DisplayContact(deleteName);
                                Console.WriteLine("Are you sure you want to DELETE the Contact?");
                                Console.WriteLine("1. YES \t 2. NO");
                                int option = Convert.ToInt32(Console.ReadLine());
                                switch (option)
                                {
                                    case 1:
                                        Contact contact = addressBook.DeleteContact(deleteName);
                                        break;
                                    case 2:
                                        Console.WriteLine("Contact is NOT deleted!!!");
                                        break;
                                    default:
                                        Console.WriteLine("Select a valid option!!!");
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 4:
                        {
                            try
                            {
                                Console.WriteLine("Enter the Name of the Contact you want to Display: ");
                                string displayName = Console.ReadLine();

                                Contact contact = addressBook.DisplayContact(displayName);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 5:
                        {
                            try
                            {
                                addressBook.Display();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        }
                    case 6:
                        {
                            bool read = addressBook.ReadFromCSVFile();
                            if (!read)
                            {
                                Console.WriteLine("ERROR!!!Could Not Read The Contacts From CSV File");
                            }
                            break;
                        }
                    case 7:
                        {
                            bool read = addressBook.ReadFronJSONFile();
                            if (!read)
                            {
                                Console.WriteLine("ERROR!!!Could Not Read The Contacts From JSON File.");
                            }
                            break;
                        }
                    case 8:
                        {
                            addressBook.AdddToJSONFile();
                            addressBook.AddToCSVFile();
                            Environment.Exit(0);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice!!! Please make a valid choice.");
                            break;
                        }
                }
            }
        }
    }
}