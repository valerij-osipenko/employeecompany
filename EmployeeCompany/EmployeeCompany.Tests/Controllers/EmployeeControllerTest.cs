using System;
using System.Collections.Generic;
using System.Web.Mvc;
using EmployeeCompany.Controllers;
using EmployeeCompany.DbProvider;
using EmployeeCompany.Helper;
using EmployeeCompany.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeCompany.Tests.Controllers {
    [TestClass]
    public class EmployeeControllerTest {

        private IRepository _repo;
        [TestMethod]
        public void IndexViewModelNotNull() {
            //var employeeController = new EmployeeController(IRepository repository);
            //var result = employeeController.Index() as ViewResult;
            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Generate_Page_Links() {
            HtmlHelper myHelper = null;
            var pageInfo = new PageInfo {PageNumber = 1, PageSize = 20, StatusInfo = 0, TotalItems = 30};
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            MvcHtmlString result = myHelper.PageLinks(pageInfo, pageUrlDelegate);
            Assert.AreEqual(result.ToString(), "<ul class=\"pagination\">" +
                                               "<li class=\"disabled\"><a href=\"Page1\"><<</a></li>" +
                                               "<li class=\"active\"><a href=\"Page1\">1</a></li>" +
                                               "<li><a href=\"Page2\">2</a></li>" +
                                               "<li><a href=\"Page2\">>></a></li></ul>");
        }

        [TestMethod]
        public void ParsTemplateEqalsWhithTemplate() {
            const string templatefile =
                "Имя                            Заработная плата Размер налога З/п с вычетом налога \t\n\r\nИванов И.И.                          20 000,00            15%            17 000,00\r\nПетров И.И.                          10 000,00            25%             7 500,00\r\n";
            var employee = new List<Employee> {
                new Employee {Name = "Иванов И.И.", Post = "Директор", StatusTypeId = 1, Salary = 20000.00},
                new Employee {Name = "Петров И.И.", Post = "Инженер", StatusTypeId = 1, Salary = 10000.00}
            };

            string exitfile = FileHelper.ParseTemplate(employee);
            Assert.AreEqual(exitfile, templatefile);
        }
    }
}