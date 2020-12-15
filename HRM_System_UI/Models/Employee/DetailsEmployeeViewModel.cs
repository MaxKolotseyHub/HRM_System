using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM_System_UI.Models.Employee
{
    public class DetailsEmployeeViewModel
    {
        public int Id { get; set; }
        [Display(Name="ФИО:")]
        public string FullName { get; set; }
        [Display(Name="Email:")]
        public string Email { get; set; }
        [Display(Name="Номер телефона:")]
        public string PhoneNumber { get; set; }
        [Display(Name="Дата рождения:")]
        public string BirthDay { get; set; }
    }
}