using System.ComponentModel.DataAnnotations;

namespace EmployeeCompany.Models {
    public class Employee {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите Ф.И.О. сотрудника")]
        [Display(Name = "Ф.И.О. сотрудника")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите занимаемую должность")]
        [Display(Name = "Занимаемая должность")]
        public string Post { get; set; }

        [Display(Name = "Статус")]
        public int StatusTypeId { get; set; }
        public StatusType StatusType { get; set; }

        [Required(ErrorMessage = "Введите размер заработной платы")]
        [Display(Name = "Заработная плата")]
        //[RegularExpression(@"\d", ErrorMessage = "Должны содержаться только цифры")]
        public double Salary { get; set; }

    }
}