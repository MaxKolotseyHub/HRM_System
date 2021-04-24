using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM_System_WebApi.Models.Employee
{
    public class EditInfoEmployeeViewModel
    {
        private DateTime? birthday;

        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        [Required]
        public string SecondName { get; set; }
        [Display(Name = "Отчество")]
        [Required]
        public string ThirdName { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Номер телефона")]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Дата рождения")]
        [Required]
        public DateTime? Birthday { get => birthday; set => birthday = value; }
        public string Date
        {
            get
            {
                if (birthday != null)
                    return ((DateTime)birthday).ToString("yyyy-MM-dd");
                return "";
            }
        }
    }
}