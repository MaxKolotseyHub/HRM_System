using AutoMapper;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Models;
using HRM_System_Dal.DbContexts;
using HRM_System_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public EmployeeService(MyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task Add(EmployeeBll employee, int departamentId, int jobId, DateTime? hireDate)
        {
            var model = _mapper.Map<EmployeeDal>(employee);

            var dept = _db.Departaments.FirstOrDefault(x => x.Id == departamentId);
            if (dept == null)
                throw new KeyNotFoundException($"Не найден отдел с идентификационным номером {departamentId}");

            var job = _db.Jobs.AsNoTracking().FirstOrDefault(x => x.Id == jobId);
            if (job == null)
                throw new KeyNotFoundException($"Не найдена должность с идентификационным номером {jobId}");

            _db.Employees.Add(model);

            var jobHistory = new JobHistoryDal()
            {
                Departament = dept,
                DepartamentId = dept.Id,
                Job = job,
                JobId = job.Id,
                StartDate = hireDate,
                Employee = model,
                EmployeeId = model.Id
            };

            await _db.SaveChangesAsync();
        }

        public async Task ChangeJob(int id, int newJobId, DateTime changeDate, int deptId)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден клиент с идентификационным номером {id}");

            var newJob = _db.Jobs.AsNoTracking().FirstOrDefault(x => x.Id == newJobId);
            if (newJob == null)
                throw new KeyNotFoundException($"Не найдена должность с идентификационным номером {newJobId}");

            var lastJob = emp.JobHistory.FirstOrDefault(x => x.EndDate == DateTime.MinValue && x.StartDate != DateTime.MinValue);
            if (lastJob == null)
                throw new KeyNotFoundException($"Не найдена последняя должность сотрудника");

            var dept = _db.Departaments.FirstOrDefault(x => x.Id == deptId);
            if (dept == null)
                throw new KeyNotFoundException($"Не найден отдел с идентификационным номером {deptId}");

            lastJob.EndDate = changeDate;

            var newJobHistoryInfo = new JobHistoryDal()
            {
                Job = newJob,
                JobId = newJob.Id,
                Departament = dept,
                DepartamentId = dept.Id,
                StartDate = changeDate,
                Employee = emp,
                EmployeeId = emp.Id
            };

            _db.JobHistories.Add(newJobHistoryInfo);
            await _db.SaveChangesAsync();
        }

        public async Task ChangeSalary(int id, decimal newSal)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден клиент с идентификационным номером {id}");

            var lastJob = emp.JobHistory.FirstOrDefault(x => x.EndDate == DateTime.MinValue && x.StartDate != DateTime.MinValue);
            if (lastJob == null)
                throw new KeyNotFoundException($"Не найдена последняя должность сотрудника");

            var job = _db.Jobs.FirstOrDefault(x => x.Id == lastJob.JobId);
            if (job == null)
                throw new KeyNotFoundException($"Не найдена должность с идентификационным номером {lastJob.JobId}");

            if (newSal >= job.MinSalary && newSal <= job.MaxSalary)
                emp.Salary = newSal;

            await _db.SaveChangesAsync();
        }

        public async Task Fire(int id, DateTime fireDate)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден клиент с идентификационным номером {id}");

            var lastJob = emp.JobHistory.FirstOrDefault(x => x.EndDate == DateTime.MinValue && x.StartDate != DateTime.MinValue);
            if (lastJob == null)
                throw new KeyNotFoundException($"Не найдена последняя должность сотрудника");

            lastJob.EndDate = fireDate;

            await _db.SaveChangesAsync();
        }

        public IEnumerable<EmployeeBll> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeBll>>(_db.Employees.ToList());
        }
    }
}
