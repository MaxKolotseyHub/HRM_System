using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApi.Models.Vacation
{
    public class CreateVacationViewModel
    {
        public int EmpId { get; set; }
        [Display(Name ="Начало отпуска:")]
        [Required]
        public DateTime StartDate { get; set; }
        [Display(Name ="Окончание отпуска:")]
        [Required]
        public DateTime EndDate { get; set; }
        [Display(Name ="Доступно дней")]
        public int AvailableDays { get; set; }
        public string ErrorMessage { get; set; }
    }
}