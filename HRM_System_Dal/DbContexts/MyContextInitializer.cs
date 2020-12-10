using HRM_System_Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Dal.DbContexts
{
    internal class MyContextInitializer: DropCreateDatabaseAlways<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            base.Seed(context);

            var dept_hr = new DepartamentDal { Title = "Департамент HR" };
            var dept_dev = new DepartamentDal { Title = "Департамент Разработки" };
            var dept_marketing = new DepartamentDal { Title = "Департамент Маркетинга" };

            var job_jun = new JobDal { Title = "Junior", MinSalary = 600, MaxSalary = 900 };
            var job_mid = new JobDal { Title = "Middle", MinSalary = 900, MaxSalary = 1700 };
            var job_sen = new JobDal { Title = "Senior", MinSalary = 1700, MaxSalary = 5000 };

            context.Departaments.AddRange(new [] { dept_hr, dept_dev, dept_marketing});
            context.Jobs.AddRange(new [] { job_jun, job_mid, job_sen});

            context.SaveChanges();
        }
    }
}
