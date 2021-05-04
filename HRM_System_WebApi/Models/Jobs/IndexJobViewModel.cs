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
        public decimal MinSalary { get; set; }
        [Required]
        public decimal MaxSalary { get; set; }
        [Required]
        public string Title { get; set; }
    }
}