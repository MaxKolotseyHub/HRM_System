using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM_System_WebApi.Models.Jobs
{
    public class IndexJobViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="Минимальный оклад")]
        public decimal MinSalary { get; set; }
        [Required]
        [Display(Name="Максимальный оклад")]
        public decimal MaxSalary { get; set; }
        [Required]
        [Display(Name="Название")]
        public string Title { get; set; }
    }
}