using HRM_System_Bll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM_System_Bll.Interfaces
{
    public interface IDepartamentService
    {
        IEnumerable<DepartamentBll> GetAll();
    }
}
