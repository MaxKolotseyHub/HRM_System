using AutoMapper;
using HRM_System_Bll.Models;
using HRM_System_UI.Models.Employee;
using HRM_System_UI.Models.JobHistory;
using HRM_System_UI.Models.Vacation;
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
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CreateEmployeeViewModel, EmployeeBll>().ReverseMap();
                    cfg.CreateMap<EmployeeBll, IndexEmployeeViewModel>()
                    .ForMember(
                        d => d.FullName,
                        opt => opt.MapFrom(x => $"{x.SecondName} {x.FirstName} {x.ThirdName}"))
                    .ForMember(
                        d => d.DepartamentTitle,
                        opt => opt.MapFrom(x => x.JobHistory.OrderByDescending(o => o.Id).FirstOrDefault().Departament.Title ?? "Уволен"))
                    .ForMember(
                        d => d.JobTitle,
                        opt => opt.MapFrom(x => x.JobHistory.OrderByDescending(o => o.Id).FirstOrDefault().Job.Title ?? "Неизвестно"));
                    cfg.CreateMap<EmployeeBll, EditEmployeeViewModel>()
                    .ForMember(
                        d => d.DepartamentId,
                        opt => opt.MapFrom(x => x.JobHistory.OrderByDescending(o => o.Id).FirstOrDefault().Departament.Id))
                    .ForMember(
                        d => d.NewDepartamentId,
                        opt => opt.MapFrom(x => x.JobHistory.OrderByDescending(o => o.Id).FirstOrDefault().Departament.Id))
                    .ForMember(
                        d => d.JobId,
                        opt => opt.MapFrom(x => x.JobHistory.OrderByDescending(o => o.Id).FirstOrDefault().Job.Id))
                    .ForMember(
                        d => d.NewJobId,
                        opt => opt.MapFrom(x => x.JobHistory.OrderByDescending(o => o.Id).FirstOrDefault().Job.Id))
                    .ForMember(
                        d => d.NewSalary,
                        opt => opt.MapFrom(x => x.Salary))
                    .ForMember(
                        d => d.JobHistory,
                        opt => opt.MapFrom(x => x.JobHistory));


                    cfg.CreateMap<JobHistoryBll, EditJobHistoryViewModel>()
                    .ForMember(
                        d => d.StartDateDt,
                        opt => opt.MapFrom(x => x.StartDate))
                    .ForMember(
                        d => d.EndDateDt,
                        opt => opt.MapFrom(x => x.EndDate))
                    .ForMember(
                        d => d.JobTitle,
                        opt => opt.MapFrom(x => x.Job.Title))
                    .ForMember(
                        d => d.DeptTitle,
                        opt => opt.MapFrom(x => x.Departament.Title));

                    cfg.CreateMap<EmployeeBll, EditInfoEmployeeViewModel>().ReverseMap();

                    cfg.CreateMap<VacationBll, CreateVacationViewModel>()
                    .ForMember(
                        d => d.StartDate,
                        opt => opt.MapFrom(x => x.StartDate ?? DateTime.MinValue))
                    .ForMember(
                        d => d.EndDate,
                        opt => opt.MapFrom(x => x.EndDate ?? DateTime.MinValue))
                    .ForMember(
                        d => d.EmpId,
                        opt => opt.MapFrom(x => x.Id));

                    cfg.CreateMap<EmployeeBll, DetailsEmployeeViewModel>()
                    .ForMember(
                        d => d.FullName,
                        opt => opt.MapFrom(x => $"{x.SecondName} {x.FirstName} {x.ThirdName}"))
                    .ForMember(
                        d => d.BirthDay,
                        opt => opt.MapFrom(x => ((DateTime)x.Birthday).ToShortDateString()));
                });

                _mapper = new Mapper(config);
            }
            return _mapper;
        }
    }
}