using AutoMapper;
using HRM_System_Bll.Modules;
using HRM_System_UI.Helpers;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM_System_UI.Modules
{
    public class UiNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Load(new MyNinjectModule());
            Kernel.Bind<Mapper>().ToMethod(_ => AutomapperConfig.GetMapper()).InSingletonScope();
        }
    }
}