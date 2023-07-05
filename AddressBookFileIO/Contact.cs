using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    public class Contact
    {
        public string name;
        public string email;
        public string phone;
        public string state;
        public string city;
        public string zipcode;

        public Contact(string name, string email, string phone, string state, string city, string zipcode)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
            this.state = state;
            this.city = city;
            this.zipcode = zipcode;
        }
        public override string ToString()
        {
            return $"Name: {name}\nEmail: {email}\nPhone: {phone}\nState: {state}\nCity: {city}\nZip: {zipcode}";
        }
    }
}
