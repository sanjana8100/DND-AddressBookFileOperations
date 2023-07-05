using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookFileIO
{
    internal class DuplicateContactException : Exception
    {
        public DuplicateContactException() { }

        public DuplicateContactException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
