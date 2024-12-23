// See https://aka.ms/new-console-template for more information
using Employeepay;
using System;
using System.Collections.Generic;
using System.IO;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            var payrollSystem = new Payrollsystem();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=== Employee Payroll System ===\n");
                Console.ResetColor();
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Display Individual Salaries");
                Console.WriteLine("4. Total Payroll");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice (1-5): ");

                switch (Console.ReadLine())
                {
                    case "1":
                        payrollSystem.AddEmployee();
                        break;
                    case "2":
                        payrollSystem.DisplayAllEmployees();
                        break;
                    case "3":
                        payrollSystem.DisplayIndividualSalaries();
                        break;
                    case "4":
                        payrollSystem.DisplayTotalPayroll();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}