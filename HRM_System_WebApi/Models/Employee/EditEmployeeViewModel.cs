using HRM_System_Bll.Models;
using HRM_System_WebApi.Models.JobHistory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HRM_System_WebApi.Models.Employee
{
    public class EditEmployeeViewModel
    {
        public int Id { get; set; }
        [Display(Name ="Текущая заработная плата")]
        public decimal Salary { get; set; }
        [Display(Name ="Новая заработная плата")]
        public decimal NewSalary { get; set; }
        [Display(Name ="Текущий департамент")]
        public int DepartamentId { get; set; }
        [Display(Name ="Новый департамент")]
        public int NewDepartamentId { get; set; }
        [Display(Name ="Текущая должность")]
        public int JobId { get; set; }
        [Display(Name ="Новая должность")]
        public int NewJobId { get; set; }
        public bool Fired { get; set; }
        public IEnumerable<JobBll> Jobs{ get; set; } 
        public IEnumerable<EditJobHistoryViewModel> JobHistory{ get; set; } 
        public IEnumerable<DepartamentBll> Depts{ get; set; }
    }
}