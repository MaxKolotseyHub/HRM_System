using HRM_System_Bll.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRM_System_WebApi.Models.Employee
{
    public class CreateEmployeeViewModel
    {
        [Display(Name ="Имя")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name ="Фамилия")]
        [Required]
        public string SecondName { get; set; }
        [Display(Name ="Отчество")]
        [Required]
        public string ThirdName { get; set; }
        [Required]
        public string Email { get; set; }
        [Display(Name ="Номер телефона")]
        [Required]
        [RegularExpression(@"\+375\d{9}", ErrorMessage ="Телефон должен быть в формате +375ХХХХХХХХХ")]
        public string PhoneNumber { get; set; }
        [Display(Name ="Оклад")]
        [Required]
        public decimal Salary { get; set; }
        [Display(Name ="Дата рождения")]
        [Required]
        public DateTime? Birthday { get; set; }
        [Display(Name ="Дата найма")]
        [Required]
        public DateTime? HireDate { get; set; }
        [Display(Name ="Департамент")]
        [Required]
        public int DepartamentId { get; set; }
        [Display(Name ="Должность")]
        [Required]
        public int JobId { get; set; }
        public double Efficiency { get; set; }
        public IEnumerable<JobBll> Jobs { get; set; }
        public IEnumerable<DepartamentBll> Depts { get; set; }
    }
}