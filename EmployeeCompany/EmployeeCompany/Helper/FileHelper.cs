using System.Collections.Generic;
using System.Text;
using EmployeeCompany.Models;

namespace EmployeeCompany.Helper {
    public static class FileHelper {
        private static readonly int[] SiziSalary = new int[2] {10000, 25000};

        public static string ParseTemplate(List<Employee> employees) {
            var fileEmployee = new StringBuilder();
            var tableHeader = new string[4] {"Имя", "Заработная плата", "Размер налога", "З/п с вычетом налога"};
            fileEmployee.AppendFormat("{0,-30} {1,15} {2,13} {3,20} \t\n", tableHeader[0], tableHeader[1], tableHeader[2], tableHeader[3]);
            fileEmployee.AppendLine();
            
            foreach (var employee in employees) {
                fileEmployee.AppendFormat("{0,-30} {1,15:N2} {2,13}% {3,20:N2}", employee.Name, employee.Salary,
                    GetSizeTaxation(employee.Salary), GetSalaryAndTaxation(employee.Salary));
                fileEmployee.AppendLine();
            }
            return fileEmployee.ToString();
        }

        private static double GetSalaryAndTaxation(double salary) {
            return salary - ((salary*GetSizeTaxation(salary))/100);
        }

        private static int GetSizeTaxation(double salary) {
            if (salary < SiziSalary[0]) {
                return (int) Taxation.Minim;
            }
            if (salary > SiziSalary[0] && salary < SiziSalary[1]) {
                return (int) Taxation.Middle;
            }
            return (int) Taxation.Max;
        }
    }
}