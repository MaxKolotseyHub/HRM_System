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
        public virtual EmployeeDal Employee { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public int JobId { get; set; }
        public virtual JobDal Job { get; set; }
        public int DepartamentId { get; set; }
        public decimal Salary { get; set; }
        public virtual DepartamentDal Departament { get; set; }
    }
}
