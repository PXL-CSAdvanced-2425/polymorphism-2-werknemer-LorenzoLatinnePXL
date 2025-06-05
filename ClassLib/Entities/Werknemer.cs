using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Entities
{
    public abstract class Werknemer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Type { get; set; }

        public Werknemer(string firstName, string lastName, char type)
        {
            FirstName = firstName;
            LastName = lastName;
            Type = type;
        }

        public abstract string Info();
        public abstract decimal Salary();
    }
}