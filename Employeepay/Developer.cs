using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeepay
{
    public class Developer : Baseemployee
    {
        public decimal OvertimeHours { get; set; }
        public decimal OvertimeRate { get; set; }

        public Developer()
        {
            Role = "Developer";
        }

        public override decimal CalculateSalary()
        {
            decimal overtimePay = OvertimeHours * OvertimeRate;
            return BasicPay + Allowances - Deductions + overtimePay;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Overtime Pay: ${OvertimeHours * OvertimeRate:F2}";
        }
    }
}
