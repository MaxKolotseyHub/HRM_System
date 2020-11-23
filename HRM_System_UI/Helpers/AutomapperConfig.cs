using AutoMapper;
using HRM_System_Bll.Models;
using HRM_System_UI.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM_System_UI.Helpers
{
    public class AutomapperConfig
    {
        private static Mapper _mapper;
        public static Mapper GetMapper()
        {
            if (_mapper == null)
            {
                var config = new MapperConfiguration(cfg => {
                    cfg.CreateMap<CreateEmployeeViewModel, EmployeeBll>().ReverseMap();
                    cfg.CreateMap<EmployeeBll, IndexEmployeeViewModel>()
                    .ForMember(
                        d=>d.FullName, 
                        opt=>opt.MapFrom(x=>$"{x.SecondName} {x.FirstName} {x.ThirdName}"))
                    .ForMember(
                        d=>d.DepartamentTitle,
                        opt=>opt.MapFrom(x=>x.JobHistory.OrderByDescending(o=>o.Id).FirstOrDefault().Departament.Title ?? "Уволен"))
                    .ForMember(
                        d=>d.JobTitle,
                        opt=>opt.MapFrom(x=>x.JobHistory.OrderByDescending(o=>o.Id).FirstOrDefault().Job.Title ?? "Неизвестно"));
                });

                _mapper = new Mapper(config);
            }
            return _mapper;
        }
    }
}