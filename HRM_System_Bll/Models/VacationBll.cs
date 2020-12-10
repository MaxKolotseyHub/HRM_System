using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Models
{
    public class VacationBll
    {
        public int Id { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public int DaysSpent { get; set; }
        public int AvailableDays { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeBll Employee { get; set; }
    }
}
