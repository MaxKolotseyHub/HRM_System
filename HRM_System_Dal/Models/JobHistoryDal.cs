using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Dal.Models
{
    public class JobHistoryDal
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDal Employee { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public int JobId { get; set; }
        public JobDal Job { get; set; }
        public int DepartamentId { get; set; }
        public DepartamentDal Departament { get; set; }
    }
}
