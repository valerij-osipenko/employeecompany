using System.Collections.Generic;
using System.Data.Entity;
using EmployeeCompany.Models;

namespace EmployeeCompany {
    public class EmployeeContext : DbContext {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<StatusType> StatusTypes { get; set; } 
    }
}