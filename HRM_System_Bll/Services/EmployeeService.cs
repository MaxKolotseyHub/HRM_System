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

            var job = _db.Jobs.FirstOrDefault(x => x.Id == jobId);
            if (job == null)
                throw new KeyNotFoundException($"Не найдена должность с идентификационным номером {jobId}");

            var jobHistory = new JobHistoryDal
            {
                DepartamentId = dept.Id,
                JobId = job.Id,
                StartDate = hireDate,
                EmployeeId = model.Id,
                Salary = model.Salary
            };

            model.JobHistory.Add(jobHistory);

            _db.Employees.Add(model);

            await _db.SaveChangesAsync();
        }

        public async Task ChangeJob(int id, int newJobId, DateTime changeDate, int deptId, decimal salary)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден клиент с идентификационным номером {id}");

            var newJob = _db.Jobs.FirstOrDefault(x => x.Id == newJobId);
            if (newJob == null)
                throw new KeyNotFoundException($"Не найдена должность с идентификационным номером {newJobId}");

            var lastJob = emp.JobHistory.FirstOrDefault(x => x.EndDate == null && x.StartDate != DateTime.MinValue);
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
                EmployeeId = emp.Id,
                Salary = salary
            };

            emp.Salary = salary;

            emp.JobHistory.Add(newJobHistoryInfo);
            await _db.SaveChangesAsync();
        }

        public async Task ChangeSalary(int id, decimal newSal)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден клиент с идентификационным номером {id}");

            var lastJob = emp.JobHistory.FirstOrDefault(x => x.EndDate == null && x.StartDate != DateTime.MinValue);
            if (lastJob == null)
                throw new KeyNotFoundException($"Не найдена последняя должность сотрудника");

            var job = _db.Jobs.FirstOrDefault(x => x.Id == lastJob.JobId);
            if (job == null)
                throw new KeyNotFoundException($"Не найдена должность с идентификационным номером {lastJob.JobId}");

            if (newSal >= job.MinSalary && newSal <= job.MaxSalary)
            {
                emp.Salary = newSal;
                lastJob.EndDate = DateTime.Now;
                var newJob = new JobHistoryBll
                {
                    EmployeeId = emp.Id,
                    JobId = job.Id,
                    Salary = newSal,
                    StartDate = DateTime.Now,
                    DepartamentId = lastJob.DepartamentId,
                };
                emp.JobHistory.Add(_mapper.Map<JobHistoryDal>(newJob));
            await _db.SaveChangesAsync();
            }

        }

        public async Task Fire(int id, DateTime fireDate)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден клиент с идентификационным номером {id}");

            var lastJob = emp.JobHistory.FirstOrDefault(x => x.EndDate == null && x.StartDate != DateTime.MinValue);
            if (lastJob == null)
                throw new KeyNotFoundException($"Не найдена последняя должность сотрудника");

            lastJob.EndDate = fireDate;

            emp.Fired = true;

            await _db.SaveChangesAsync();
        }

        public IEnumerable<EmployeeBll> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeBll>>(_db.Employees.ToList());
        }

        public EmployeeBll GetById(int id)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден сотрудник с идентификационным номером {id}");
            return _mapper.Map<EmployeeBll>(emp);
        }

        public async Task Update(EmployeeBll model)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == model.Id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден сотрудник с идентификационным номером {model.Id}");

            emp.Birthday = model.Birthday;
            emp.Email = model.Email;
            emp.FirstName = model.FirstName;
            emp.SecondName = model.SecondName;
            emp.ThirdName = model.ThirdName;

            await _db.SaveChangesAsync();
        }

        public async Task UpdateEfficiency(int id, double value)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            if (emp == null)
                throw new KeyNotFoundException($"Не найден сотрудник с идентификационным номером {id}");

            emp.Efficiency = value;

            await _db.SaveChangesAsync();
        }
    }
}
