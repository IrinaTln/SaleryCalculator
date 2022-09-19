using System;
using System.Reflection.Metadata;

namespace SaleryCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your salary: ");
            double salary = int.Parse(Console.ReadLine());
            double result = 0;
            SalaryBeforeTax(salary, out result);

            if (salary < 1200)
            {
                MonthlySalaryIsLessThen1200Euro(ref salary, result);
            }
            else if (salary >= 1200 && salary <= 2100)
            {
                MonthlySalaryIsBetween1200To2100Euro(ref salary, result);
            }
            else
            {
                MonthlySalaryIsMoreThen2100Euro(ref salary, result);
            }
            Console.WriteLine($"Salary: {Math.Round(salary,2)}");
        }

        static void SalaryBeforeTax(double salary, out double result)
        {
            double pensionTax = salary * 0.02;
            double unemploymentTax = salary * 0.016;
            result = salary - (pensionTax + unemploymentTax);
        }
        static void MonthlySalaryIsLessThen1200Euro(ref double salary, double result)
        {
            
            double salaryWithoutMin = result - 500;
            double vat = salaryWithoutMin * 0.2;
            salary = result - vat;
        }

        static void MonthlySalaryIsBetween1200To2100Euro(ref double salary, double result)
        {
            double taxFree = 500 - 0.5556 * (salary - 1200);
            double salaryWithoutMin = result - taxFree;
            double vat = salaryWithoutMin * 0.2;
            salary = result - vat;

        }

        static void MonthlySalaryIsMoreThen2100Euro(ref double salary, double result)
        {
            double vat = salary * 0.1928;
            salary = result - vat;
        }
    }
}
