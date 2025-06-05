using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Entities
{
    public class Bediende : Werknemer
    {
        public decimal HourlyWage { get; set; }
        public decimal HoursWorked { get; set; }

        public Bediende(string firstName, string lastName, char type, decimal hourlyWage, decimal hoursWorked)
            : base(firstName, lastName, type)
        {
            HourlyWage = hourlyWage;
            HoursWorked = hoursWorked;
        }

        public override string Info()
        {
            return $"{Type} | {FirstName} {LastName} | Wedde: {HourlyWage:c} * {HoursWorked} = {Salary():c}";
        }

        public override decimal Salary()
        {
            return HourlyWage * HoursWorked;
        }
    }
}
