using AutoMapper;
using HRM_System_Bll.Models;
using HRM_System_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Helpers
{
    internal class AutomapperConfig
    {
        private static Mapper _mapper;
        public static Mapper GetMapper()
        {
            if(_mapper == null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<EmployeeDal, EmployeeBll>().ReverseMap();
                    cfg.CreateMap<JobDal, JobBll>().ReverseMap();
                    cfg.CreateMap<JobHistoryDal, JobHistoryBll>().ReverseMap();
                    cfg.CreateMap<DepartamentDal, DepartamentBll>().ReverseMap();
                    cfg.CreateMap<VacationDal, VacationBll>().ReverseMap();
                });

                _mapper = new Mapper(config);
            }
            return _mapper; 
        }
    }
}
