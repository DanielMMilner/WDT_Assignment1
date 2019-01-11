using System;
using System.Collections.Generic;
using System.Text;

namespace WDT_Assignment1
{
    public class Person
    {   
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public bool IsStaff { get => Id.StartsWith('e'); }
    }
}
