using HRM_System_Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Dal.DbContexts
{
    internal class MyContextInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);

            var dept_hr = new DepartamentDal { Title = "Отдел по работе с физическими лицами" };
            var dept_dev = new DepartamentDal { Title = "Отдел по работе с юридическими лицами" };
            var dept_marketing = new DepartamentDal { Title = "Отдел по представлению ИМНС в судах" };

            var job_jun = new JobDal { Title = "Специалист 1 категории", MinSalary = 600, MaxSalary = 900 };
            var job_mid = new JobDal { Title = "Специалист 2 категории", MinSalary = 900, MaxSalary = 1700 };
            var job_sen = new JobDal { Title = "Руководитель отдела", MinSalary = 1700, MaxSalary = 5000 };

            context.Departaments.AddRange(new[] { dept_hr, dept_dev, dept_marketing });
            context.Jobs.AddRange(new[] { job_jun, job_mid, job_sen });

            List<EmployeeDal> emplTest = new List<EmployeeDal>();

            for (int i = 0; i < 10; i++)
            {
                var empl1 = new EmployeeDal
                {
                    Birthday = DateTime.Now.AddYears(-24 + i),
                    Email = $"test{i}@gmail.com",
                    Fired = false,
                    FireDate = null,
                    FirstName = $"Тестер{i}",
                    HireDate = DateTime.Now.AddYears(-1 - i),
                    PhoneNumber = "+375297768576",
                    Salary = 1500,
                    SecondName = $"Тестовский{i}",
                    ThirdName = $"Тестовов{i}",
                    JobHistory = new List<JobHistoryDal>
                    {
                       
                    }
                };

                var hist = new JobHistoryDal
                {
                    Departament = dept_dev,
                    Employee = empl1,
                    Salary = 1500,
                    Job = job_mid,
                    StartDate = DateTime.Now.AddYears(-1)
                };

                empl1.JobHistory.Add(hist);

                context.Employees.Add(empl1);
                context.JobHistories.Add(hist);

            }
            context.SaveChanges();
        }
    }
}
