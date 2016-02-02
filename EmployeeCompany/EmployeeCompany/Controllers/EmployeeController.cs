using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using EmployeeCompany.Helper;
using EmployeeCompany.Models;

namespace EmployeeCompany.Controllers {
    public class EmployeeController : Controller {
        private const string NameAll = "Все";
        private const int PageSize = 20;
        private const int FirstPage = 1;
        //
        // GET: /Employee/
        [HttpGet]
        public ActionResult Index(string statustype = "0", int page = FirstPage) {
            int statusId = int.Parse(statustype);
            var model = GetModelForIndex(page, statusId);
            return View(model);
        }

        
        private EmployeeModel GetModelForIndex(int page, int? statusId = null) {
            using (var db = new EmployeeContext()) {
                var query = statusId == null || statusId == 0 ? db.Employees.Include(st => st.StatusType).ToList() : 
                    db.Employees.Where(e => e.StatusTypeId == statusId).ToList();
                var statusView = GetStatusList(db.StatusTypes.ToList(), true);
                var allEmployee = query.Skip((page - 1)*PageSize).Take(PageSize);
                var pageInfo = new PageInfo() { PageNumber = page, TotalItems = query.Count(), PageSize = PageSize, StatusInfo = statusId};
                var model = new EmployeeModel { Employee = allEmployee, StatusList = statusView, PageInfo = pageInfo};
                return model;
            }
        }

        [HttpGet]
        public ActionResult Create() {
            using (var db = new EmployeeContext()) {
                ViewBag.Status = GetStatusList(db.StatusTypes.ToList());
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(Employee employee) {
            
            using (var db = new EmployeeContext()) {
                if (!ModelState.IsValid) {
                    ViewBag.Status = GetStatusList(db.StatusTypes.ToList());
                    return View(employee);
                }
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            using (var db = new EmployeeContext()) {
                var employee = db.Employees.Find(id);
                ViewBag.Status = GetStatusList(db.StatusTypes.ToList(), false, employee);
                return View(employee);
            }
        }

        [HttpPost]
        public ActionResult Edit(Employee employee) {
            using (var db = new EmployeeContext()) {
                if (!ModelState.IsValid) {
                    ViewBag.Status = GetStatusList(db.StatusTypes.ToList());
                    return View(employee);
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id) {
            using (var db = new EmployeeContext()) {
                var employee = db.Employees.Find(id);
                if(employee == null)
                    return RedirectToAction("Index");
                db.Entry(employee).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public FileContentResult SaveFileEmployee() {
            using (var db = new EmployeeContext()) {
                var employees = db.Employees.Where(x => x.StatusTypeId == 1).ToList();
                var fileEmployee = FileHelper.ParseTemplate(employees);
                var bytes = new byte[fileEmployee.Length * sizeof(char)];
                System.Buffer.BlockCopy(fileEmployee.ToCharArray(), 0, bytes, 0, bytes.Length);
                return File(bytes, "application/txt", "Отчет по зарплатам.txt");
            }

        }

        private SelectList GetStatusList(List<StatusType> status, bool isFilter = false, Employee employee = null) {
            if (employee == null && !isFilter)
                return new SelectList(status, "Id", "StatusName");
            if (employee == null) {
                status.Insert(0, new StatusType { Id = 0, StatusName = NameAll });
                return new SelectList(status, "Id", "StatusName");
            }
            return new SelectList(status, "Id", "StatusName", employee.StatusTypeId);   
            }

        

    }
}
