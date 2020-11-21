using HRM_System_Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Dal.DbContexts
{
    public class MyDbContext : DbContext
    {
        public DbSet<EmployeeDal> Employees { get; set; }
        public DbSet<DepartamentDal> Departaments { get; set; }
        public DbSet<JobDal> Jobs { get; set; }
        public DbSet<JobHistoryDal> JobHistories { get; set; }
        public DbSet<VacationDal> Vacations { get; set; }
        public MyDbContext(string connectionString = "Default") : base(connectionString)
        {
            Database.SetInitializer<MyDbContext>(new MyContextInitializer());
        }
        
    }
}
