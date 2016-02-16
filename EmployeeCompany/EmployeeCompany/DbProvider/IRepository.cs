using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeCompany.Models;

namespace EmployeeCompany.DbProvider
{
    public interface IRepository {
        void Save(Employee employee);
        IEnumerable<Employee> List();
        IEnumerable<Employee> ListWithoutStatus();
        void EditEmployee(Employee employee);
        List<StatusType> ListTypes();
        Employee GetEmployee(int id);
        bool DeleteEmployee(int id);
    }
}
