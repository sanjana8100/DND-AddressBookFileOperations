using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    public class Contact
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string State { set; get; }
        public string City { set; get; }
        public string Zipcode { set; get; }

        public Contact(string name, string email, string phone, string state, string city, string zipcode)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.State = state;
            this.City = city;
            this.Zipcode = zipcode;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nPhone: {Phone}\nState: {State}\nCity: {City}\nZip: {Zipcode}";
        }
    }
}
