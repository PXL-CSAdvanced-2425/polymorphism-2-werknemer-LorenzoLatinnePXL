using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Entities
{
    public class Kader : Werknemer
    {
        public decimal Wage { get; set; }

        public Kader(string firstName, string lastName, char type, decimal wage)
            : base(firstName, lastName, type)
        {
            Wage = wage;
        }

        public override string Info()
        {
            return $"{Type} | {FirstName} {LastName} | Wedde: {Salary():c}";
        }

        public override decimal Salary()
        {
            return Wage;
        }
    }
}
