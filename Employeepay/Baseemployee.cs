using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeepay
{
    public abstract class Baseemployee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }

        public abstract decimal CalculateSalary();

        public override string ToString()
        {
            return $"ID: {ID} | Name: {Name} | Role: {Role} | Total Salary: ${CalculateSalary():F2}";
        }
    }
}
