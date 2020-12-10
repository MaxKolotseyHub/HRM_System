using AutoMapper;
using HRM_System_Bll.Exceptions;
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
    public class VacationService : IVacationService
    {
        private readonly MyDbContext _db;
        private readonly IMapper _mapper;

        public VacationService(MyDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Task Add(VacationBll model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VacationBll> GetAll()
        {
            throw new NotImplementedException();
        }


        public VacationBll GetById(int id)
        {
            var vacation = _db.Vacations.FirstOrDefault(x => x.EmployeeId == id);
            if (vacation == null)
                throw new KeyNotFoundException($"Не найден отпуск сотрудника с идентификационным номером {id}");

            return _mapper.Map<VacationBll>(vacation);
        }

        public async Task StartVacation(int id, DateTime start, DateTime end)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            var vacation = new VacationDal
            {
                EmployeeId = id,
                StartDate = start,
                EndDate = end,
            };

            var availableDays = GetAvailableDays(id);
            vacation.StartDate = start;
            vacation.EndDate = end;
            vacation.DaysSpent = (end - start).Days;
            vacation.AvailableDays = availableDays - vacation.DaysSpent;

            if (vacation.AvailableDays < 0)
                throw new TooManyVacationDaysException();

            emp?.VacationHistory.Add(vacation);

            await _db.SaveChangesAsync();
        }

        public int GetAvailableDays(int id)
        {
            var emp = _db.Employees.FirstOrDefault(x => x.Id == id);
            var vacations = emp.VacationHistory;

            var lastVacation = vacations.OrderByDescending(x => x.EndDate).FirstOrDefault();

            var availableDays = (DateTime.Now - (DateTime)lastVacation.EndDate).Days / 30 * 2;
            availableDays += vacations.Sum(x => x.AvailableDays);
            return availableDays;
        }
    }
}
