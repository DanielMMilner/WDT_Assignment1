using System;
using System.Collections.Generic;
using System.Text;

namespace WDT_Assignment1
{
    public class Person
    {   
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public Person(string id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}
