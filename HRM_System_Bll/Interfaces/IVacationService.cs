using HRM_System_Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Interfaces
{
    public interface IVacationService: IBaseService<VacationBll>
    {
        Task StartVacation(int emplId, DateTime start, DateTime end);
        int GetAvailableDays(int id);
        bool CheckOnVacation(DateTime date, int id);
    }
}
