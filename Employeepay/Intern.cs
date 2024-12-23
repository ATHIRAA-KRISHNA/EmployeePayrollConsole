using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeepay
{
    public class Intern : Baseemployee
    {
        public Intern()
        {
            Role = "Intern";
        }

        public override decimal CalculateSalary()
        {
            return BasicPay + Allowances - Deductions;
        }
    }
}
