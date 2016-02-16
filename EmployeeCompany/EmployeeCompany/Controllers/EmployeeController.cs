using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EmployeeCompany.DbProvider;
using EmployeeCompany.Helper;
using EmployeeCompany.Models;

namespace EmployeeCompany.Controllers {
    public class EmployeeController : Controller {
        private const string NameAll = "Все";
        private const int PageSize = 20;
        private const int FirstPage = 1;

        private IRepository _repo;

        public EmployeeController() : this(new DbRepository()) { }

        public EmployeeController(IRepository repository) {
            _repo = repository;
        }

        [HttpGet]
        public ActionResult Index(string statustype = "0", int page = FirstPage) {
            int statusId = int.Parse(statustype);
            var model = GetModelForIndex(page, statusId);
            return View(model);
        }

        
        private EmployeeModel GetModelForIndex(int page, int? statusId = null) {
            var query = statusId == null || statusId == 0 ? _repo.ListWithoutStatus() : 
                        _repo.List().Where(e => e.StatusTypeId == statusId).ToList();
            var statusView = GetStatusList(_repo.ListTypes(), true);
            var enumerable = query as Employee[] ?? query.ToArray();
            var allEmployee = enumerable.Skip((page - 1)*PageSize).Take(PageSize);
            var pageInfo = new PageInfo() { PageNumber = page, TotalItems = enumerable.Count(), PageSize = PageSize, StatusInfo = statusId};
            var model = new EmployeeModel { Employee = allEmployee, StatusList = statusView, PageInfo = pageInfo};
            return model;
        }

        public ActionResult AutoCompleteSearch(string term) {
            var models = _repo.List().Where(a => a.Post.Contains(term)).Select(a => new { Value = a.Post }).Distinct().ToList();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create() {
           ViewBag.Status = GetStatusList(_repo.ListTypes().ToList());
           return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee) {
            if (!ModelState.IsValid) {
                ViewBag.Status = GetStatusList(_repo.ListTypes().ToList());
                return View(employee);
            }
            _repo.Save(employee);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id) {
            var employee = _repo.GetEmployee(id);
            ViewBag.Status = GetStatusList(_repo.ListTypes(), false, employee);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee) {
            if (!ModelState.IsValid) {
                ViewBag.Status = GetStatusList(_repo.ListTypes());
                return View(employee);
            }
            _repo.EditEmployee(employee); 
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) {
            return _repo.DeleteEmployee(id) ? RedirectToAction("Index") : RedirectToAction("Index");
        }

        public FileContentResult SaveFileEmployee() {
            var employees = _repo.List().Where(x => x.StatusTypeId == 1).ToList();
            var fileEmployee = FileHelper.ParseTemplate(employees);
            var bytes = new byte[fileEmployee.Length * sizeof(char)];
            System.Buffer.BlockCopy(fileEmployee.ToCharArray(), 0, bytes, 0, bytes.Length);
            return File(bytes, "application/txt", "Отчет по зарплатам.txt");
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
