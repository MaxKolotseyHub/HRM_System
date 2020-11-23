using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Models
{
    public class JobHistoryBll
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual EmployeeBll Employee { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public int JobId { get; set; }
        public virtual JobBll Job { get; set; }
        public int DepartamentId { get; set; }
        public virtual DepartamentBll Departament { get; set; }
    }
}
