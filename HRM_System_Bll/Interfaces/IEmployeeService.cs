using HRM_System_Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Interfaces
{
    public interface IEmployeeService
    {
        Task Add(EmployeeBll employee, int departamentId, int jobId, DateTime? hireDate);
        Task Fire(int id, DateTime fireDate);
        Task ChangeSalary(int id, decimal newSal);
        Task ChangeJob(int id, int newJobId, DateTime changeDate, int deptId);
        IEnumerable<EmployeeBll> GetAll();
        EmployeeBll GetById(int id);
    }
}
