using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM_System_WebApi.Models.Employee
{
    public class IndexEmployeeViewModel
    {
        public int Id { get; set; }
        [Display(Name ="ФИО")]
        public string FullName { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name ="Нанят")]
        public DateTime HireDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name ="Дата рождения")]
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        [Display(Name ="Департамент")]
        public string DepartamentTitle { get; set; }
        [Display(Name ="Должность")]
        public string JobTitle { get; set; }
        [Display(Name ="Уволен")]
        public bool Fired { get; set; }
        [Display(Name ="В отпуске")]
        public bool OnVacation { get; set; }
        public double Efficiency { get; set; }
        public double Salary { get; set; }
    }
}