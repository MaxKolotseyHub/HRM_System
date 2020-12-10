using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Dal.Models
{
    public class EmployeeDal
    {
        public EmployeeDal()
        {
            JobHistory = new List<JobHistoryDal>();
            VacationHistory = new List<VacationDal>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? FireDate { get; set; } 
        public int ManagerId { get; set; }
        public virtual List<JobHistoryDal> JobHistory { get; set; } 
        public virtual List<VacationDal> VacationHistory { get; set; } 
        public bool Fired { get; set; } = false;
        public DateTime? Birthday { get; set; }
    }
}
