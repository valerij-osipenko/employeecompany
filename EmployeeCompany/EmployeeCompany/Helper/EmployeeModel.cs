
using System.Collections.Generic;
using System.Web.Mvc;
using EmployeeCompany.Models;

namespace EmployeeCompany.Helper {
    public class EmployeeModel {
        public IEnumerable<Employee> Employee { get; set; }
        public SelectList StatusList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}