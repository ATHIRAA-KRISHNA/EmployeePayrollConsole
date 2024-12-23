using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeepay
{
    public class Payrollsystem
    {
        private List<Baseemployee> employees;

        public Payrollsystem()
        {
            employees = new List<Baseemployee>();
        }

        private Baseemployee CreateEmployee(int roleChoice)
        {
            Baseemployee employee = null;

            switch (roleChoice)
            {
                case 1: // Manager
                    var manager = new Manager();
                    Console.Write("Enter Employee ID: ");
                    manager.ID = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    manager.Name = Console.ReadLine();
                    Console.Write("Enter Basic Pay: ");
                    manager.BasicPay = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Allowances: ");
                    manager.Allowances = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Bonus: ");
                    manager.Bonus = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Deductions: ");
                    manager.Deductions = decimal.Parse(Console.ReadLine());
                    employee = manager;
                    break;

                case 2: // Developer
                    var developer = new Developer();
                    Console.Write("Enter Employee ID: ");
                    developer.ID = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    developer.Name = Console.ReadLine();
                    Console.Write("Enter Basic Pay: ");
                    developer.BasicPay = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Allowances: ");
                    developer.Allowances = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Overtime Hours: ");
                    developer.OvertimeHours = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Overtime Rate: ");
                    developer.OvertimeRate = decimal.Parse(Console.ReadLine());
                    employee = developer;
                    Console.Write("Enter Deductions: ");
                    developer.Deductions = decimal.Parse(Console.ReadLine());
                    break;

                case 3: // Intern
                    var intern = new Intern();
                    Console.Write("Enter Employee ID: ");
                    intern.ID = Console.ReadLine();
                    Console.Write("Enter Name: ");
                    intern.Name = Console.ReadLine();
                    Console.Write("Enter Basic Pay: ");
                    intern.BasicPay = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Allowances: ");
                    intern.Allowances = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Deductions: ");
                    intern.Deductions = decimal.Parse(Console.ReadLine());
                    employee = intern;
                    break;
            }

            return employee;
        }

        public void AddEmployee()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("=== Add New Employee ===\n");
            Console.ResetColor();
            Console.WriteLine("Enter role choice:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Developer");
            Console.WriteLine("3. Intern");
            Console.Write("\nChoice: ");

            if (int.TryParse(Console.ReadLine(), out int roleChoice) && roleChoice >= 1 && roleChoice <= 3)
            {
                try
                {
                    var employee = CreateEmployee(roleChoice);

                    if (employees.Any(e => e.ID == employee.ID))
                    {
                        Console.WriteLine("\nError: Employee ID already exists!");
                    }
                    else
                    {
                        employees.Add(employee);
                        Console.WriteLine("\nEmployee added successfully!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nError: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid role choice!");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void DisplayAllEmployees()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== All Employees ===\n");
            Console.ResetColor();
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee);
                    Console.WriteLine("----------------------------------------");
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void DisplayIndividualSalaries()
        {
            Console.Clear();
            Console.WriteLine("=== Individual Salaries ===\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.Name} (ID: {employee.ID}, Role: {employee.Role})");
                    Console.WriteLine($"Basic Pay: ${employee.BasicPay:F2}");
                    Console.WriteLine($"Allowances: ${employee.Allowances:F2}");
                    Console.WriteLine($"Deductions: ${employee.Deductions:F2}");

                    if (employee is Manager manager)
                    {
                        Console.WriteLine($"Bonus: ${manager.Bonus:F2}");
                    }
                    else if (employee is Developer developer)
                    {
                        Console.WriteLine($"Overtime Pay: ${developer.OvertimeHours * developer.OvertimeRate:F2}");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Total Salary: ${employee.CalculateSalary():F2}");
                    Console.WriteLine("----------------------------------------");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public void DisplayTotalPayroll()
        {
            Console.Clear();
            Console.WriteLine("=== Total Payroll ===\n");

            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
            }
            else
            {
                decimal totalPayroll = employees.Sum(e => e.CalculateSalary());
                Console.WriteLine($"Total number of employees: {employees.Count}");
                Console.WriteLine($"Total payroll amount: ${totalPayroll:F2}");

                // Display role-wise breakdown
                Console.WriteLine("\nBreakdown by Role:");
                Console.WriteLine($"Managers: {employees.Count(e => e is Manager)}");
                Console.WriteLine($"Developers: {employees.Count(e => e is Developer)}");
                Console.WriteLine($"Interns: {employees.Count(e => e is Intern)}");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
