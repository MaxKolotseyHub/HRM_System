using AutoMapper;
using HRM_System_Bll.Helpers;
using HRM_System_Bll.Interfaces;
using HRM_System_Bll.Services;
using HRM_System_Dal.DbContexts;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Modules
{
    public class MyNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IEmployeeService>().To<EmployeeService>();
            Kernel.Bind<IJobService>().To<JobService>();
            Kernel.Bind<IDepartamentService>().To<DepartamentService>();
            Kernel.Bind<MyDbContext>().ToSelf();
            Kernel.Bind<IMapper>().ToMethod( (_)=> AutomapperConfig.GetMapper());
        }
    }
}
