using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Entities
{
    public class Commissie : Werknemer
    {
        private decimal _comm;

        public decimal CommissionPercentage {get; set;}

        public decimal Turnover { get; set; }
        public decimal Wage { get; set; }

        public Commissie(string firstName, string lastName, char type, decimal wage, decimal percentage, decimal turnover)
            : base(firstName, lastName, type)
        {
            Wage = wage;
            CommissionPercentage = percentage;
            _comm = (turnover * percentage / 100);
            Turnover = turnover;
        }

        public override string Info()
        {
            return $"{Type} | {FirstName} {LastName} | Wedde (incl. comm.): {Wage:c} + {_comm:c} = {Salary():c}";
        }

        public override decimal Salary()
        {
            return Wage + _comm;
        }
    }
}
