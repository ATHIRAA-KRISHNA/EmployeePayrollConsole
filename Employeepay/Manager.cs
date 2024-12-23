using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeepay
{

    public class Manager : Baseemployee
    {
        public decimal Bonus { get; set; }

        public Manager()
        {
            Role = "Manager";
        }

        public override decimal CalculateSalary()
        {
            return BasicPay + Allowances - Deductions + Bonus;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Bonus: ${Bonus:F2}";
        }
    }
}
