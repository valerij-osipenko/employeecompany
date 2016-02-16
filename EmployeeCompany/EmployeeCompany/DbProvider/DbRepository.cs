
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using EmployeeCompany.Models;

namespace EmployeeCompany.DbProvider
{
    public class DbRepository : IRepository, IDisposable
    {
        private EmployeeContext db = new EmployeeContext();

        public void Save(Employee employee) {
            db.Employees.Add(employee);
            db.SaveChanges();
        }

        public IEnumerable<Employee> List() {
            return db.Employees.ToList();
        }

        public IEnumerable<Employee> ListWithoutStatus()
        {
            var empl = db.Employees.Include(st => st.StatusType).ToList();
            return empl;
        }

        public void EditEmployee(Employee employee) {
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<StatusType> ListTypes()
        {
            return db.StatusTypes.ToList();
        } 

        public Employee GetEmployee(int id) {
            return db.Employees.Find(id);
        }

        public bool DeleteEmployee(int id) {
            var employee = db.Employees.Find(id);
            if (employee == null)
                return false;  
            db.Entry(employee).State = EntityState.Deleted;
            db.SaveChanges();
            return true;
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                if (db != null) {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}