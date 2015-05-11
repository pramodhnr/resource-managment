using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace databaseproject
{
    public class Person
    {
        public string Username;
        public string email;

        public Person(string username, string Email)
        {
            Username = username;
            email = Email;
        }
    }
}
